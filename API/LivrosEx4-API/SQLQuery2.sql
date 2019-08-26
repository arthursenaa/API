CREATE DATABASE T_BookStore;

USE T_BookStore;

CREATE TABLE Generos
(
    IdGenero    INT PRIMARY KEY IDENTITY
    ,Nome  VARCHAR(200) NOT NULL UNIQUE
);

drop table Generos;

CREATE TABLE Autores 
(
    IdAutor             INT PRIMARY KEY IDENTITY
    ,Nome               VARCHAR(200)
    ,Email              VARCHAR(255) UNIQUE
    ,Ativo              BIT DEFAULT(1) -- BIT/CHAR
    ,DataNascimento     DATE
);

CREATE TABLE Livros
(
    IdLivro             INT PRIMARY KEY IDENTITY
    ,Titulo             VARCHAR(255) NOT NULL UNIQUE
    ,IdAutor            INT FOREIGN KEY REFERENCES Autores (IdAutor)
    ,IdGenero           INT FOREIGN KEY REFERENCES Generos (IdGenero)
);

select Livros.Titulo , Autores.Nome As Autor , Generos.Nome as Genero
from Livros
inner join Autores
on Livros.IdAutor = Autores.IdAutor
inner join Generos
on Livros.IdGenero = Generos.IdGenero

