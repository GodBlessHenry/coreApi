using Catalog.Entity;
using Microsoft.EntityFrameworkCore;

namespace Catalog.EFRepository
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Product>().Property(x => x.Price).HasColumnType("decimal(20,2)");
        }
    }
}
