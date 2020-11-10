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

SELECT* FROM Usuario

CREATE TABLE Administrador(
    Cod_Administrador int  PRIMARY KEY  IDENTITY(1,1) NOT NULL,
    Nome_Administrador varchar(50) NULL,
    UsuarioId int NULL references Usuario(UsuarioId)
)

SELECT * FROM Administrador

CREATE TABLE PROFESSOR(
COD_PROF INT IDENTITY(1,1),
NOME VARCHAR(100),
 UsuarioId int NULL references Usuario(UsuarioId)
 
CONSTRAINT PK_PROFESSOR PRIMARY KEY (COD_PROF)
)

SELECT * FROM PROFESSOR

CREATE TABLE MATERIA(
	COD_MATERIA INT IDENTITY(1,1),
	NOME VARCHAR (100)

	CONSTRAINT PK_MATERIA PRIMARY KEY(COD_MATERIA)
)

SELECT * FROM MATERIA

CREATE TABLE TURMA(
	COD_TURMA INT IDENTITY(1,1),
	SERIE VARCHAR(20),
	PERIODO_LET VARCHAR(10)
	CONSTRAINT PK_TURMA PRIMARY KEY (COD_TURMA)
)

SELECT * FROM TURMA

Create TABLE ALUNO  (
	COD_ALUNO INT IDENTITY(1,1),
	NOME VARCHAR(100),
	COD_TURMA INT NULL,
	 UsuarioId int NULL references Usuario(UsuarioId),
 
	CONSTRAINT PK_ALUNO PRIMARY KEY (COD_ALUNO),
	CONSTRAINT FK_TURMA FOREIGN KEY (COD_TURMA) REFERENCES TURMA (COD_TURMA)
)


SELECT * FROM ALUNO

 CREATE TABLE PROFMATERIATURMA(
	COD_PROF INT REFERENCES PROFESSOR(COD_PROF),
	COD_MATERIA INT REFERENCES MATERIA (COD_MATERIA),
	COD_TURMA INT REFERENCES TURMA (COD_TURMA),
	PERIODO_LETIVO INT NOT NULL
	CONSTRAINT PK_PROFMATTURMA PRIMARY KEY (COD_PROF,COD_MATERIA,COD_TURMA,PERIODO_LETIVO)
)

SELECT * FROM PROFMATERIATURMA

CREATE TABLE TURMA_PROFMT(
COD_PROF INT REFERENCES PROFESSOR(COD_PROF), 
COD_MATERIA INT REFERENCES MATERIA (COD_MATERIA), 
COD_TURMA INT REFERENCES TURMA (COD_TURMA),
PERIODO_LETIVO INT REFERENCES TURMA NOT NULL, 
CONSTRAINT PK_TURMA_PROFMT PRIMARY KEY (COD_PROF,COD_MATERIA,COD_TURMA,PERIODO_LETIVO)
)

SELECT * FROM TURMA_PROFMT

CREATE TABLE ATIVIDADE(
COD_ATIVIDADE INT IDENTITY(1,1)NOT NULL,
NOME_ATIVIDADE VARCHAR(100)NOT NULL,
DATA_ENTREGA DATE NOT NULL,
TIPO_ATIVIDADE TINYINT CHECK ( TIPO_ATIVIDADE IN (0,1,2)),
COD_MATERIA INT NOT NULL,
CONSTRAINT PK_ATIVIDADE PRIMARY KEY (COD_ATIVIDADE),
CONSTRAINT FK_MATERIA FOREIGN KEY (COD_MATERIA) REFERENCES MATERIA (COD_MATERIA)
)

SELECT * FROM ATIVIDADE

Create TABLE ALUNO_ATIVIDADE(
COD_ALUNO INT REFERENCES ALUNO(COD_ALUNO),
COD_ATIVIDADE INT REFERENCES ATIVIDADE(COD_ATIVIDADE),
NOTA float DEFAULT NULL,
CONSTRAINT PK_ALUNO_aTIVIDADE PRIMARY KEY (COD_ALUNO, COD_ATIVIDADE)
)

SELECT * FROM ALUNO_ATIVIDADE

CREATE TABLE ATIVIDADE_PROFMT(
COD_ATIVIDADE INT REFERENCES ATIVIDADE (COD_ATIVIDADE) NOT NULL,
COD_PROF INT REFERENCES PROFESSOR(COD_PROF), 
COD_MATERIA INT REFERENCES MATERIA (COD_MATERIA), 
COD_TURMA INT REFERENCES TURMA (COD_TURMA), 
PERIODO_LETIVO INT NOT NULL 
CONSTRAINT PK_ATIVIDADE_PROFMT PRIMARY KEY (COD_PROF,COD_MATERIA,COD_TURMA,COD_ATIVIDADE,PERIODO_LETIVO)
)

SELECT * FROM ATIVIDADE_PROFMT


SELECT * FROM Usuario



insert into  Usuario (Email,HashSenha,FlagSenhaTemp) values ('gabriel@gmail.com','81dc9bdb52d04dc20036dbd8313ed055','S')
insert into Usuario (Email,HashSenha,FlagSenhaTemp) values ('adm@gmail.com','81dc9bdb52d04dc20036dbd8313ed055','S')


Insert Administrador (Nome_Administrador,UsuarioId) values ('Admin', 2) 

Insert into  ATIVIDADE(NOME_ATIVIDADE,DATA_ENTREGA,TIPO_ATIVIDADE,COD_MATERIA) values ('EXERCICIO-2','06/11/2020',1,'1')

Insert into  ATIVIDADE_PROFMT (COD_ATIVIDADE,COD_PROF,COD_MATERIA,COD_TURMA,PERIODO_LETIVO) values ('5','1','1','1','20202')

SELECT * FROM ATIVIDADE_PROFMT

SELECT * FROM ATIVIDADE

Select * from ALUNO_ATIVIDADE 


Select * from PROFESSOR


Select * from TURMA


Select * from MATERIA


Select * from Usuario






































