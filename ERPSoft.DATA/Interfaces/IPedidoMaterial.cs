using ERPSoft.DATA.Models;

namespace ERPSoft.DATA.Interfaces
{
    public interface IPedidoMaterial
    {
        IEnumerable<PedidoMaterial> GetAll();
        PedidoMaterial GetById(int id);
        PedidoMaterial Create(PedidoMaterial pedidoMaterial);
        PedidoMaterial Update(PedidoMaterial pedidoMaterial);
        void Delete(PedidoMaterial pedidoMaterial);
        void DeleteById(int id);
    }
}
