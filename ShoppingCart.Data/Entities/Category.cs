using ShoppingCart.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ShoppingCart.Data.Entities
{
    [Table("Tbl_Category")]
    public class Category : IEntity
    {
        public Category()
        {
            Products = new Collection<Product>();
        }
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool IsActive { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
