CREATE DATABASE T_Filmes;

USE T_Filmes;

CREATE TABLE Generos 
(
    IdGenero    INT PRIMARY KEY IDENTITY
    ,Nome       VARCHAR(200) NOT NULL UNIQUE
);

CREATE TABLE Filmes
(
    IdFilme     INT PRIMARY KEY IDENTITY
    ,Titulo     VARCHAR(200) UNIQUE
    ,IdGenero   INT FOREIGN KEY REFERENCES Generos (IdGenero)
);

INSERT INTO Generos VALUES
	('Suspense')
	,('Ação')


INSERT INTO Filmes (Titulo, IdGenero) VALUES
	('Velozes e Furiosos 8', 2)
	,('A Morte Está de Parabéns', 1)

Delete FROM Generos WHERE IdGenero = 3

SELECT * FROM Generos order by IdGenero asc
SELECT * FROM Filmes 

Select F.IdFilme, F.Titulo, G.IdGenero, G.Nome AS NomeGenero 
FROM Filmes F 
INNER JOIN Generos G 
ON F.IdGenero = G.IdGenero;