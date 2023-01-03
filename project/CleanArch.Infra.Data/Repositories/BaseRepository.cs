using CleanArch.Domain.DomainObjects;
using CleanArch.Domain.Interfaces;
using CleanArch.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.Infra.Data.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T>
            where T : EntityBase
    {
        public readonly AppDbContext DbContext;
        public DbSet<T> DbSet { get => DbContext.Set<T>(); }

        public BaseRepository(AppDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public virtual async Task AddAsync(T entity, CancellationToken cancellation)
        {
            DbSet.Add(entity);
            await DbContext.SaveChangesAsync(cancellation);
        }

        public virtual async Task<bool> ExistAsync(Guid entityId, CancellationToken cancellation)
        {
            var id = await DbSet.Select(e => e.Id)
                .SingleOrDefaultAsync(id => id == entityId, cancellation);

            return id != Guid.Empty;
        }

        public virtual async Task<T> GetByIdAsync(Guid entityId, CancellationToken cancellation)
        {
            DbContext.ChangeTracker.Clear();

            var entity = await DbSet.FirstOrDefaultAsync(e => e.Id == entityId, cancellation);

            if (entity == null)
                throw new DomainException("Nenhuma entidade encontrada para o id informado");

            return entity;
        }

        public virtual Task<List<T>> ListAsync(int page, int size, CancellationToken cancellation) =>
            DbSet.Skip((page - 1) * size).Take(size).ToListAsync(cancellation);

        public virtual Task<int> CountAsync(CancellationToken cancellation) =>
            DbSet.CountAsync(cancellation);

        public virtual async Task RemoveAsync(Guid entityId, CancellationToken cancellation)
        {
            var entity = await GetByIdAsync(entityId, cancellation);
            DbContext.Remove(entity);
            await DbContext.SaveChangesAsync(cancellation);
        }

        public virtual Task UpdateAsync(T entity, CancellationToken cancellation)
        {
            DbContext.Update(entity);
            return DbContext.SaveChangesAsync(cancellation);
        }

    }
}
