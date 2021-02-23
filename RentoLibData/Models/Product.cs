using System;
using System.Collections.Generic;

#nullable disable

namespace RentoLibData.Models
{
    public partial class Product
    {
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public int ProductSubcategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal PricePerDay { get; set; }
        public bool Status { get; set; }

        public virtual ProductSubcategory ProductSubcategory { get; set; }
        public virtual User User { get; set; }
        public virtual ProductRequest ProductRequest { get; set; }
    }
}
