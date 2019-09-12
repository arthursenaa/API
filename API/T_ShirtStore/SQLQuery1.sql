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
