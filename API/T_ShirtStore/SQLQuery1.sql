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
ALTER TABLE Camisa ADD Nome varchar(25) not null unique


insert into Camisa (Nome,Descricao) values ('camiseta','Khelf, nunca nem comprei.')

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
	Cor				varchar(255) not null ,
)

select * from Estoque

ALTER TABLE Estoque ADD Quantidade int not null

insert into Estoque (Camisa,Tamanho,Cor,IdEmpresa , Quantidade) 
values (1,2,'Azul',1,3),(1,2,'Roxa',1,2)
					 	
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
	,IdPerfil			int Foreign key References Perfis (IdPerfil)	
)

drop table Usuario

select * from Usuario

select * from Empresa	

insert into Empresa	values ('Khelf')

insert into Usuario (Email, Senha, IdEmpresa, IdPerfil) values ('empresa@email.com','123456',1,1)

select * from Estoque Where IdEmpresa = 1	

--Estoque
Select Camisa.Nome ,Tamanho.Tamanho ,Estoque.Cor , Estoque.Quantidade , Empresa.Nome  
From Estoque
FULL join Camisa 
on Estoque.Camisa = Camisa.IdCamisa
Inner join Tamanho
on Estoque.Tamanho = Tamanho.IdTamanho
FULL join Empresa
on Estoque.IdEmpresa = Empresa.IdEmpresa
--Estoque