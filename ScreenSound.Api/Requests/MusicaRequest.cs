﻿namespace ScreenSound.Api.Requests;

public record MusicaRequest(
    string Nome,
    int ArtistaId,
    int? AnoLancamento,
    ICollection<GeneroRequest> Generos = null); 