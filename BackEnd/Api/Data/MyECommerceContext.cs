using Microsoft.EntityFrameworkCore;

namespace Api.Data
{
    public class MyDBContext : DbContext
    {
    public MyDBContext(DbContextOptions<MyDBContext> options) : base(options) { }


    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<User> users { get; set; }
    public DbSet<Order> Orders { get; set; }

    }

}