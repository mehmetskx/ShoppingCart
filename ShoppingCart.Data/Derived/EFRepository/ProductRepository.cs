using Microsoft.EntityFrameworkCore;
using ShoppingCart.Data.Entities;
using ShoppingCart.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Data.Derived.EFRepository
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(ShoppingCartDbContext context) : base(context)
        {
        }
    }
}
