using Microsoft.EntityFrameworkCore;
using ShoppingCart.Data.Entities;
using ShoppingCart.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Data.Derived.EFRepository
{
    public class ShoppingCartDetailRepository : GenericRepository<ShoppingCartDetail>, IShoppingCartDetailRepository
    {
        private DbSet<ShoppingCartDetail> _table;
        public ShoppingCartDetailRepository(ShoppingCartDbContext context) : base(context)
        {
            _table = context.Set<ShoppingCartDetail>();
        }

        public async Task AddRangeAsync(IEnumerable<ShoppingCartDetail> shoppingCartDetails)
        {
            await _table.AddRangeAsync(shoppingCartDetails);
        }
    }
}
