using ScreenSound.Banco;
using ScreenSound.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound.Menus;

internal class MenuMostrarMusicasPorAno : Menu
{
    public override void Executar(Dal<Artista> dal)
    {
        base.Executar(dal);
        ExibirTituloDaOpcao("Mostrar músicas por ano de lançamento");
        Console.Write("Digite o ano para saber as músicas lançadas naquele ano: ");
        int anoDePesquisaMusicas = int.Parse(Console.ReadLine()!);
        var musicaDal = new Dal<Musica>(new ScreenSoundContext());
        var listaDeLancamentos = musicaDal.ListarPor(m => m.AnoLancamento == anoDePesquisaMusicas);
        if (listaDeLancamentos.Any())
        {
            Console.WriteLine($"Lista de música lançadas em {anoDePesquisaMusicas}");
            foreach( var musica in listaDeLancamentos)
            {
                musica.ExibirFichaTecnica();
            }
            Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
        }
        else
        {
            Console.WriteLine("Não foi encontrado nenhuma música nesse ano de pesquisa.");
            Console.WriteLine("Digite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
