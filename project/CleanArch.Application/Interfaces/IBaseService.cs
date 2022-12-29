
using CleanArch.Domain.DomainObjects;

namespace CleanArch.Application.Interfaces
{
    public interface IBaseService<T> where T : Dto
    {
        Task<List<T>> ListAsync(int page, int size, CancellationToken cancellation);
        Task<int> CountAsync(CancellationToken cancellation);
        Task<T> GetByIdAsync(Guid entityDtoId, CancellationToken cancellation);
        Task<T> AddAsync(T entityDto, CancellationToken cancellation);
        Task<T> UpdateAsync(T entityDto, CancellationToken cancellation);
        Task RemoveAsync(Guid entityDtoId, CancellationToken cancellation);
    }
}
