using ERPSoft.DATA.Models;

namespace ERPSoft.DATA.Interfaces
{
    public interface IOrdemCompra
    {
        IEnumerable<OrdemCompra> GetAll();
        OrdemCompra GetById(int id);
        OrdemCompra Create(OrdemCompra ordemCompra);
        OrdemCompra Update(OrdemCompra ordemCompra);
        void Delete(OrdemCompra ordemCompra);
        void DeleteById(int id);
    }
}
