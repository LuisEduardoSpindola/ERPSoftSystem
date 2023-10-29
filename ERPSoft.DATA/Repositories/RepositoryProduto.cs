using ERPSoft.DATA.Interfaces;
using ERPSoft.DATA.Models;

namespace ERPSoft.DATA.Repositories
{
    public class RepositoryProduto : IProduto
    {
        private readonly ERPSoftDbContext _context;

        public RepositoryProduto(ERPSoftDbContext context)
        {
            _context = context;
        }

        public Produto Create(Produto produto)
        {
            _context.Produto.Add(produto);
            _context.SaveChanges();
            return produto;
        }

        public IEnumerable<Produto> GetAll()
        {
            return _context.Produto.ToList();
        }

        public Produto GetById(int id)
        {
            var product = _context.Produto.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                throw new Exception("Produto não encontrado");
            }
            return product;
        }

        public Produto Update(Produto produto)
        {
            _context.Produto.Update(produto);
            _context.SaveChanges();
            return produto;
        }

        public void Delete(Produto produto)
        {
            _context.Produto.Remove(produto);
            _context.SaveChanges();
        }

        public void DeleteById(int id)
        {
            var produto = GetById(id);
            Delete(produto);
        }
    }
}
