﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Entities
{
    public class ProductBrand : BaseEntity
    {
        public string Name { get; set; }

        //public ICollection<Product> Products { get; set; } = new HashSet<Product>();   //instead of this navigation property, i will define it using fluent API.

    }
}
