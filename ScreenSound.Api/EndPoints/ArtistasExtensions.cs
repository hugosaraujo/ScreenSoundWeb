using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ScreenSound.Api.Requests;
using ScreenSound.Api.Response;
using ScreenSound.Banco;
using ScreenSound.Modelos;

namespace ScreenSound.Api.EndPoints;

public static class ArtistasExtensions
{
    public static void AddEndPointsArtistas(this WebApplication app)
    {

        app.MapGet("/Artistas", ([FromServices] Dal<Artista> dal) =>
        {
            var listaDeArtistas = dal.Listar();
            var listaDeArtistasResponse = EntityListToResponseList(listaDeArtistas);
            return Results.Ok(listaDeArtistasResponse);
        });

        app.MapGet("/Artistas/{nome}", ([FromServices] Dal<Artista> dal, string nome) =>
        {
            var artista = dal.RecuperaPor(a => a.Nome.ToUpper().Equals(nome.ToUpper()));
            if (artista is null) return Results.NotFound(); 
            
            return Results.Ok(EntityToResponse(artista));
        });

        app.MapPost("/Artistas", ([FromServices] Dal<Artista> dal, [FromBody] ArtistaRequest artistaRequest) =>
        {
            Artista artista = new(artistaRequest.Nome, artistaRequest.Bio);

            dal.Adicionar(artista);
            return Results.Ok();
        });

        app.MapPut("/Artistas", ([FromServices] Dal<Artista> dal, [FromBody] ArtistaRequestEdit artistaRequestEdit) =>
        {
            var artistaParaAtualizar = dal.RecuperaPor(a => a.Id == artistaRequestEdit.Id);
            if (artistaParaAtualizar is null) return Results.NotFound();

            artistaParaAtualizar.Nome = artistaRequestEdit.Nome;
            artistaParaAtualizar.Bio = artistaRequestEdit.Bio;

            dal.Atualizar(artistaParaAtualizar);
            return Results.Ok();
        });

        app.MapDelete("/Artistas/{id}", ([FromServices] Dal<Artista> dal, int id) =>
        {
            var artista = dal.RecuperaPor(a => a.Id == id);
            if (artista is null) return Results.NotFound();

            dal.Deletar(artista);
            return Results.NoContent();
        });
    }

    private static ICollection<ArtistaResponse> EntityListToResponseList(IEnumerable<Artista> listaDeArtistas)
    {
        return listaDeArtistas.Select(a => EntityToResponse(a)).ToList();
    }

    private static ArtistaResponse EntityToResponse(Artista artista)
    {
        return new ArtistaResponse(artista.Id, artista.Nome, artista.Bio, artista.FotoPerfil);
    }

}
