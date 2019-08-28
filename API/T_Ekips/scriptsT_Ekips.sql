create database T_Ekips

use T_Ekips

-----DDL-----

Create table Permissao
(
	IdPermissao		INT primary key identity ,
	Permissao		varchar(255) not null 
)

Create table Usuario 
(
	IdUsuario		INT primary key identity ,
	Nome			varchar(255) not null,
	Email			varchar(255) not null unique,
	Senha			varchar(255) not null,
	IdPermissao		Int foreign key References  Permissao(IdPermissao)
)
--select * from Permissao
--select * from Ativo

create Table Ativo
(
	IdAtividade		INT primary key identity,
	Ativo			varchar(255) not null unique,
)

create table Cargo
(
	IdCargo			INT primary key identity,
	Cargo			varchar(255) not null unique,
	IdAtivo			int foreign key References Ativo(IdAtividade)
)

create table Departamento
(
	IdDepartamento			INT primary key identity,
	Departamento			varchar(255) not null unique,
)

create table Funcionario
(
	IdFuncionario		INT primary key identity ,
	Nome				varchar(255) not null,
	CPF					varchar(15) not null unique,
	DataNascimento		Date not null,
	Salario				Int not null,
	IdDepartamento		int foreign key References Departamento(IdDepartamento),
	IdCargo				int foreign key References Cargo(IdCargo),
	IdUsuario			int foreign key References Usuario(IdUsuario)
)


-----DML-----

insert into Ativo (Ativo) values ('Ativo'),('Inativo');

insert into Permissao(Permissao) values ('ADMINISTRADOR'),('COMUM');

insert into Cargo(Cargo) values ('Advogado Trabalhista'),('Product Owner');

select * from Ativo
select * from Cargo


--insert into Cargo(IdAtivo) values (1),( 1);

insert into Departamento(Departamento) values ('Jurídico '),('Tecnologia');
