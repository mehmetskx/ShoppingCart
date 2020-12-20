using Microsoft.EntityFrameworkCore;
using ShoppingCart.Data.Derived.EFRepository;
using ShoppingCart.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Data.Derived
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ShoppingCartDbContext _context;
        private ProductRepository _productRepository;
        private ShoppingCartRepository _shoppingCartRepository;
        private ShoppingCartDetailRepository _shoppingCartDetailRepository;

        public UnitOfWork(ShoppingCartDbContext context)
        {
            this._context = context;
        }

        public IProductRepository Products => _productRepository = _productRepository ?? new ProductRepository(_context);
        public IShoppingCartRepository ShoppingCart => _shoppingCartRepository = _shoppingCartRepository ?? new ShoppingCartRepository(_context);
        public IShoppingCartDetailRepository ShoppingCartDetail => _shoppingCartDetailRepository = _shoppingCartDetailRepository ?? new ShoppingCartDetailRepository(_context);


        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
