using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace UI.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Product { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            Category[] data = new Category[2];
            data[0] = new Category() { Id = 1, Name = "IPhone" };
            data[1] = new Category() { Id = 2, Name = "Samsung" };
            builder.Entity<Category>().HasData(data);

            Product[] products = new Product[3];
            products[0] = new Product() { Id = 1, Name = "7", CategoryId = 1, ColorId = 0, Memory = 16, Price = 300 };
            products[1] = new Product() { Id = 2, Name = "8", CategoryId = 1, ColorId = 0, Memory = 32, Price = 400 };
            products[2] = new Product() { Id = 3, Name = "Galaxy X10", CategoryId = 2, ColorId = 0, Memory = 32, Price = 350 };
            builder.Entity<Product>().HasData(products);

        }
    }

    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //Navigation properties
        public ICollection<Product> Products { get; set; } = new HashSet<Product>();
    }
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int ColorId { get; set; }
        public int Memory { get; set; }
        public int CategoryId { get; set; }
        //Navigation properties
        public Category Category { get; set; }
    }
}