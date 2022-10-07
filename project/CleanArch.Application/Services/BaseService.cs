
using AutoMapper;
using CleanArch.Application.Interfaces;
using CleanArch.Domain.DomainObjects;
using CleanArch.Domain.Interfaces;

namespace CleanArch.Application.Services
{
    public abstract class BaseService<T1, T2> : IBaseService<T2>
        where T1 : Entity
        where T2 : Dto
    {

        public readonly IBaseRepository<T1> repository;
        public readonly IMapper mapper;

        public BaseService(IBaseRepository<T1> _repository, IMapper _mapper)
        {
            repository = _repository;
            mapper = _mapper;
        }

        public async Task<T2> Add(T2 entityDto)
        {
            var entity = mapper.Map<T1>(entityDto);
            await repository.Add(entity);
            return await GetByIdAsync(entity.Id);
        }

        public async Task<T2> GetByIdAsync(Guid entityDtoId)
        {
            var entity = await repository.GetByIdAsync(entityDtoId);
            return mapper.Map<T2>(entity);
        }

        public async Task<List<T2>> GetListAsync()
        {
            var entityList = await repository.GetListAsync();
            return mapper.Map<List<T2>>(entityList);
        }

        public Task Remove(Guid entityDtoId) =>
            repository.Remove(entityDtoId);

        public async Task<T2> Update(T2 entityDto)
        {
            var entity = mapper.Map<T1>(entityDto);
            await repository.Update(entity);
            return await GetByIdAsync(entity.Id);
        }

    }
}
