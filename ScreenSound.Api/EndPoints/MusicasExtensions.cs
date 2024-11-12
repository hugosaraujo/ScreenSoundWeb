using Microsoft.AspNetCore.Mvc;
using ScreenSound.Banco;
using ScreenSound.Modelos;

namespace ScreenSound.Api.EndPoints;

public static class MusicasExtensions
{
    public static void AddEndPointMusicas(this WebApplication app)
    {
        app.MapGet("/Musicas", ([FromServices] Dal<Musica> dal) => dal.Listar());

        app.MapGet("/Musicas/{nome}", ([FromServices] Dal<Musica> dal, string nome) =>
        {
            return dal.RecuperaPor(m => m.Nome.ToUpper().Equals(nome.ToUpper()));
        });

        app.MapPost("/Musicas", ([FromServices] Dal<Musica> dal, [FromBody] Musica musica) =>
        {
            dal.Adicionar(musica);
            return Results.Ok();
        });

        app.MapPut("/Musicas", ([FromServices] Dal<Musica> dal, [FromBody] Musica musica) =>
        {
            var musicaParaAtualizar = dal.RecuperaPor(a => a.Id == musica.Id);
            if (musicaParaAtualizar is null) return Results.NotFound();

            musicaParaAtualizar.Nome = musica.Nome;
            musicaParaAtualizar.AnoLancamento = musica.AnoLancamento;

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
}
