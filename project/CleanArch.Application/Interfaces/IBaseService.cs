
namespace CleanArch.Application.Interfaces
{
    public interface IBaseService<Dto> where Dto : class
    {
        Task<List<Dto>> GetListAsync();
        Task<Dto> GetByIdAsync(Guid entityDtoId);
        Task Add(Dto entityDto);
        Task Update(Dto entityDto);
        Task Remove(Guid entityDtoId);
    }
}
