using ERPSoft.DATA.Interfaces;
using ERPSoft.DATA.Models;

namespace ERPSoft.DATA.Repositories
{
    public class RepositoryOrdemCompra : IOrdemCompra
    {
        private readonly ERPSoftDbContext _context;

        public RepositoryOrdemCompra(ERPSoftDbContext context)
        {
            _context = context;
        }

        public OrdemCompra Create(OrdemCompra ordemCompra)
        {
            _context.OrdemCompra.Add(ordemCompra);
            _context.SaveChanges();
            return ordemCompra;
        }

        public IEnumerable<OrdemCompra> GetAll()
        {
            return _context.OrdemCompra.ToList();
        }

        public OrdemCompra GetById(int id)
        {
            var ordemCompra = _context.OrdemCompra.FirstOrDefault(p => p.Id == id);
            if (ordemCompra == null)
            {
                throw new Exception("OrdemCompra não encontrado");
            }
            return ordemCompra;
        }

        public OrdemCompra Update(OrdemCompra ordemCompra)
        {
            _context.OrdemCompra.Update(ordemCompra);
            _context.SaveChanges();
            return ordemCompra;
        }

        public void Delete(OrdemCompra ordemCompra)
        {
            _context.OrdemCompra.Remove(ordemCompra);
            _context.SaveChanges();
        }

        public void DeleteById(int id)
        {
            var ordemCompra = GetById(id);
            Delete(ordemCompra);
        }
    }
}