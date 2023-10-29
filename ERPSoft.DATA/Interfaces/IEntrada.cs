using ERPSoft.DATA.Models;

namespace ERPSoft.DATA.Interfaces
{
    public interface ISaida
    {
        IEnumerable<Saida> GetAll();
        Saida GetById(int id);
        Saida Create(Saida saida);
        Saida Update(Saida saida);
        void Delete(Saida saida);
        void DeleteById(int id);
    }
}
