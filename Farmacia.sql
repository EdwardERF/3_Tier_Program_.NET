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
	apellido varchar(20) not null,
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




/*
----------------SP Necesarios----------------
EliminarUsuario // HECHO
Logueo (BuscarUsuario) // HECHO
AltaEmpleado // HECHO
ModificarEmpleado // HECHO
EliminarEmpleado
BuscarEmpleado
AltaCliente
AltaFarmaceutica
ModificarFarmaceutica
EliminarFarmaceutica
BuscarFarmaceutica
AltaMedicamento
ModificarMedicamento
EliminarMedicamento
ListarMedicamento
BuscarMedicamento
AltaPedido
EliminarPedido
ListarTodo (Todos los pedidos)
ListarGenerados (Pedidos)
ListarEnviados (Pedidos)
ListarEntregados (Pedidos)
BuscarPedido
CambioEstadoPedido
*/


--RNE, tal numero de estado, significa tal estado.