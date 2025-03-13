using MagicBuysAdmin.Models;
using Microsoft.EntityFrameworkCore;

namespace MagicBuysAdmin.Repository
{
    public class ProductDBContext:DbContext
    {
        public ProductDBContext(DbContextOptions<ProductDBContext> options) : 
            base(options)
        {
        }

        public DbSet<ProductModel> Products { get; set; }   

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ProductModel>().ToTable("Products");
        }

    }
}
