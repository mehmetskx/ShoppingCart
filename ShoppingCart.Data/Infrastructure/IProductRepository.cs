using ShoppingCart.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Data.Infrastructure
{
    public interface IProductRepository : IGenericRepository<Product>
    {
    }
}
