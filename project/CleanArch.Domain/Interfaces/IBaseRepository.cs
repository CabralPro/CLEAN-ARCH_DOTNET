
using CleanArch.Domain.DomainObjects;

namespace CleanArch.Domain.Interfaces
{
    public interface IBaseRepository<T> where T : Entity
    {
        Task<List<T>> GetListAsync();
        Task<T> GetByIdAsync(Guid entityId);
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task<bool> Exist(Guid entityId);
        Task Remove(Guid entityId);
    }
}
