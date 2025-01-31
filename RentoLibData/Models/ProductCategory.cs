﻿using System;
using System.Collections.Generic;

#nullable disable

namespace RentoLibData.Models
{
    public partial class ProductCategory
    {
        public ProductCategory()
        {
            ProductSubcategories = new HashSet<ProductSubcategory>();
        }

        public int ProductCategoryId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ProductSubcategory> ProductSubcategories { get; set; }
    }
}
