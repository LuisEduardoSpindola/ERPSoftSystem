using ERPSoft.DATA.Models;

namespace ERPSoft.DATA.Interfaces
{
    public interface IOrdemServico
    {
        IEnumerable<OrdemServico> GetAll();
        OrdemServico GetById(int id);
        OrdemServico Create(OrdemServico ordemServico);
        OrdemServico Update(OrdemServico ordemServico);
        void Delete(OrdemServico ordemServico);
        void DeleteById(int id);
    }
}
