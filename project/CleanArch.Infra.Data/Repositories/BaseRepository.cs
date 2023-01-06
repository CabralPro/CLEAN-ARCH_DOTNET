using CleanArch.Domain.DomainObjects;
using CleanArch.Domain.Interfaces;
using CleanArch.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections;

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

        public virtual async Task<T> AddAsync(T entity, CancellationToken cancellation)
        {
            DbSet.Add(entity);
            await DbContext.SaveChangesAsync(cancellation);
            return entity;
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

        public virtual async Task<T> UpdateAsync(T entity, CancellationToken cancellation)
        {
            DbContext.Update(entity);
            await DbContext.SaveChangesAsync(cancellation);
            return entity;
        }

        public async Task<T> RemoveInternalDeletedEntitiesAsync(T entity, CancellationToken cancellation)
        {
            var entityDb = await GetByIdAsync(entity.Id, cancellation);

            var dbEntities = new Dictionary<Guid, EntityBase>();
            FillRecursiveEntityList(entityDb, dbEntities);

            var receivedEntities = new Dictionary<Guid, EntityBase>();
            FillRecursiveEntityList(entity, receivedEntities);

            foreach (var item in dbEntities)
            {
                var received = receivedEntities.GetValueOrDefault(item.Key);
                if (received == null)
                    DbContext.Entry(item.Value).State = EntityState.Deleted;
            }

            await DbContext.SaveChangesAsync(cancellation);
            return await GetByIdAsync(entity.Id, cancellation);
        }

        private void FillRecursiveEntityList(EntityBase entity, Dictionary<Guid, EntityBase> list)
        {
            if (entity == null || list.ContainsKey(entity.Id) || entity.Id == Guid.Empty)
                return;

            list.Add(entity.Id, entity);

            foreach (var prop in entity.GetType().GetProperties())
            {
                if (prop.PropertyType.IsAssignableTo(typeof(EntityBase)))
                {
                    FillRecursiveEntityList((EntityBase)prop.GetValue(entity), list);
                }
                else if (prop.PropertyType.IsAssignableTo(typeof(IEnumerable)))
                {
                    var entityList = ((IEnumerable)prop.GetValue(entity)).OfType<EntityBase>();

                    foreach (var item in entityList)
                        FillRecursiveEntityList(item, list);
                }
            }
        }

    }
}
