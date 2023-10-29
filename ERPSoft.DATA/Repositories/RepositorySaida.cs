using ERPSoft.DATA.Interfaces;
using ERPSoft.DATA.Models;

namespace ERPSoft.DATA.Repositories
{
    public class RepositorySaida : ISaida
    {
        private readonly ERPSoftDbContext _context;

        public RepositorySaida(ERPSoftDbContext context)
        {
            _context = context;
        }

        public Saida Create(Saida saida)
        {
            _context.Saida.Add(saida);
            _context.SaveChanges();
            return saida;
        }

        public IEnumerable<Saida> GetAll()
        {
            return _context.Saida.ToList();
        }

        public Saida GetById(int id)
        {
            var saida = _context.Saida.FirstOrDefault(p => p.Id == id);
            if (saida == null)
            {
                throw new Exception("Não encontrado");
            }
            return saida;
        }

        public Saida Update(Saida saida)
        {
            _context.Saida.Update(saida);
            _context.SaveChanges();
            return saida;
        }

        public void Delete(Saida saida)
        {
            _context.Saida.Remove(saida);
            _context.SaveChanges();
        }

        public void DeleteById(int id)
        {
            var saida = GetById(id);
            Delete(saida);
        }
    }
}
