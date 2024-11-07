using Microsoft.Data.SqlClient;
using ScreenSound.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound.Banco;

internal class ArtistaDal : Dal<Artista>
{
    private ScreenSoundContext _context;

    public ArtistaDal(ScreenSoundContext context)
    {
        _context = context;
    }

    public override IEnumerable<Artista> Listar() 
    {
        return _context.Artistas.ToList();
    }

    public Artista? RecuperaPeloNome(string nome)
    {
        return _context.Artistas.FirstOrDefault(a =>  a.Nome.Equals(nome));
    }

    public override void Adicionar(Artista artista)
    {
        _context.Artistas.Add(artista);
        _context.SaveChanges();
    }

    public override void Atualizar(Artista artista)
    {
        _context.Artistas.Update(artista);
        _context.SaveChanges();
    }

    public override void Deletar(Artista artista)
    {
        _context.Artistas.Remove(artista);
        _context.SaveChanges();
    }
}
