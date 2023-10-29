using ERPSoft.DATA.Interfaces;
using ERPSoft.DATA.Models;

namespace ERPSoft.DATA.Repositories
{
    public class RepositoryOrdemServico : IOrdemServico
    {
        private readonly ERPSoftDbContext _context;

        public RepositoryOrdemServico(ERPSoftDbContext context)
        {
            _context = context;
        }

        public OrdemServico Create(OrdemServico ordemServico)
        {
            _context.OrdemServico.Add(ordemServico);
            _context.SaveChanges();
            return ordemServico;
        }

        public IEnumerable<OrdemServico> GetAll()
        {
            return _context.OrdemServico.ToList();
        }

        public OrdemServico GetById(int id)
        {
            var ordemServico = _context.OrdemServico.FirstOrDefault(p => p.Id == id);
            if (ordemServico == null)
            {
                throw new Exception("OrdemServico não encontrado");
            }
            return ordemServico;
        }

        public OrdemServico Update(OrdemServico ordemServico)
        {
            _context.OrdemServico.Update(ordemServico);
            _context.SaveChanges();
            return ordemServico;
        }

        public void Delete(OrdemServico ordemServico)
        {
            _context.OrdemServico.Remove(ordemServico);
            _context.SaveChanges();
        }

        public void DeleteById(int id)
        {
            var ordemServico = GetById(id);
            Delete(ordemServico);
        }
    }
}