using CleanArch.Domain.DomainObjects;
using CleanArch.Domain.Interfaces;
using CleanArch.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.Infra.Data.Repositories
{
    public class BaseRepository<Entity> : IBaseRepository<Entity>
        where Entity : class
    {
        public readonly AppDbContext dbContext;
        public readonly DbSet<Entity> dbSet;

        public BaseRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
            dbSet = dbContext.Set<Entity>();
        }

        public async Task Add(Entity entity)
        {
            dbContext.Add(entity);
            var resp = await dbContext.SaveChangesAsync();
            if (resp != 1)
                throw new DomainException("It was not possible to save the entity");
        }

        public async Task<Entity> GetByIdAsync(Guid entityId)
        {
            var entity = await dbSet.FindAsync(entityId);
            if (entity is null)
                throw new DomainException("No entity found for the given id");

            return entity;
        }

        public Task<List<Entity>> GetListAsync() =>
            dbSet.ToListAsync();

        public async Task Remove(Guid entityId)
        {
            dbContext.Remove(entityId);
            var resp = await dbContext.SaveChangesAsync();
            if (resp != 1)
                throw new DomainException("It was not possible to remove the entity");
        }

        public async Task Update(Entity entity)
        {
            dbContext.Update(entity);
            var resp = await dbContext.SaveChangesAsync();
            if (resp != 1)
                throw new DomainException("It was not possible to update the entity");
        }
    }
}
