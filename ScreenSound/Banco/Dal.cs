using ScreenSound.Modelos;

namespace ScreenSound.Banco;

internal class Dal<T> where T : class
{
    protected readonly ScreenSoundContext _context;

    public Dal(ScreenSoundContext context)
    {
        _context = context;
    }
    public IEnumerable<T> Listar()
    {
        return _context.Set<T>().ToList();
    }
    public void Adicionar(T objeto)
    {
        _context.Set<T>().Add(objeto);
        _context.SaveChanges();
    }
    public void Atualizar(T objeto)
    {
        _context.Set<T>().Update(objeto);
        _context.SaveChanges();
    }
    public void Deletar(T objeto)
    {
        _context.Set<T>().Remove(objeto);
        _context.SaveChanges();
    }

    public T? RecuperaPor(Func<T, bool> condicao)
    {
        return _context.Set<T>().FirstOrDefault(condicao);
    }

    public IEnumerable<T> ListarPor(Func<T, bool> condicao)
    {
        return _context.Set<T>().Where(condicao).ToList();

    }
}