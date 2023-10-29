using ERPSoft.DATA.Models;

namespace ERPSoft.DATA.Interfaces
{
    public interface IFornecedor
    {
        IEnumerable<Fornecedor> GetAll();
        Fornecedor GetById(int id);
        Fornecedor Create(Fornecedor fornecedor);
        Fornecedor Update(Fornecedor fornecedor);
        void Delete(Fornecedor fornecedor);
        void DeleteById(int id);
    }
}
