use master
go

if exists(select * from SysDataBases where name = 'Farmacia')
	begin
		drop database Farmacia
	end
go

create database Farmacia
go

use Farmacia
go

create table Farmaceutica
(
	ruc int primary key,
	nombre varchar(20) not null,
	correo varchar(50) not null,
	calle varchar(50) not null,
	numero int not null,
	apto int not null
)
go

create table Medicamento
(
	ruc int not null foreign key references Farmaceutica(ruc),
	codigo int not null,
	nombre varchar(20) not null,
	descripcion varchar(100),
	precio int not null,
	primary key(ruc, codigo)
)
go

create table Usuario
(
	nomUsu varchar(20) primary key,
	pass varchar(20) not null,
	nombre varchar(20) not null,
	apellido varchar(20) not null
)
go

create table Cliente
(
	nomUsu varchar(20) primary key foreign key references Usuario(nomUsu),
	dirEntrega varchar(100) not null,
)
go

create table Telefono
(
	nomUsu varchar(20) not null foreign key references Cliente(nomUsu),
	telefono int not null,
	primary key(nomUsu, telefono)
)
go

create table Empleado
(
	nomUsu varchar(20) primary key foreign key references Usuario(nomUsu),
	horaInicio datetime not null,
	horaFinal datetime not null
)
go

create table Pedido
(
	numero int primary key,
	cliente varchar(20) foreign key references Cliente(nomUsu),
	rucMedicamento int not null,
	codMedicamento int not null,
	foreign key (rucMedicamento, codMedicamento) references Medicamento(ruc, codigo),
	cantidad int,
	estado int
)
go

CREATE PROCEDURE EliminarUsuario
@nomUsu VARCHAR(20)
AS
BEGIN
	DELETE Usuario WHERE nomUsu = @nomUsu
END
GO

CREATE PROCEDURE LogueoUsuario
@nomUsu VARCHAR(20),
@pass VARCHAR(20)
AS
BEGIN
	SELECT *
	FROM Usuario U
	WHERE U.nomUsu = @nomUsu AND U.pass = @pass
END
GO

CREATE PROCEDURE AltaEmpleado
@nomUsu VARCHAR(20),
@pass VARCHAR(20),
@nombre VARCHAR(20),
@apellido VARCHAR(20),
@horaInicio DATETIME,
@horaFinal DATETIME
AS
BEGIN
	BEGIN TRAN
		INSERT Usuario VALUES(@nomUsu, @pass, @nombre, @apellido)
		if @@ERROR <> 0
			begin
				ROLLBACK TRAN
				return -1 --Esto es, error de transaccion
			end
		INSERT Empleado VALUES(@nomUsu, @horaInicio, @horaFinal)
		if @@ERROR <> 0
			BEGIN
				ROLLBACK TRAN
				return -1 --Esto es, error de transaccion
			END
	COMMIT TRAN
	RETURN 1 --Esto es, transaccion exitosa
END
GO

CREATE PROCEDURE ModificarEmpleado
@nomUsu VARCHAR(20),
@pass VARCHAR(20),
@nombre VARCHAR(20),
@apellido VARCHAR(20),
@horaInicio DATETIME,
@horaFinal DATETIME
AS
BEGIN
	IF NOT EXISTS(SELECT * FROM Empleado WHERE nomUsu = @nomUsu)
		RETURN -1 --Esto es, no existe un empleado con ese nombre

	IF EXISTS(SELECT * FROM Cliente WHERE nomUsu = @nomUsu)
		RETURN -2 --Esto es, ERROR - Se esta intentando modificar un cliente, no un empleado

	UPDATE Empleado
	SET pass = @pass, nombre = @nombre, apellido = @apellido, horaInicio = @horaInicio, horaFinal = @horaFinal
	WHERE nomUsu = @nomUsu
	IF @@ERROR <> 0
		RETURN -1
	ELSE
		RETURN 1
END
GO

CREATE PROCEDURE EliminarEmpleado
@nomUsu VARCHAR(20)
AS
BEGIN
	IF NOT EXISTS(SELECT * FROM Empleado WHERE nomUsu = @nomUsu)
		RETURN -1 --Esto es, Error - No existe empleado con ese nombre de usuario
	ELSE
		BEGIN
			BEGIN TRAN
				DELETE Empleado WHERE nomUsu = @nomUsu
				IF @@ERROR <> 0
					BEGIN
						ROLLBACK TRAN
						RETURN -2 --Error SQL
					END
				DELETE Usuario WHERE nomUsu = @nomUsu
				IF @@ERROR <> 0
					BEGIN
						ROLLBACK TRAN
						RETURN -2 --Error SQL
					END
			COMMIT TRAN
			RETURN 1
		END
END
GO

CREATE PROCEDURE BuscarEmpleado
@nomUsu VARCHAR(20)
AS
BEGIN
	IF NOT EXISTS(SELECT * FROM Empleado WHERE nomUsu = @nomUsu)
		RETURN -1 --No existe empleado
	ELSE
		BEGIN
		SELECT * FROM Empleado WHERE nomUsu = @nomUsu
		END
END
GO

CREATE PROCEDURE AltaCliente
@nomUsu VARCHAR(20),
@pass VARCHAR(20),
@nombre VARCHAR(20),
@apellido VARCHAR(20),
@dirEntrega VARCHAR(100)
AS
BEGIN
	BEGIN TRAN
		INSERT Usuario VALUES(@nomUsu, @pass, @nombre, @apellido)
		IF @@ERROR <> 0
			BEGIN
				ROLLBACK TRAN
				RETURN -1 --Error SQL
			END
		INSERT Cliente VALUES(@nomUsu, @dirEntrega)
		IF @@ERROR <> 0
			BEGIN
				ROLLBACK TRAN
				RETURN -1 --Error SQL
			END
	COMMIT TRAN
	RETURN 1 --Transaccion exitosa
END
GO

CREATE PROCEDURE AltaFarmaceutica
@ruc int,
@nombre varchar(20),
@apellido varchar(20),
@correo varchar(50),
@calle varchar(50),
@numero int,
@apto int
AS
BEGIN
	BEGIN TRAN
		INSERT Farmaceutica VALUES(@ruc, @nombre, @apellido, @correo, @calle, @numero, @apto)
		IF @@ERROR <> 0
			BEGIN
				ROLLBACK TRAN
				RETURN -1 --Error SQL
			END
	COMMIT TRAN
	RETURN 1 --Transaccion exitosa
END
GO

CREATE PROCEDURE ModificarFarmaceutica
@ruc int,
@nombre varchar(20),
@correo varchar(50),
@calle varchar(50),
@numero int,
@apto int
AS
BEGIN
	IF NOT EXISTS(SELECT * FROM Farmaceutica WHERE ruc = @ruc)
		RETURN -1 --Esto es, no existe una farmaceutica con ese nombre

	UPDATE Farmaceutica
	SET nombre = @nombre, correo = @correo, calle = @calle, numero = @numero, apto = @apto
	WHERE ruc = @ruc
	IF @@ERROR <> 0
		RETURN -1
	ELSE
		RETURN 1
END
GO

CREATE PROCEDURE EliminarFarmaceutica
@ruc int
AS
BEGIN
	IF NOT EXISTS(SELECT * FROM Farmaceutica WHERE ruc = @ruc)
		RETURN -1 --Esto es, no existe Farmaceutica con ese ruc

	IF EXISTS(SELECT * FROM Pedido P INNER JOIN Medicamento M ON P.ruc = M.ruc WHERE P.ruc = @ruc)
		RETURN -2 --Esto es, no se puede eliminar, hay pedidos asociados a esta farmaceutica

	IF NOT EXISTS(SELECT * FROM Pedido P INNER JOIN Medicamento M ON P.ruc = M.ruc WHERE P.ruc = @ruc)
		BEGIN
			IF NOT EXISTS(SELECT * FROM Medicamento WHERE ruc = @ruc)
				BEGIN
					DELETE Farmaceutica WHERE ruc = @ruc
					RETURN 1 --Esto es, transaccion exitosa
				END
			ELSE IF EXISTS(SELECT * FROM Medicamento WHERE ruc = @ruc)
				BEGIN
					BEGIN TRAN
						DELETE Medicamento WHERE ruc = @ruc
						IF @@ERROR <> 0
							BEGIN
								ROLLBACK TRAN
								RETURN -1 --Error SQL
							END
						DELETE Farmaceutica WHERE ruc = @ruc
						IF @@ERROR <> 0
							BEGIN
								ROLLBACK TRAN
								RETURN -1 --Error SQL
							END
					COMMIT TRAN
					RETURN 1 --Esto es, transaccion exitosa
				END
		END
END
GO

CREATE PROCEDURE BuscarFarmaceutica
@ruc INT
AS
BEGIN
	SELECT * FROM Farmaceutica WHERE ruc = @ruc
END	
GO

CREATE PROCEDURE AltaMedicamento
@ruc INT,
@codigo INT,
@nombre VARCHAR(20),
@descripcion VARCHAR(100),
@precio INT
AS
BEGIN
	IF EXISTS(SELECT * FROM Medicamento WHERE ruc = @ruc AND codigo = @codigo)
		RETURN -1 --Esto es, ya existe medicamento con ese ruc y codigo
	ELSE
		BEGIN TRAN
			INSERT Medicamento VALUES(@ruc, @codigo, @nombre, @descripcion, @precio)
			IF @@ERROR <> 0
				BEGIN
					ROLLBACK TRAN
					RETURN -2 --Esto es, error de SQL
				END
		COMMIT TRAN
		RETURN 1 --Esto es, transaccion exitosa
END
GO

CREATE PROCEDURE ModificarMedicamento
@ruc INT,
@codigo INT,
@nombre VARCHAR(20),
@descripcion VARCHAR(100),
@precio INT
AS
BEGIN
	IF NOT EXISTS(SELECT * FROM Medicamento WHERE ruc = @ruc)
		RETURN -1 --Esto es, no existe Medicamento con ese ruc
	ELSE
		BEGIN TRAN
			UPDATE Medicamento
			SET codigo = @codigo, nombre = @nombre, descripcion = @descripcion, precio = @precio
			WHERE ruc = @ruc
			IF @@ERROR <> 0
				BEGIN
					ROLLBACK TRAN
					RETURN -2 --Esto es, error SQL
				END
		COMMIT TRAN
		RETURN 1 --Esto es, transaccion exitosa
END
GO

CREATE PROCEDURE EliminarMedicamento
@ruc int,
@codigo INT
AS
BEGIN
	IF NOT EXISTS(SELECT * FROM Medicamento WHERE ruc = @ruc AND codigo = @codigo)
		RETURN -1 --Esto es, no existe medicamento
	ELSE
		BEGIN TRAN
			DELETE Pedido WHERE rucMedicamento = @ruc AND codMedicamento = @codigo
			IF @@ERROR <> 0
				BEGIN
					ROLLBACK TRAN
					RETURN -2 --Esto es, error SQL
				END
			DELETE Medicamento WHERE ruc = @ruc AND codigo = @codigo
			IF @@ERROR <> 0
				BEGIN
					ROLLBACK TRAN
					RETURN -2 --Esto es, error SQL
				END
		COMMIT TRAN
		RETURN 1 --Esto es, transaccion exitosa
END
GO

CREATE PROCEDURE ListarMedicamento
AS
BEGIN
	SELECT * FROM Medicamento
END
GO

CREATE PROCEDURE BuscarMedicamento
@ruc INT,
@codigo INT
AS
BEGIN
	SELECT * FROM Medicamento WHERE ruc = @ruc AND codigo = @codigo
END
GO

CREATE PROCEDURE AltaPedido
@numero int,
@cliente varchar(20),
@rucMedicamento int,
@codMedicamento int,
@cantidad int
AS
BEGIN
	INSERT Pedido VALUES(@numero, @cliente, @rucMedicamento, @codMedicamento, @cantidad, 0)
	IF @@ERROR <> 0
		RETURN -1 --Esto es, error SQL
	ELSE
		RETURN 1 --Esto es, transaccion exitosa
END
GO

CREATE PROCEDURE EliminarPedido
@numero INT
AS
BEGIN
	DELETE Pedido WHERE numero = @numero
	IF @@ERROR <> 0
		RETURN -1 --Esto es, error SQL
	ELSE
		RETURN 1 --Esto es, transaccion exitosa
END
GO

CREATE PROCEDURE ListarTodo --PEDIDOS
AS
BEGIN
	SELECT * FROM Pedido
END
GO

CREATE PROCEDURE ListarGenerados
AS
BEGIN
	SELECT * FROM Pedido WHERE estado = 0
END
GO

CREATE PROCEDURE ListarEnviados
AS
BEGIN
	SELECT * FROM Pedido WHERE estado = 1
END
GO

CREATE PROCEDURE ListarEntregados
AS
BEGIN
	SELECT * FROM Pedido WHERE estado = 2
END
GO

CREATE PROCEDURE BuscarPedido
@numero INT
AS
BEGIN
	SELECT * FROM Pedido WHERE numero = @numero
END
GO

CREATE PROCEDURE CambioEstadoPedido
@numero INT
AS
BEGIN
	SELECT * FROM Pedido WHERE numero = @numero

	IF(Pedido.estado = 0)
		UPDATE Pedido SET estado = 1 WHERE Pedido.numero = @numero
	ELSE IF(Pedido.estado = 1)
		UPDATE Pedido SET estado = 2 WHERE Pedido.numero = @numero
END
GO

/*
----------------SP Necesarios----------------
EliminarUsuario // HECHO
Logueo (BuscarUsuario) // HECHO
AltaEmpleado // HECHO
ModificarEmpleado // HECHO
EliminarEmpleado // HECHO
BuscarEmpleado // HECHO
AltaCliente // HECHO
AltaFarmaceutica // HECHO
ModificarFarmaceutica // HECHO
EliminarFarmaceutica // HECHO
{
	Para eliminar Farmaceutica, hay que eliminar todas las tablas y datos que generen dependencia a ella:
	- Si tiene pedidos asociados, no se podrá eliminar la farmacéutica.
	Si no los tiene, entonces:
	- Se deben eliminar medicamentos que tenga el ruc de la Farmaceutica
	- Se borra, ahora si, correctamente la farmaceutica.
}
BuscarFarmaceutica // HECHO
AltaMedicamento // HECHO
ModificarMedicamento // HECHO
EliminarMedicamento // HECHO
{
	Para eliminar Medicamento, hay que eliminar dependencias
	- Se eliminan pedidos con el medicamento asociado
	- Ahora si, se borra correctamente el medicamento
}
ListarMedicamento // HECHO
BuscarMedicamento // HECHO
AltaPedido // HECHO
EliminarPedido // HECHO
ListarTodo (Todos los pedidos) // HECHO
ListarGenerados (Pedidos) // HECHO
ListarEnviados (Pedidos) // HECHO
ListarEntregados (Pedidos) // HECHO
BuscarPedido // HECHO
CambioEstadoPedido // HECHO
*/


--RNE, tal numero de estado, significa tal estado.