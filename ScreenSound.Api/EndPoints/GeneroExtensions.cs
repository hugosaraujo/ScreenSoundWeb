using Microsoft.AspNetCore.Mvc;
using ScreenSound.Api.Requests;
using ScreenSound.Api.Response;
using ScreenSound.Banco;
using ScreenSound.Modelos;
using ScreenSound.Shared.Modelos.Modelos;

namespace ScreenSound.Api.EndPoints;

public static class GeneroExtensions
{
    public static void AddEndPointsGeneros(this WebApplication app)
    {

        app.MapGet("/Generos", ([FromServices] Dal<Genero> dal) =>
        {
            var listaDeGeneros = dal.Listar();
            var listaDeGenerosResponse = EntityListToResponseList(listaDeGeneros);
            return Results.Ok(listaDeGenerosResponse);
        });

        app.MapGet("/Generos/{nome}", ([FromServices] Dal<Genero> dal, string nome) =>
        {
            var genero = dal.RecuperaPor(g => g.Nome.ToUpper().Equals(nome.ToUpper()));
            if (genero is null) return Results.NotFound();

            return Results.Ok(EntityToResponse(genero));
        });

        app.MapPost("/Generos", ([FromServices] Dal<Genero> dal, [FromBody] GeneroRequest generoRequest) =>
        {
            dal.Adicionar(RequestToEntity(generoRequest));
        });

        app.MapPut("/Generos", ([FromServices] Dal<Genero> dal, [FromBody] GeneroRequestEdit generoRequestEdit) =>
        {
            var generoParaAtualizar = dal.RecuperaPor(a => a.Id == generoRequestEdit.Id);
            if (generoParaAtualizar is null) return Results.NotFound();

            generoParaAtualizar.Nome = generoRequestEdit.Nome;
            generoParaAtualizar.Descricao = generoRequestEdit.Descricao;

            dal.Atualizar(generoParaAtualizar);
            return Results.Ok();
        });

        app.MapDelete("/Genero/{id}", ([FromServices] Dal<Genero> dal, int id) =>
        {
            var genero = dal.RecuperaPor(a => a.Id == id);
            if (genero is null) return Results.NotFound();

            dal.Deletar(genero);
            return Results.NoContent();
        });
    }

    private static Genero RequestToEntity(GeneroRequest generoRequest)
    {
        return new Genero() { Nome = generoRequest.Nome, Descricao = generoRequest.Descricao };
    }
    private static ICollection<GeneroResponse> EntityListToResponseList(IEnumerable<Genero> listaDeGeneros)
    {
        return listaDeGeneros.Select(g => EntityToResponse(g)).ToList();
    }

    private static GeneroResponse EntityToResponse(Genero genero)
    {
        return new GeneroResponse(genero.Id, genero.Nome!, genero.Descricao!);
    }
}
