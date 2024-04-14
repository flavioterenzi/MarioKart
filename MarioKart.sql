

USE MarioKart


DROP TABLE Personaggi

DROP TABLE Squadra

CREATE TABLE Squadra(
squadraID INT PRIMARY KEY IDENTITY(1,1),
codice varchar(50) unique DEFAULT NEWID(),
nome VARCHAR(250),
nomeUtente VARCHAR (250),
crediti INT,

);

CREATE TABLE Personaggi(
personaggiId INT PRIMARY KEY IDENTITY(1,1),
codice varchar(50) DEFAULT NEWID(),
nome VARCHAR(250),
categoria VARCHAR(50),
costo INT,
img TEXT,
squadraRif INT,
FOREIGN KEY (squadraRif) REFERENCES Squadra(squadraID) ON DELETE SET NULL
);

INSERT INTO Squadra(nome,categoria,costo,img,squadraRif) VALUE
(""