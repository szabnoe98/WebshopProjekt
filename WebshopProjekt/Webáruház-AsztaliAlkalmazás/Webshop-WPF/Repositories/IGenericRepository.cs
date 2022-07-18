using System.Collections.Generic;

namespace Webshop_WPF.Repositories
{
    interface IGenericRepository<T> where T : class
    {
        List<T> GetAll();
        T GetById(int id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}
