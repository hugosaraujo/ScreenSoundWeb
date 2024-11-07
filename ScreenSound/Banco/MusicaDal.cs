using ScreenSound.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound.Banco;

internal class MusicaDal
{
    private ScreenSoundContext _context;

    public MusicaDal(ScreenSoundContext context)
    {
        _context = context;
    }

    public IEnumerable<Musica> Listar()
    {
        return _context.Musicas.ToList();
    }

    public Musica? RecuperaPeloNome(string nome)
    {
        return _context.Musicas.FirstOrDefault(m => m.Nome.Equals(nome));
    }

    public void Adicionar(Musica musica)
    {
        _context.Musicas.Add(musica);
        _context.SaveChanges();
    }

    public void Atualizar(Musica musica)
    {
        _context.Musicas.Update(musica);
        _context.SaveChanges();
    }

    public void Deletar(Musica musica)
    {
        _context.Musicas.Remove(musica);
        _context.SaveChanges();
    }
}
