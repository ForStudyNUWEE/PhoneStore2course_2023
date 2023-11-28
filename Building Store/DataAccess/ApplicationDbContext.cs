using Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    internal class ApplicationDbContext : IdentityDbContext<Person>
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
}