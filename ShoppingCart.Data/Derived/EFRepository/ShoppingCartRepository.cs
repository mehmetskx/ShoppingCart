using Microsoft.EntityFrameworkCore;
using ShoppingCart.Data.Entities;
using ShoppingCart.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Data.Derived.EFRepository
{
    public class ShoppingCartRepository : GenericRepository<ShoppingCart.Data.Entities.ShoppingCart>, IShoppingCartRepository
    {
        private DbSet<ShoppingCart.Data.Entities.ShoppingCart> _table;
        private ShoppingCartDbContext _context;
        public ShoppingCartRepository(ShoppingCartDbContext context) : base(context)
        {
            _table = context.Set<ShoppingCart.Data.Entities.ShoppingCart>();
            _context = context;
        }

        public async Task<ShoppingCart.Data.Entities.ShoppingCart> GetUserShoppingCartByUserIdAsync(int userId)
        {
            //One person has got one shopping cart
            return await _table.SingleOrDefaultAsync(x => x.CreatedBy == userId && x.IsActive == true);
        }       
    }
}
