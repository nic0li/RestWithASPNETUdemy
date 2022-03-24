using RestWithASPNETUdemy.Models.Base;
using System.Collections.Generic;

namespace RestWithASPNETUdemy.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        List<T> FindAll();
        T FindById(long id);
        T Create(T item);
        T Update(T item);
        void Delete(long id);
        bool Exists(long id);
        List<T> FindWithPagedSearch(string query);
        int GetCount(string query);
    }
}
