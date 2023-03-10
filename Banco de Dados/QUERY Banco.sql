CREATE DATABASE CatalogoVeiculo
USE CatalogoVeiculo

CREATE TABLE Usuario(
	UsuarioId INT IDENTITY(1,1) NOT NULL,
	Nome VARCHAR(30) NOT NULL,
	LoginUsuario VARCHAR(10) NOT NULL UNIQUE,
	Senha VARCHAR(30) NOT NULL,
	Administrador bit NOT NULL,
	StatusUsuario BIT DEFAULT(1) NOT NULL,
	CONSTRAINT PK_UsuarioId PRIMARY KEY(UsuarioId)
)

CREATE TABLE Marca(
	MarcaId INT IDENTITY(1,1) NOT NULL,
	NomeMarca VARCHAR(15) NOT NULL,
	StatusMarca BIT DEFAULT(1) NOT NULL,
	CONSTRAINT PK_MarcaId PRIMARY KEY(MarcaId)
)

CREATE TABLE Modelo(
	ModeloId INT IDENTITY(1,1) NOT NULL,
	NomeModelo VARCHAR(30) NOT NULL,
	MarcaId INT NOT NULL,
	StatusModelo BIT DEFAULT(1) NOT NULL
	CONSTRAINT PK_ModeloId PRIMARY KEY(ModeloId),
	CONSTRAINT FK_Modelo_Marca FOREIGN KEY (MarcaId) REFERENCES Marca (MarcaId),
)

CREATE TABLE Veiculo(
	VeiculoId INT IDENTITY(1,1) NOT NULL,
	Nome VARCHAR(30) NOT NULL,
	Foto VARCHAR(255) NOT NULL,
	Preco DECIMAL(13, 3) NOT NULL,
	DataCriacao Date NOT NULL,
	DataAtualizacao Date NOT NULL,
	ModeloId INT NOT NULL,
	UsuarioId INT NOT NULL,
	StatusVeiculo BIT DEFAULT(1) NOT NULL,
	CONSTRAINT PK_VeiculoId PRIMARY KEY(VeiculoId),
	CONSTRAINT FK_Veiculo_Modelo FOREIGN KEY (ModeloId) REFERENCES Modelo (ModeloId),
	CONSTRAINT FK_Veiculo_Usuario FOREIGN KEY (UsuarioId) REFERENCES Usuario (UsuarioId)
)
