namespace ScreenSound.Api.Requests;

public record MusicaRequestEdit(
    int Id, 
    string Nome, 
    int ArtistaId, 
    int? AnoLancamento) : MusicaRequest (Nome, ArtistaId, AnoLancamento);

