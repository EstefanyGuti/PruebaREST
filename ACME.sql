Create DataBase ACME
USE ACME
 create table TipoEmpresa
 (
 IDTipoEmpresa int primary key identity (1,1),
 TipoEmpresa varchar(100)not null,
 Descripcion varchar(1000)not null,
 Sigla varchar (10)not null,
 Activo bit not null,
 )

 create table Empresa
 (
 IDEmpresa int,
 IDTipoEmpresa int,
 Empresa varchar (50),
 Direccion varchar (100),
 RUC varchar (15),
 FechaCreacion date,
 Presupuesto decimal (18,2),
 Activo bit,
 )