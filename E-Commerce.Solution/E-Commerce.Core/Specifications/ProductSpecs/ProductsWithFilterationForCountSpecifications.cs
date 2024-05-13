using E_Commerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Specifications.ProductSpecs
{
    public class ProductsWithFilterationForCountSpecifications : BaseSpecifications<Product>
    {

        public ProductsWithFilterationForCountSpecifications(ProductSpecParams specParams)
            :base(P =>
                        (string.IsNullOrEmpty(specParams.Search) || P.Name.ToLower().Contains(specParams.Search)) && // For Searching
                        (!specParams.BrandId.HasValue || P.BrandId == specParams.BrandId.Value) &&      //For Filteration
                        (!specParams.TypeId.HasValue || P.TypeId == specParams.TypeId.Value)
                 )
        {
            
        }

    }
}
