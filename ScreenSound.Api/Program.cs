using ScreenSound.Banco;
using ScreenSound.Modelos;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using ScreenSound.Api.EndPoints;
using ScreenSound.Shared.Data.Banco;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ScreenSoundContext>();
builder.Services.AddTransient<Dal<Artista>>();
builder.Services.AddTransient<Dal<Musica>>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options => options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

var app = builder.Build();

app.AddEndPointsArtistas();
app.AddEndPointMusicas();

app.UseSwagger();
app.UseSwaggerUI();

app.Run();