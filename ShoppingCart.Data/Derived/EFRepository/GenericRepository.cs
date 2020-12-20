using Microsoft.EntityFrameworkCore;
using ShoppingCart.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Data.Derived.EFRepository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task<IEnumerable<T>> GetAllAsync(int id)
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public void RemoveAsync(T entity)
        {
            _dbSet.Remove(entity);
        }

        public T UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return entity;
        }
    }
}
