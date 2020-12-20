using System.Threading.Tasks;

namespace ShoppingCart.Data.Infrastructure
{
    public interface IShoppingCartRepository : IGenericRepository<ShoppingCart.Data.Entities.ShoppingCart>
    {
        /// <summary>
        /// This method return a user shopping cart. 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>ShoppingCart</returns>
        Task<ShoppingCart.Data.Entities.ShoppingCart> GetUserShoppingCartByUserIdAsync(int userId);
    }    
}
