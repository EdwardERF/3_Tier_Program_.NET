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

--RNE, tal numero de estado, significa tal estado.

