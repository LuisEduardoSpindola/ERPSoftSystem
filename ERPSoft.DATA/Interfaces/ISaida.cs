using ERPSoft.DATA.Models;

namespace ERPSoft.DATA.Interfaces
{
    public interface IEntrada
    {
        IEnumerable<Entrada> GetAll();
        Entrada GetById(int id);
        Entrada Create(Entrada entrada);
        Entrada Update(Entrada entrada);
        void Delete(Entrada entrada);
        void DeleteById(int id);
    }
}
