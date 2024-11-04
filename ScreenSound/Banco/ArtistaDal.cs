using Microsoft.Data.SqlClient;
using ScreenSound.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound.Banco;

internal class ArtistaDal
{
    public IEnumerable<Artista> Listar()
    {
        List<Artista> lista = new();

        using var conn = new Connection().ObterConexao() ;
        conn.Open();

        string sql = "SELECT * FROM Artistas";
        SqlCommand cmd = new SqlCommand(sql, conn);
        using SqlDataReader dataReader = cmd.ExecuteReader();

        while (dataReader.Read())
        {
            int idArtista = Convert.ToInt32(dataReader["ID"]);
            string nomeArtista = Convert.ToString(dataReader["Nome"]);
            string bioArtista = Convert.ToString(dataReader["Bio"]);
            Artista artista = new(nomeArtista, bioArtista) { Id = idArtista };
            lista.Add(artista);
        }
        return lista;
    }
    
    public void Adicionar(Artista artista)
    {
        var conn = new Connection().ObterConexao();
        conn.Open();

        string sql = "INSERT INTO Artistas (Nome, FotoPerfil, Bio) VALUES (@nome, @perfilPadrao, @bio)";
        SqlCommand cmd = new SqlCommand(sql, conn);

        cmd.Parameters.AddWithValue("@nome", artista.Nome);
        cmd.Parameters.AddWithValue("@perfilPadrao", artista.FotoPerfil);
        cmd.Parameters.AddWithValue("@bio", artista.Bio);

        int retorno = cmd.ExecuteNonQuery();
        Console.WriteLine($"Linhas afetadas: {retorno}");
    }
}
