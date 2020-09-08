USE MASTER
DROP DATABASE BoletimOnline2

CREATE DATABASE BoletimOnline2
USE BoletimOnline2

CREATE TABLE Usuario(
    UsuarioId int PRIMARY KEY IDENTITY(1,1) ,
    Email varchar(50) NULL UNIQUE,
    HashSenha varchar(256) NULL ,
    FlagSenhaTemp char(1) NOT NULL check(FlagSenhaTemp in ('S','N'))
)


CREATE TABLE Administrador(
    Cod_Administrador int  PRIMARY KEY  IDENTITY(1,1) NOT NULL,
    Nome_Administrador varchar(50) NULL,
    UsuarioId int NULL references Usuario(UsuarioId)
)

 


CREATE TABLE PROFESSOR(
COD_PROF INT IDENTITY(1,1),
NOME VARCHAR(100),
 UsuarioId int NULL references Usuario(UsuarioId)
 

CONSTRAINT PK_PROFESSOR PRIMARY KEY (COD_PROF)
)
SELECT * FROM Administrador

 

--------------------------
CREATE TABLE MATERIA(
	COD_MATERIA INT IDENTITY(1,1),
	NOME VARCHAR (100)

 

	CONSTRAINT PK_MATERIA PRIMARY KEY(COD_MATERIA)
)
SELECT * FROM MATERIA
--------------------------

 

CREATE TABLE TURMA(
	COD_TURMA INT IDENTITY(1,1),
	SERIE VARCHAR(20),
	PERIODO_LET VARCHAR(10)
	CONSTRAINT PK_TURMA PRIMARY KEY (COD_TURMA)
)
SELECT * FROM TURMA
-------------------------

 

CREATE TABLE ALUNO(
	COD_ALUNO INT IDENTITY(1,1),
	NOME VARCHAR(100),
	 UsuarioId int NULL references Usuario(UsuarioId)
 

	CONSTRAINT PK_ALUNO PRIMARY KEY (COD_ALUNO)
)
SELECT * FROM ALUNO
------------------------

 


CREATE TABLE TURMA_ALUNO(
	COD_ALUNO INT references Aluno (Cod_Aluno),
	COD_TURMA INT references Turma (Cod_Turma)
	CONSTRAINT PK_TURMA_ALUNO PRIMARY KEY (COD_ALUNO, COD_TURMA)
)
---------------------------

 

CREATE TABLE PROFMATERIATURMA(
	COD_PROF INT REFERENCES PROFESSOR(COD_PROF),
	COD_MATERIA INT REFERENCES MATERIA (COD_MATERIA),
	COD_TURMA INT REFERENCES TURMA (COD_TURMA),
	PERIODO_LETIVO INT NOT NULL
	CONSTRAINT PK_PROFMATTURMA PRIMARY KEY (COD_PROF,COD_MATERIA,COD_TURMA,PERIODO_LETIVO)
)
SELECT * FROM PROFMATERIATURMA

 


CREATE TABLE AVALIACAO(
	COD_AVALIACAO INT IDENTITY(1,1),
	NOME VARCHAR(70) NOT NULL,
	DESCRICAO VARCHAR(100),
	DATA DATE NOT NULL,
	PESO DECIMAL(5,2) NOT NULL,

	--- QUEM CRIOU ESSA AVALIACAO?---
	COD_PROF INT NOT NULL,
	COD_MATERIA INT NOT NULL,
	COD_TURMA INT NOT NULL,
	PERIODO_LETIVO INT

	CONSTRAINT PK_AVL PRIMARY KEY (COD_AVALIACAO),
	CONSTRAINT FK_PROFTURMA_ATV FOREIGN KEY (COD_PROF,COD_MATERIA,COD_TURMA,PERIODO_LETIVO)
	REFERENCES PROFMATERIATURMA (COD_PROF,COD_MATERIA,COD_TURMA,PERIODO_LETIVO)
)
SELECT * FROM AVALIACAO

 


CREATE TABLE NOTA(
	COD_NOTA INT NOT NULL,
	COD_ALUNO INT,
	COD_PROF INT REFERENCES PROFESSOR(COD_PROF),
	COD_MATERIA INT REFERENCES MATERIA (COD_MATERIA),
	COD_TURMA INT REFERENCES TURMA (COD_TURMA),
	VALOR DECIMAL (5,2) NOT NULL

	CONSTRAINT PK_NOTA PRIMARY KEY (COD_NOTA)
)
SELECT * FROM NOTA


 


CREATE TABLE ALUNO_NOTA(
	COD_ALUNO INT references Aluno (Cod_Aluno),
	COD_NOTA INT  references NOTA (Cod_Nota)

	CONSTRAINT PK_ALUNO_NOTA PRIMARY KEY (COD_ALUNO,COD_NOTA)
)
SELECT * FROM Usuario



insert into  Usuario (Email,HashSenha,FlagSenhaTemp) values ('gabriel@gmail.com','81dc9bdb52d04dc20036dbd8313ed055','S')
insert into Usuario (Email,HashSenha,FlagSenhaTemp) values ('adm@gmail.com','81dc9bdb52d04dc20036dbd8313ed055','S')


Insert Administrador (Nome_Administrador,UsuarioId) values ('Prof', 2) 




Select * from ALUNO


Select * from PROFESSOR


Select * from TURMA


Select * from MATERIA


Select * from Usuario






































