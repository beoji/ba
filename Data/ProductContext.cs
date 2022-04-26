using Microsoft.EntityFrameworkCore;
using ba.Models;

namespace ba.Data;

public class ProductContext : DbContext
{
    public ProductContext(DbContextOptions<ProductContext> opt) : base(opt)
    {
        
    }

    public DbSet<Product> Products { get; set; }
}