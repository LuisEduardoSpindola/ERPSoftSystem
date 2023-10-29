using ERPSoft.DATA.Models;

namespace ERPSoft.DATA.Interfaces
{
    public interface IPedidoServico
    {
        IEnumerable<PedidoServico> GetAll();
        PedidoServico GetById(int id);
        PedidoServico Create(PedidoServico pedodoServico);
        PedidoServico Update(PedidoServico pedodoServico);
        void Delete(PedidoServico pedodoServico);
        void DeleteById(int id);
    }
}
