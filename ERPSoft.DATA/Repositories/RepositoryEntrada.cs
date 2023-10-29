using ERPSoft.DATA.Interfaces;
using ERPSoft.DATA.Models;

namespace ERPSoft.DATA.Repositories
{
    public class RepositoryEntrada : IEntrada
    {
        private readonly ERPSoftDbContext _context;

        public RepositoryEntrada(ERPSoftDbContext context)
        {
            _context = context;
        }

        public Entrada Create(Entrada entrada)
        {
            _context.Entrada.Add(entrada);
            _context.SaveChanges();
            return entrada;
        }

        public IEnumerable<Entrada> GetAll()
        {
            return _context.Entrada.ToList();
        }

        public Entrada GetById(int id)
        {
            var entrada = _context.Entrada.FirstOrDefault(p => p.Id == id);
            if (entrada == null)
            {
                throw new Exception("Não encontrado");
            }
            return entrada;
        }

        public Entrada Update(Entrada entrada)
        {
            _context.Entrada.Update(entrada);
            _context.SaveChanges();
            return entrada;
        }

        public void Delete(Entrada entrada)
        {
            _context.Entrada.Remove(entrada);
            _context.SaveChanges();
        }

        public void DeleteById(int id)
        {
            var entrada = GetById(id);
            Delete(entrada);
        }
    }
}
