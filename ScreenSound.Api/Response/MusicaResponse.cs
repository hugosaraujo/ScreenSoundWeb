using ScreenSound.Shared.Modelos.Modelos;

namespace ScreenSound.Api.Response;

public record MusicaResponse(
    int Id, 
    string Nome, 
    int ArtistaId, 
    string NomeArtista);