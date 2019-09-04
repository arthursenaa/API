create database T_AutoPecas

use T_AutoPecas

create table Usuario
(
	IdUsuario		int primary key identity,
	Email			varchar(255) not null unique,
	Senha			varchar(25) not null 
)

create table Fornecedor
(
	IdFornecedor	int primary key identity,
	Cnpj			int not null unique,
	RazaoSocial		varchar(255) not null,
	NomeFantasia	varchar(255) not null,
	Endereco		varchar(255) not null,
	IdUsuario		int foreign key references Usuario (IdUsuario)
)

create table Pecas 
(
	IdPeca		int primary key identity,
	Codigo		varchar(25) not null unique,
	Descricao	text not null,
	Peso		int not null,
	Preco		int not null,
	PrecoCusto	int not null,
	PrecoVenda	int not null,
	IdFornecedor int foreign key References Fornecedor (IdFornecedor) 
)

select * from Pecas
select * from Fornecedor
select * from Usuario