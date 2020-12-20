using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Data.Infrastructure
{
   public interface IUnitOfWork
    {
        IProductRepository Products { get; }
        IShoppingCartRepository ShoppingCart{ get; }
        IShoppingCartDetailRepository ShoppingCartDetail{ get; }
        Task<int> CommitAsync();
    }
}
