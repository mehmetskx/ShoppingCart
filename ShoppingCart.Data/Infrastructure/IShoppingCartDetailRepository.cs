using ShoppingCart.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Data.Infrastructure
{
    public interface IShoppingCartDetailRepository : IGenericRepository<ShoppingCartDetail>
    {
        Task AddRangeAsync(IEnumerable<ShoppingCartDetail> shoppingCartDetails);
    }
}
