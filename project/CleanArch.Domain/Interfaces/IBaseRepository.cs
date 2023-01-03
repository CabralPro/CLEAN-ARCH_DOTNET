
using CleanArch.Domain.DomainObjects;

namespace CleanArch.Domain.Interfaces
{
    public interface IBaseRepository<T> where T : EntityBase
    {
        Task<List<T>> ListAsync(int page, int size, CancellationToken cancellation);
        Task<int> CountAsync(CancellationToken cancellation);
        Task<T> GetByIdAsync(Guid entityId, CancellationToken cancellation);
        Task AddAsync(T entity, CancellationToken cancellation);
        Task UpdateAsync(T entity, CancellationToken cancellation);
        Task<bool> ExistAsync(Guid entityId, CancellationToken cancellation);
        Task RemoveAsync(Guid entityId, CancellationToken cancellation);
    }
}
