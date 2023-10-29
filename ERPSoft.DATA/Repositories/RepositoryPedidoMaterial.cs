using ERPSoft.DATA.Interfaces;
using ERPSoft.DATA.Models;

namespace ERPSoft.DATA.Repositories
{
    public class RepositoryPedidoMaterial : IPedidoMaterial
    {
        private readonly ERPSoftDbContext _context;

        public RepositoryPedidoMaterial(ERPSoftDbContext context)
        {
            _context = context;
        }

        public PedidoMaterial Create(PedidoMaterial pedidoMaterial)
        {
            _context.PedidoMaterial.Add(pedidoMaterial);
            _context.SaveChanges();
            return pedidoMaterial;
        }

        public IEnumerable<PedidoMaterial> GetAll()
        {
            return _context.PedidoMaterial.ToList();
        }

        public PedidoMaterial GetById(int id)
        {
            var pedidoMaterial = _context.PedidoMaterial.FirstOrDefault(p => p.Id == id);
            if (pedidoMaterial == null)
            {
                throw new Exception("Não encontrado");
            }
            return pedidoMaterial;
        }

        public PedidoMaterial Update(PedidoMaterial pedidoMaterial)
        {
            _context.PedidoMaterial.Update(pedidoMaterial);
            _context.SaveChanges();
            return pedidoMaterial;
        }

        public void Delete(PedidoMaterial pedidoMaterial)
        {
            _context.PedidoMaterial.Remove(pedidoMaterial);
            _context.SaveChanges();
        }

        public void DeleteById(int id)
        {
            var pedidoMaterial = GetById(id);
            Delete(pedidoMaterial);
        }
    }
}
