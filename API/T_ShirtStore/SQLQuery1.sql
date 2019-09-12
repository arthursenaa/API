create database T_ShirtStore

use T_ShirtStore

create Table Perfis
(
	IdPerfil		int primary key identity ,
	Perfil			varchar(25) not null unique
)

insert into Perfis (Perfil) values ('Gerente'),('Atendente')

select * from Perfis

create table Camisa
(
	IdCamisa	int primary key identity ,
	Descricao	text not null 
)

create table Tamanho
(
	IdTamanho		int primary key identity,
	Tamanho		varchar(2) not null unique
)

insert into Tamanho Values ('PP'),('P'),('M'),('G'),('GG')

create table Estoque
(
	IdEstoque		int primary key identity,
	Camisa			int Foreign key References Camisa (IdCamisa),
	Tamanho			int Foreign key References Tamanho(IdTamanho),
	Cor				varchar(255) not null 
)

create table Empresa 
(
	IdEmpresa		int primary key identity,			
	Nome			varchar(255) not null 
)


create table Usuario 
(
	IdUsuario			int primary key identity,	
	Email				varchar(255) not null unique,
	Senha				varchar(255) not null ,
	IdEmpresa			int Foreign key References Empresa (IdEmpresa)
)

drop table Empresa#Estoque

create table EmpresaEstoque
(
	Id					int primary key identity,
	IdEmpresa			int Foreign key References Empresa (IdEmpresa),
	IdEstoque			int Foreign key References Estoque (IdEstoque)
)