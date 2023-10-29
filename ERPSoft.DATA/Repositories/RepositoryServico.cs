using ERPSoft.DATA.Interfaces;
using ERPSoft.DATA.Models;
using Microsoft.EntityFrameworkCore;

namespace ERPSoft.DATA.Repositories
{
    public class RepositoryServico : IServico
    {
        private readonly ERPSoftDbContext _context;

        public RepositoryServico(ERPSoftDbContext context)
        {
            _context = context;
        }

        public Servicos Create(Servicos servico)
        {
            _context.Servicos.Add(servico);
            _context.SaveChanges();
            return servico;
        }

        public IEnumerable<Servicos> GetAll()
        {
            return _context.Servicos.ToList();
        }

        public Servicos GetById(int id)
        {
            var product = _context.Servicos.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                throw new Exception("Produto não encontrado");
            }
            return product;
        }

        public Servicos Update(Servicos servico)
        {
            _context.Servicos.Update(servico);
            _context.SaveChanges();
            return servico;
        }

        public void Delete(Servicos servicos)
        {
            _context.Servicos.Remove(servicos); 
            _context.SaveChanges();
        }

        public void DeleteById(int id)
        {
            var servico = GetById(id);
            Delete(servico);
        }
    }
}
