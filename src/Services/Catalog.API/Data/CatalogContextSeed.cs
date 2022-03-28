using Catalog.API.Entities;
using MongoDB.Driver;

namespace Catalog.API.Data;

public class CatalogContextSeed
{
    public static void SeedData(IMongoCollection<Product> productCollection)
    {
        var existProduct = productCollection.Find(p => true).Any();
        if (!existProduct) productCollection.InsertManyAsync(GetPreconfiguredProducts());
    }

    private static IEnumerable<Product> GetPreconfiguredProducts()
    {
        return new List<Product>
        {
            new()
            {
                Id = "60d8f8e0ad8e0a4c2aab8c11",
                Name = "Product 1",
                Description = "Product 1 description",
                Summary = "Product 1 summary",
                Category = "Category 1",
                ImageFile = "1.png",
                InStock = true,
                Price = 10
            },
            new()
            {
                Id = "60d8f8e0ad8e0a4c2aab8c21",
                Name = "Product 2",
                Description = "Product 2 description",
                Summary = "Product 2 summary",
                Category = "Category 2",
                ImageFile = "2.png",
                InStock = true,
                Price = 11
            },
            new()
            {
                Id = "60d8f8e0ad8e0a4c2aab8c31",
                Name = "Product 3",
                Description = "Product 3 description",
                Summary = "Product 3 summary",
                Category = "Category 3",
                ImageFile = "3.png",
                InStock = true,
                Price = 12
            },
            new()
            {
                Id = "60d8f8e0ad8e0a4c2aab8c41",
                Name = "Product 4",
                Description = "Product 4 description",
                Summary = "Product 4 summary",
                Category = "Category 4",
                ImageFile = "4.png",
                InStock = true,
                Price = 13
            }
        };
    }
}