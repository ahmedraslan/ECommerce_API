﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Specifications.ProductSpecs
{
    public class ProductSpecParams
    {
        private const int MaxPageSize = 10;
        private int pageSize = 5; //default page size

        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = value > MaxPageSize ? MaxPageSize : value; }
        }

        public int PageIndex { get; set; } = 1;

        private string? search;

        public string? Search
        {
            get { return search; }
            set { search = value?.ToLower(); }
        }

        public string? Sort { get; set; }
        public int? BrandId { get; set; }
        public int? TypeId { get; set;}
    }
}
