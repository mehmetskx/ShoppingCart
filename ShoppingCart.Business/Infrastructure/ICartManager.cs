using ShoppingCart.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoppingCart.Business.Infrastructure
{
    public interface ICartManager
    {
       Task AddProductToCart(List<Product> product);
    }
}
