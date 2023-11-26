using APITask1.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Contracts;

namespace APITask1.Data
{
    public class ProductDbContext:DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> opt)
            :base(opt) 
        {
            
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }        
        public DbSet<Customer> Customers { get; set; }      
    }
}
