using ERPSoft.DATA.Models;

namespace ERPSoft.DATA.Interfaces
{
    public interface IServico
    {
        IEnumerable<Servicos> GetAll();
        Servicos GetById(int id);
        Servicos Create(Servicos servico);
        Servicos Update(Servicos servico);
        void Delete(Servicos servicos);
        void DeleteById(int id);
    }
}
