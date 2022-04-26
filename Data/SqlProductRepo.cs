using ba.Models;

namespace ba.Data;

public class SqlProductRepo : IProductRepo
{
    private readonly ProductContext _context;

    public SqlProductRepo(ProductContext context)
    {
        _context = context;
    }
    public bool SaveChanges()
    {
        return (_context.SaveChanges() >= 0);
    }

    public IEnumerable<Product> GetAllProducts()
    {
        return _context.Products.ToList();
    }

    public Product GetProductById(int id)
    {
        return _context.Products.FirstOrDefault(p => p.Id == id);
    }

    public void CreateProduct(Product product)
    {
        if (product == null)
            throw new ArgumentNullException(nameof(product));
        _context.Products.Add(product);
    }

    public void UpdateProduct(Product product)
    {
        //Nothing
    }

    public void DeleteProduct(Product product)
    {
        if (product == null)
            throw new ArgumentNullException(nameof(product));
        _context.Products.Remove(product);
        
    }
}