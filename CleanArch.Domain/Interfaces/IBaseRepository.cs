
namespace CleanArch.Domain.Interfaces
{
    public interface IBaseRepository<Entity> where Entity : class
    {
        Task<List<Entity>> GetListAsync();
        Task<Entity> GetByIdAsync(Guid entityId);
        Task Add(Entity entity);
        Task Update(Entity entity);
        Task Remove(Guid entityId);
    }
}
