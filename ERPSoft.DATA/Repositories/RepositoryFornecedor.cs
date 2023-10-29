using ERPSoft.DATA.Interfaces;
using ERPSoft.DATA.Models;

namespace ERPSoft.DATA.Repositories
{
    public class RepositoryFornecedor : IFornecedor
    {
        private readonly ERPSoftDbContext _context;

        public RepositoryFornecedor(ERPSoftDbContext context)
        {
            _context = context;
        }

        public Fornecedor Create(Fornecedor fornecedor)
        {
            _context.Fornecedor.Add(fornecedor);
            _context.SaveChanges();
            return fornecedor;
        }

        public IEnumerable<Fornecedor> GetAll()
        {
            return _context.Fornecedor.ToList();
        }

        public Fornecedor GetById(int id)
        {
            var entrada = _context.Fornecedor.FirstOrDefault(p => p.Id == id);
            if (entrada == null)
            {
                throw new Exception("Não encontrado");
            }
            return entrada;
        }

        public Fornecedor Update(Fornecedor fornecedor)
        {
            _context.Fornecedor.Update(fornecedor);
            _context.SaveChanges();
            return fornecedor;
        }

        public void Delete(Fornecedor fornecedor)
        {
            _context.Fornecedor.Remove(fornecedor);
            _context.SaveChanges();
        }

        public void DeleteById(int id)
        {
            var fornecedor = GetById(id);
            Delete(fornecedor);
        }
    }
}