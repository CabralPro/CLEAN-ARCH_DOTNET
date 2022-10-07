
using CleanArch.Domain.DomainObjects;

namespace CleanArch.Domain.Interfaces
{
    public interface IBaseRepository<T> where T : Entity
    {
        Task<List<T>> GetListAsync();
        Task<T> GetByIdAsync(Guid entityId);
        Task Add(T entity);
        Task Update(T entity);
        Task Remove(Guid entityId);
        Task<bool> Exist(Guid entityId);
    }
}
