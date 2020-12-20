﻿using ShoppingCart.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ShoppingCart.Data.Entities
{
    [Table("Tbl_ShoppingCart")]
    public class ShoppingCart : IEntity
    {
        [Key]
        public int Id { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool IsActive { get; set; }
        public ICollection<ShoppingCartDetail> ShoppingCartDetail  { get; set; }
    }
}
