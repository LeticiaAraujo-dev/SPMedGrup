/*CREATE DATABASE SPMedGroup;
GO*/

USE SPMedGroup;
GO

CREATE TABLE tiposUsuarios
(
	idTipoUsuario			INT PRIMARY KEY IDENTITY
	,NomeTipoUsuario		VARCHAR(200) UNIQUE NOT NULL
);
GO

CREATE TABLE usuarios
(
	idUsuario			INT PRIMARY KEY IDENTITY
	,idTipoUsuario		INT FOREIGN KEY REFERENCES tiposUsuarios(idTipoUsuario)
	,email				VARCHAR(200) UNIQUE NOT NULL
	,senha				VARCHAR(200) NOT NULL
);
GO

CREATE TABLE paciente
(
	idUsuario			INT FOREIGN KEY REFERENCES usuarios(idUsuario)
	,idPaciente			INT PRIMARY KEY IDENTITY
	,DataNascimento		DATE NOT NULL
	,NomePaciente		VARCHAR(200) NOT NULL
	,Telefone			INT
	,CPF				INT NOT NULL
	,Rua				VARCHAR(200) 
	,Numero				INT
	,CEP				INT
	,RG					INT NOT NULL
);
GO

CREATE TABLE especialidade
(
	idEspecialidade		INT PRIMARY KEY IDENTITY
	,NomeEspecialidade	VARCHAR(200) UNIQUE NOT NULL
);
GO

CREATE TABLE clinica
(
	idClinica			INT PRIMARY KEY IDENTITY
	,cnpj				CHAR(14) UNIQUE NOT NULL
	,nomeFantasia		VARCHAR(200) NOT NULL
	,Rua				VARCHAR(200) 
	,Numero				INT
	,RazaoSocial		VARCHAR (200) UNIQUE NOT NULL
);
GO

CREATE TABLE medico
(
	idUsuario			INT FOREIGN KEY REFERENCES usuarios(idUsuario)
	,idClinica			INT FOREIGN KEY REFERENCES clinica(idClinica)
	,idEspecialidade	INT FOREIGN KEY REFERENCES especialidade(idEspecialidade)
	,idMedico			INT PRIMARY KEY IDENTITY 
	,NomeMedico			VARCHAR(200) NOT NULL
	,CRM				CHAR(200) UNIQUE NOT NULL
);
GO

CREATE TABLE situacao
(
	idSituacao			INT PRIMARY KEY IDENTITY 
	,TipoSituacao		VARCHAR(200) NOT NULL UNIQUE
);
GO

CREATE TABLE consulta
(
	idSituacao			INT FOREIGN KEY REFERENCES situacao(idSituacao)
	,idMedico			INT FOREIGN KEY REFERENCES medico(idMedico)
	,idPaciente			INT FOREIGN KEY REFERENCES paciente(idPaciente)
	,idConsulta			INT PRIMARY KEY IDENTITY
	,DataRealizacao		DATETIME 
);