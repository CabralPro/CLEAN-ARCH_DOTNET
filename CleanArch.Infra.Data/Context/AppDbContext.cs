using CleanArch.Domain.Entities;
using CleanArch.Infra.Data.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.Infra.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        { }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
        }

    }
}
