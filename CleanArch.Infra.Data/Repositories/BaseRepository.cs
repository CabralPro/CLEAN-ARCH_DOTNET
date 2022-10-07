using CleanArch.Domain.DomainObjects;
using CleanArch.Domain.Interfaces;
using CleanArch.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.Infra.Data.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T>
        where T : Entity
    {
        public readonly AppDbContext dbContext;
        public readonly DbSet<T> dbSet;

        public BaseRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
            dbSet = dbContext.Set<T>();
        }

        public async Task Add(T entity)
        {
            dbContext.Add(entity);
            await dbContext.SaveChangesAsync();
        }

        public async Task<bool> Exist(Guid entityId)
        {
            var entity = await GetByIdAsync(entityId);
            return entity != null;
        }

        public async Task<T> GetByIdAsync(Guid entityId) =>
             await dbSet.FindAsync(entityId);

        public Task<List<T>> GetListAsync() =>
            dbSet.ToListAsync();

        public async Task Remove(Guid entityId)
        {
            var entityDb = await GetByIdAsync(entityId);
            dbContext.Remove<T>(entityDb);
            await dbContext.SaveChangesAsync();
        }

        public Task Update(T entity)
        {
            dbContext.Update(entity);
            return dbContext.SaveChangesAsync();
        }
    }
}
