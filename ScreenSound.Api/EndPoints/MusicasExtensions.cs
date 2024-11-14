using System.Formats.Tar;
using Microsoft.AspNetCore.Mvc;
using ScreenSound.Api.Requests;
using ScreenSound.Api.Response;
using ScreenSound.Banco;
using ScreenSound.Modelos;
using ScreenSound.Shared.Modelos.Modelos;

namespace ScreenSound.Api.EndPoints;

public static class MusicasExtensions
{
    public static void AddEndPointMusicas(this WebApplication app)
    {
        app.MapGet("/Musicas", ([FromServices] Dal<Musica> dal) =>
        {
            var listaDeMusicas = dal.Listar();
            var listaDeMusicasResponse = EntityListToResponseList(listaDeMusicas);
            return Results.Ok(listaDeMusicasResponse);
        });

        app.MapGet("/Musicas/{nome}", ([FromServices] Dal<Musica> dal, string nome) =>
        {
            var musica = dal.RecuperaPor(m => m.Nome.ToUpper().Equals(nome.ToUpper()));
            if (musica is null ) return Results.NotFound();
            
            return Results.Ok(EntityToResponse(musica));
        });

        app.MapPost("/Musicas", ([FromServices] Dal<Musica> dal, [FromBody] MusicaRequest musicaRequest) =>
        {
            Musica musica = new Musica(musicaRequest.Nome)
            {
                ArtistaId = musicaRequest.ArtistaId,
                AnoLancamento = musicaRequest.AnoLancamento,
                Generos = musicaRequest.Generos is not null? GeneroRequestConverter(musicaRequest.Generos) : new List<Genero>(),
            };
            dal.Adicionar(musica);
            return Results.Ok();
        });

        app.MapPut("/Musicas", ([FromServices] Dal<Musica> dal, [FromBody] MusicaRequestEdit musicaRequestEdit) =>
        {
            var musicaParaAtualizar = dal.RecuperaPor(m => m.Id == musicaRequestEdit.Id);
            if (musicaParaAtualizar is null) return Results.NotFound();

            musicaParaAtualizar.Nome = musicaRequestEdit.Nome;
            musicaParaAtualizar.AnoLancamento = musicaRequestEdit.AnoLancamento;      

            dal.Atualizar(musicaParaAtualizar);
            return Results.Ok();
        });

        app.MapDelete("/Musicas/{id}", ([FromServices] Dal<Musica> dal, int id) =>
        {
            var musica = dal.RecuperaPor(a => a.Id == id);
            if (musica is null) return Results.NotFound();

            dal.Deletar(musica);
            return Results.NoContent();
        });
    }

    private static ICollection<Genero> GeneroRequestConverter(ICollection<GeneroRequest> generos)
    {
        return generos.Select(a => RequestToEntity(a)).ToList();
    }

    private static Genero RequestToEntity(GeneroRequest genero)
    {
        return new Genero() {Nome = genero.Nome, Descricao = genero.Descricao};
    }

    private static ICollection<MusicaResponse> EntityListToResponseList(IEnumerable<Musica> musicaList)
    {
        return musicaList.Select(a => EntityToResponse(a)).ToList();
    }
    private static MusicaResponse EntityToResponse(Musica musica)
    {
        int artistaId = musica.Artista?.Id ?? 0;
        string nomeArtista = musica.Artista?.Nome ?? string.Empty;
        
        return new MusicaResponse(musica.Id, musica.Nome, artistaId, nomeArtista);
    }
}
