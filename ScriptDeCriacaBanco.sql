IF db_id('DiscoMania') IS NULL 
    CREATE DATABASE DiscoMania

GO

CREATE TABLE DiscoMania.dbo.Disco (
    Id  INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    TituloAlbum VARCHAR(MAX),
    NomeArtista VARCHAR(MAX),
	Genero INT,
	Valor DECIMAL(10,2)
);

CREATE TABLE DiscoMania.dbo.Venda (
    Id  INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    DataVenda DATETIME,
    ValorTotalVenda DECIMAL(10,2),
	ValorTotalCashBack DECIMAL(10,2),
);
CREATE TABLE DiscoMania.dbo.DiscoVenda (
    Id  INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    DiscoId INT FOREIGN KEY REFERENCES DiscoMania.dbo.Disco(Id),
	VendaId INT FOREIGN KEY REFERENCES DiscoMania.dbo.Venda(Id),
    Qtde INT,
	Valor DECIMAL(10,2),
	ValorCashBack DECIMAL(10,2),
);

CREATE TABLE DiscoMania.dbo.CashBack (
    Id  INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    Genero INT UNIQUE,
	Domingo INT,
	Segunda INT,
	Terca INT,
	Quarta INT,
	Quinta INT,
	Sexta INT,
	Sabado INT,
	
);

INSERT INTO DiscoMania.dbo.CashBack (Genero, Domingo, Segunda,Terca,Quarta, Quinta, Sexta, Sabado)
VALUES (0, 25,7,6,2,10,15,20);
INSERT INTO DiscoMania.dbo.CashBack (Genero, Domingo, Segunda,Terca,Quarta, Quinta, Sexta, Sabado)
VALUES (1, 30,5,10,15,20,25,30);
INSERT INTO DiscoMania.dbo.CashBack (Genero, Domingo, Segunda,Terca,Quarta, Quinta, Sexta, Sabado)
VALUES (2, 40,10,15,15,15,20,40);
INSERT INTO DiscoMania.dbo.CashBack (Genero, Domingo, Segunda,Terca,Quarta, Quinta, Sexta, Sabado)
VALUES (3, 35,3,5,8,13,18,25);