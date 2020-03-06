--DDL SpMedGroup_Manha

CREATE DATABASE SpMedGroup_Manha

CREATE TABLE TipoUsuario (
	IdTipoUsuario	  INT PRIMARY KEY IDENTITY,
	TituloTipoUsuario VARCHAR (200) NOT NULL UNIQUE
); 

CREATE TABLE TipoMedico (
	IdTipoMedico  INT PRIMARY KEY IDENTITY,
	Especialidade VARCHAR (200) NOT NULL UNIQUE
);                  

CREATE TABLE Clinica (
	IdClinica	 INT PRIMARY KEY IDENTITY,
	RazaoSocial	 VARCHAR (200) NOT NULL,
	NomeFantasia VARCHAR (200) NOT NULL,
	Endereco	 VARCHAR (200) NOT NULL,
	Telefone	 VARCHAR (200) NOT NULL
);  

CREATE TABLE Situacao (
	IdSituacao    INT PRIMARY KEY IDENTITY,
	Tipo_Situacao VARCHAR (200) NOT NULL

);

CREATE TABLE Usuario (
	IdUsuario		INT PRIMARY KEY IDENTITY,
	Nome			VARCHAR (200) NOT NULL,
	Email			VARCHAR (200) NOT NULL UNIQUE,
	Senha			VARCHAR (200) NOT NULL,
	Data_Nascimento DATETIME2 NOT NULL,
	Telefone		VARCHAR (200) NOT NULL,
	RG				CHAR (10) NOT NULL,
	CPF				CHAR (11) NOT NULL,
	Endereco		VARCHAR (200) NOT NULL,
	IdTipoUsuario	INT FOREIGN KEY REFERENCES TipoUsuario (IdTipoUsuario)
);

CREATE TABLE Paciente (
	IdPaciente INT PRIMARY KEY IDENTITY,
	Queixa	   VARCHAR (200) NOT NULL,
	IdUsuario  INT FOREIGN KEY  REFERENCES Usuario (IdUsuario)
);

CREATE TABLE Medico (
	IdMedico	 INT PRIMARY KEY IDENTITY,
	CRM			 VARCHAR (15),
	IdTipoMedico INT FOREIGN KEY REFERENCES TipoMedico(IdTipoMEdico),
	IdClinica	 INT FOREIGN KEY REFERENCES Clinica (IdClinica),
	IdUsuario	 INT FOREIGN KEY REFERENCES Usuario (IdUsuario)

);

CREATE TABLE Consulta (
	IdConsulta INT PRIMARY KEY IDENTITY,
	Data_Consulta DATETIME2,
	IdMedico INT FOREIGN KEY REFERENCES Medico (IdMedico),
	IdPaciente INT FOREIGN KEY REFERENCES Paciente (IdPaciente),
	IdSituacao INT FOREIGN KEY REFERENCES Situacao (IdSituacao)

);