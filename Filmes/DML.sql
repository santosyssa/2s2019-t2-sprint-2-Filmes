use T_Filmes;

INSERT INTO Generos VALUES
	('Suspense')
	,('Ação')


INSERT INTO Filmes (Titulo, IdGenero) VALUES
	('Velozes e Furiosos 8', 2)
	,('A Morte Está de Parabéns', 1)

SELECT * FROM Generos order by IdGenero asc
SELECT * FROM Filmes 