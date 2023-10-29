using ERPSoft.DATA.Interfaces;
using ERPSoft.DATA.Models;

namespace ERPSoft.DATA.Repositories
{
    public class RepositoryPedidoServico : IPedidoServico
    {
        private readonly ERPSoftDbContext _context;

        public RepositoryPedidoServico(ERPSoftDbContext context)
        {
            _context = context;
        }

        public PedidoServico Create(PedidoServico pedidoServico)
        {
            _context.PedidoServico.Add(pedidoServico);
            _context.SaveChanges();
            return pedidoServico;
        }

        public IEnumerable<PedidoServico> GetAll()
        {
            return _context.PedidoServico.ToList();
        }

        public PedidoServico GetById(int id)
        {
            var pedidoServico = _context.PedidoServico.FirstOrDefault(p => p.Id == id);
            if (pedidoServico == null)
            {
                throw new Exception("Não encontrado");
            }
            return pedidoServico;
        }

        public PedidoServico Update(PedidoServico pedidoServico)
        {
            _context.PedidoServico.Update(pedidoServico);
            _context.SaveChanges();
            return pedidoServico;
        }

        public void Delete(PedidoServico pedidoServico)
        {
            _context.PedidoServico.Remove(pedidoServico);
            _context.SaveChanges();
        }

        public void DeleteById(int id)
        {
            var pedidoServico = GetById(id);
            Delete(pedidoServico);
        }
    }
}
