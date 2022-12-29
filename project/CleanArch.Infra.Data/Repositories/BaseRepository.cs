using CleanArch.Domain.DomainObjects;
using CleanArch.Domain.Interfaces;
using CleanArch.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace CleanArch.Infra.Data.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T>
            where T : Entity
    {
        public readonly AppDbContext DbContext;
        public DbSet<T> DbSet { get => DbContext.Set<T>(); }

        public BaseRepository(AppDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public virtual async Task AddAsync(T entity, CancellationToken cancellation)
        {
            if (entity.Id != Guid.Empty && await ExistAsync(entity.Id, cancellation))
                throw new DomainException("Já existe uma entidade para o 'id' informado");

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
            var entity = await DbSet.FirstOrDefaultAsync(e => e.Id == entityId, cancellation);

            if (entity == null)
                throw new DomainException("Nenhuma entidade encontrada para o id informado");

            return entity;
        }

        public virtual Task<List<T>> ListAsync(int page, int size, CancellationToken cancellation) =>
            DbSet.Skip((page - 1) * size).Take(size).ToListAsync(cancellation);

        public virtual Task<int> CountAsync(CancellationToken cancellation) =>
            DbSet.CountAsync(cancellation);

        public virtual async Task RemoveRecursivelyAsync(Guid entityId, CancellationToken cancellation)
        {
            var entity = await GetByIdAsync(entityId, cancellation);
            var entityList = new Dictionary<Guid, Entity>();

            FillRecursiveEntityList(entity, entityList);

            foreach (var item in entityList)
                DbContext.Entry(item.Value).State = EntityState.Deleted;

            await DbContext.SaveChangesAsync(cancellation);
        }

        public virtual async Task UpdateRecursivelyAsync(T entity, CancellationToken cancellation)
        {
            var entityDb = await GetByIdAsync(entity.Id, cancellation);

            if (entityDb == null)
                throw new DomainException("Nenhuma entidade encontrada para o 'id' informado");

            var targetList = new Dictionary<Guid, Entity>();
            FillRecursiveEntityList(entityDb, targetList);

            var sourceList = new Dictionary<Guid, Entity>();
            FillRecursiveEntityList(entity, sourceList);

            foreach (var item in sourceList)
            {
                var target = targetList.GetValueOrDefault(item.Key);
                var source = item.Value;

                if (target == null)
                {
                    DbSet.Add(entity);
                    continue;
                }

                DbContext.Entry(target).CurrentValues.SetValues(source);
            }

            await DbContext.SaveChangesAsync(cancellation);
        }

        private void FillRecursiveEntityList(Entity entity, Dictionary<Guid, Entity> list)
        {
            // Retorna propriedades assinaveis para 'Entity' ou 'IList<Entity>'
            var props = entity.GetType().GetProperties()
                .Where(p =>
                   p.PropertyType.IsAssignableTo(typeof(Entity)) ||
                   p.PropertyType.GetGenericArguments()?.FirstOrDefault()?.BaseType == typeof(Entity));

            foreach (var prop in props)
            {
                if (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(IList<>))
                {
                    var entityList = (IList)entity.GetType().GetProperty(prop.Name).GetValue(entity);

                    foreach (var item in entityList)
                        FillRecursiveEntityList((Entity)item, list);

                    continue;
                }

                var entrieEntity = (Entity)entity.GetType().GetProperty(prop.Name).GetValue(entity);

                if (entrieEntity == null)
                    continue;

                FillRecursiveEntityList(entrieEntity, list);
            }

            list.Add(entity.Id, entity);
        }

    }
}
