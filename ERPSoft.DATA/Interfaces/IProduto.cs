using ERPSoft.DATA.Models;

namespace ERPSoft.DATA.Interfaces
{
    public interface IProduto
    {
        IEnumerable<Produto> GetAll();
        Produto GetById(int id);
        Produto Create(Produto produto);
        Produto Update(Produto produto);
        void Delete(Produto produto);
        void DeleteById(int id);
    }
}
