using E_Commerce.Core.Entities;
using E_Commerce.Repository.Context;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace E_Commerce.Repository
{
    public static class ContextSeed
    {
        public static async Task SeedAsync (DataContext context)
        {
            
            
                if(context.ProductBrands.Count() == 0)
                {
                    var brandsData = File.ReadAllText("../E-Commerce.Repository/SeedData/brands.json");

                    //Serialization is converting Object to string. and DeSerialization is converting string to list of brands
                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);

                    if(brands?.Count() > 0)
                    {
                        foreach (var brand in brands)
                                 context.Set<ProductBrand>().Add(brand);

                        await context.SaveChangesAsync();
                    }
                }

                if (context.ProductTypes.Count() == 0)
                {
                    var typesData = File.ReadAllText("../E-Commerce.Repository/SeedData/types.json");

                    //Serialization is converting Object to string. and DeSerialization is converting string to list of types
                    var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);

                    if (types?.Count() > 0)
                    {
                        foreach (var type in types)
                            context.Set<ProductType>().Add(type);

                        await context.SaveChangesAsync();
                    }
                }

                if (context.Products.Count() == 0)
                {
                    var productsData = File.ReadAllText("../E-Commerce.Repository/SeedData/products.json");

                    //Serialization is converting Object to string. and DeSerialization is converting string to list of products
                    var products = JsonSerializer.Deserialize<List<Product>>(productsData);

                    if (products?.Count() > 0)
                    {
                        foreach (var product in products)
                            context.Set<Product>().Add(product);

                        await context.SaveChangesAsync();
                    }
                }
                      
        }
    }
}
