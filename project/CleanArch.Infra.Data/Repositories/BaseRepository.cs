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

        public async Task<T> Add(T entity)
        {
            dbContext.Add(entity);
            await dbContext.SaveChangesAsync();
            return await GetByIdAsync(entity.Id);
        }

        public async Task<bool> Exist(Guid entityId)
        {
            var entity = await GetByIdAsync(entityId);
            return entity != null;
        }

        public async Task<T> GetByIdAsync(Guid entityId)
        {
            var entity = await dbSet.FindAsync(entityId);
            if (entity == null)
                throw new DomainException("There is no entity for the given id");
            
            return entity;
        }

        public Task<List<T>> GetListAsync() =>
            dbSet.ToListAsync();

        public async Task Remove(Guid entityId)
        {
            var entityDb = await GetByIdAsync(entityId);
            dbContext.Remove(entityDb);
            await dbContext.SaveChangesAsync();
        }

        public async Task<T> Update(T entity)
        {
            dbContext.Update(entity);
            await dbContext.SaveChangesAsync();
            return await GetByIdAsync(entity.Id);
        }
    }
}
