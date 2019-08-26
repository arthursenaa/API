create database T_Peoples
 
use T_Peoples
--DDL
Create table Funcionarios(
	IdFuncionario		int primary key identity
	,Nome				varchar(255) not null
	,Sobrenome			varchar(255) not null
)

--DML
insert into Funcionarios(Nome,Sobrenome) values ('Catarina','Strada'),('Tadeu','Vitelli')

--DQL
select * from Funcionarios

GO
create procedure TodosFunionarios @Nome varchar(255)
as
select * from Funcionarios
Where Nome = @Nome

Execute TodosFunionarios 'Catarina'

GO
create procedure FuncionariosPorId 
@Id int
as
select * from Funcionarios
Where IdFuncionario = @Id

Execute FuncionariosPorId 1