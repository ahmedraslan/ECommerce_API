using E_Commerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Specifications.ProductSpecs
{
    public class ProductWithBrandAndTypeSpecifications : BaseSpecifications<Product>
    {

        //This constructor will be used for creating an object, this object will be used to get All Products
        public ProductWithBrandAndTypeSpecifications(ProductSpecParams specParams) 
            :base(P =>
                        (string.IsNullOrEmpty(specParams.Search) || P.Name.ToLower().Contains(specParams.Search)) && // For Searching
                        (!specParams.BrandId.HasValue || P.BrandId == specParams.BrandId.Value) &&      //For Filteration
                        (!specParams.TypeId.HasValue  || P.TypeId  == specParams.TypeId.Value)                  
                 )
        {
            AddIncludes(); 

            if(!string.IsNullOrEmpty(specParams.Sort))
            {
                switch(specParams.Sort)
                {
                    case "priceAsc":
                        AddOrderBy(P => P.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDesc(P => P.Price);
                        break;
                    default:
                        AddOrderBy(P => P.Name);
                        break;
                }
            }
            else
                AddOrderBy(P => P.Name);


            ApplyPagination((specParams.PageIndex - 1) * specParams.PageSize, specParams.PageSize);

        }
        
        public ProductWithBrandAndTypeSpecifications(int id) : base(P => P.Id == id)
        {
            AddIncludes();

        }

        private void AddIncludes()
        {
            Includes.Add(P => P.ProductBrand);
            Includes.Add(P => P.ProductType);
        }

    }
}
