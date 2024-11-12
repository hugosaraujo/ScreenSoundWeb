using ScreenSound.Banco;
using ScreenSound.Modelos;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ScreenSoundContext>();
builder.Services.AddTransient<Dal<Artista>>();

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



app.Run();
