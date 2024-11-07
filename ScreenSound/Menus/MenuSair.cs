using ScreenSound.Banco;
using ScreenSound.Modelos;

namespace ScreenSound.Menus;

internal class MenuSair : Menu
{
    public override void Executar(Dal<Artista> dal)
    {
        Console.WriteLine("Tchau tchau :)");
    }
}
