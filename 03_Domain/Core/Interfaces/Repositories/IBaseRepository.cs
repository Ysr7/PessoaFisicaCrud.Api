using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        Task AddAsync(T entity);
        IEnumerable<T> GetAll();
        T FirstOrDefault(Func<T, bool> criteria);
        IEnumerable<T> Where(Func<T, bool> criteria);
        Task UpdateAsync(T entity);
        void Delete(T entity);
        bool Exists(Func<T, bool> criteria);
    }
}