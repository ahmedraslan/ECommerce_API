using E_Commerce.Core.Entities;

namespace E_Commerce.API.DTOs
{
    public class ProductToReturnDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PictureUrl { get; set; }
        public decimal Price { get; set; }

        public int BrandId { get; set; }
        public int TypeId { get; set; }
        public string ProductBrand { get; set; } // instead of ProductBrand type it will be string type because we need only name of productBrand not the entire object and not to repeat Id.
        public string ProductType { get; set; }// instead of ProductType type it will be string type because we need only name of productType not the entire object and not to repeat Id.
    }
}
