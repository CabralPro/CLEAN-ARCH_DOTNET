
using CleanArch.Domain.DomainObjects;
using CleanArch.Infra.Data.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.Infra.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ClientConfiguration());
            modelBuilder.ApplyConfiguration(new BankAccountConfiguration());
            modelBuilder.ApplyConfiguration(new AddressConfiguration());
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            UpdateEntityDates();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void UpdateEntityDates()
        {
            var entries = ChangeTracker.Entries()
                .Where(e => e.Entity is Entity &&
                    (e.State == EntityState.Added ||
                     e.State == EntityState.Modified));

            foreach (var entry in entries)
            {
                var entity = ((Entity)entry.Entity);
                entity.UpdatedDate = DateTime.UtcNow;

                switch (entry.State)
                {
                    case EntityState.Detached:
                    case EntityState.Modified:
                        entry.Property(nameof(entity.CreatedDate)).IsModified = false;
                        break;
                    case EntityState.Added:
                        entity.CreatedDate = DateTime.UtcNow;
                        break;
                }

                entity.Validate();
            }
        }

    }
}
