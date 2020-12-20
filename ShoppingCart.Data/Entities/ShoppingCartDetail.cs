using ShoppingCart.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ShoppingCart.Data.Entities
{
    [Table("Tbl_ShoppingCartDetail")]
    public class ShoppingCartDetail : IEntity
    {
        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public int ShoppingCartId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool IsActive { get; set; }
        public ShoppingCart ShoppingCart { get; set; }
    }
}
