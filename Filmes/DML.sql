use T_Filmes;

INSERT INTO Generos VALUES
	('Suspense')
	,('A��o')


INSERT INTO Filmes (Titulo, IdGenero) VALUES
	('Velozes e Furiosos 8', 2)
	,('A Morte Est� de Parab�ns', 1)

SELECT * FROM Generos order by IdGenero asc
SELECT * FROM Filmes 