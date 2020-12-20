using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Data.Infrastructure
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync(int id);
        Task AddAsync(T entity);
        void RemoveAsync(T entity);
        T UpdateAsync(T entity);

    }
}
