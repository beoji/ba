// using System.Collections.Generic;
using ba.Models;

namespace ba.Data;
public class MockProductRepo : IProductRepo
{
    public void CreateProduct(Product product)
    {
        throw new NotImplementedException();
    }

    public void DeleteProduct(int id)
    {
        throw new NotImplementedException();
    }

    public void DeleteProduct(Product product)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Product> GetAllProducts()
    {
        var products = new List<Product> 
        {
            new Product{Id=0, Name="Meek AirPurifier", ShortDescription="Good quality Air Purifier", Price=799},
            new Product{Id=1, Name="Meek Boiler",      ShortDescription="Good quality Boiler", Price=499},
            new Product{Id=2, Name="Meek CleaningRobot",ShortDescription="Good quality Air CleaningRobot", Price=1299},
            new Product{Id=3, Name="Meek Headphones",  ShortDescription="Good quality HeadPhones", Price=199}
        };

        return products;
    }

    public Product GetProductById(int id)
    {
        return new Product{Id=17, Name="Meek AirPurifier", ShortDescription="Good quality Air Purifier", Price=799};
    }

    public bool SaveChanges()
    {
        throw new NotImplementedException();
    }

    public void UpdateProduct(Product product)
    {
        throw new NotImplementedException();
    }
}