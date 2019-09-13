using Senai.FilmesWebApi.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.FilmesWebApi.Repositorys
{
    public class FilmeRepository
    {
        private string StringConexao = "Data Source=.\\SqlExpress;Initial Catalog=T_Filmes;User Id=sa;Pwd=132;";

        public List<FilmeDomain> Listar()
        {
            List<FilmeDomain> filmes = new List<FilmeDomain>();

            string Query = "Select F.IdFilme, F.Titulo, G.IdGenero, G.Nome AS NomeGenero FROM Filmes F INNER JOIN Generos G ON F.IdGenero = G.IdGenero;";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                SqlDataReader sdr;

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    sdr = cmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        FilmeDomain filme = new FilmeDomain
                        {
                            IdFilme = Convert.ToInt32(sdr["IdFilme"]),

                            Titulo = sdr["Titulo"].ToString(),
                            Genero = new GeneroDomain
                            {
                                IdGenero = Convert.ToInt32(sdr["IdGenero"]),
                                Nome = sdr["NomeGenero"].ToString()
                            }
                        };

                        filmes.Add(filme);
                    }
                }
            }
            return filmes;
        }

        public FilmeDomain BuscarPorId(int id)
        {
           string Query = "Select F.IdFilme, F.Titulo, G.IdGenero, G.Nome AS NomeGenero FROM Filmes F INNER JOIN Generos G ON F.IdGenero = G.IdGenero where IdFilme = @IdFilme;";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                SqlDataReader sdr;


                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("@IdFilme", id);
                    sdr = cmd.ExecuteReader();

                    if (sdr.HasRows)
                    {
                        
                        while (sdr.Read())
                        {
                            FilmeDomain filme = new FilmeDomain
                            {
                                IdFilme = Convert.ToInt32(sdr["IdFilme"]),
                                Titulo = sdr["Titulo"].ToString(),
                                Genero = new GeneroDomain
                                {
                                    IdGenero = Convert.ToInt32(sdr["IdGenero"]),
                                    Nome = sdr["NomeGenero"].ToString()
                                }
                            };
                            return filme;
                        }
                        }
                    }

                    return null;
                }
            }

        public void Cadastrar(FilmeDomain filmeDomain)
        {
            string Query = "INSERT INTO Filmes (Titulo, IdGenero) VALUES (@Titulo, @IdGenero)";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@Titulo", filmeDomain.Titulo);
                cmd.Parameters.AddWithValue("@IdGenero", filmeDomain.GeneroId);
                cmd.ExecuteNonQuery();
            }
        }
       }

    }

