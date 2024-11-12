using ScreenSound.Banco;
using ScreenSound.Modelos;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ScreenSoundContext>();
builder.Services.AddTransient<Dal<Artista>>();
builder.Services.AddTransient<Dal<Musica>>();

builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options => options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

var app = builder.Build();

app.MapGet("/Artistas", ([FromServices] Dal<Artista> dal) => dal.Listar());

app.MapGet("/Artistas/{nome}", ([FromServices] Dal<Artista> dal ,string nome) =>
{
    return dal.RecuperaPor(a => a.Nome.ToUpper().Equals(nome.ToUpper()));
});

app.MapPost("/Artistas", ([FromServices] Dal<Artista> dal,[FromBody]Artista artista) =>
{
    dal.Adicionar(artista);
    return Results.Ok();
});

app.MapPut("/Artistas", ([FromServices] Dal<Artista> dal, [FromBody] Artista artista) =>
{
    var artistaParaAtualizar = dal.RecuperaPor(a => a.Id == artista.Id);
    if (artistaParaAtualizar is null) return Results.NotFound();
    
    artistaParaAtualizar.Nome = artista.Nome;
    artistaParaAtualizar.Bio = artista.Bio;
    
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

app.Run();
