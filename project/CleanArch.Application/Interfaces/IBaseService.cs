
using CleanArch.Domain.DomainObjects;

namespace CleanArch.Application.Interfaces
{
    public interface IBaseService<T> where T : Dto
    {
        Task<List<T>> GetListAsync();
        Task<T> GetByIdAsync(Guid entityDtoId);
        Task<T> Add(T entityDto);
        Task<T> Update(T entityDto);
        Task Remove(Guid entityDtoId);
    }
}
