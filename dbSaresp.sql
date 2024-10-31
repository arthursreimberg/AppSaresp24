create database Saresp_2024;
use Saresp_2024;


create table ProfessorAplicador(
IdProfessor int auto_increment primary key,
Nome varchar(50),
CPF varchar(11),
RG varchar(9),
Telefone bigint,
DataNascimento dateTime
);
select * from professorAplicador;

create table Aluno(
RA int primary key,
Nome varchar(50),
Email varchar(50),
Telefone bigint,
Serie char(1), 
Turma varchar(10),
DataNascimento DateTime
);

select * from aluno;

update aluno set nome = "Alex" where RA = 123451;