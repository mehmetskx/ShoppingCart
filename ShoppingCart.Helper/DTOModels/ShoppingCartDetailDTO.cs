using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Helper.DTOModels
{
    public class ShoppingCartDetailDTO
    {
        public int Id { get; set; }
        public int ShoppingCartId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
