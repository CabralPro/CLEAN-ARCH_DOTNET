
using AutoMapper;
using CleanArch.Application.Interfaces;
using CleanArch.Domain.Interfaces;

namespace CleanArch.Application.Services
{
    public abstract class BaseService<Entity, Dto> : IBaseService<Dto>
        where Dto : class
        where Entity : class
    {
        
        public readonly IBaseRepository<Entity> repository;
        public readonly IMapper mapper;

        public BaseService(IBaseRepository<Entity> _repository, IMapper _mapper)
        {
            repository = _repository;
            mapper = _mapper;
        }

        public Task Add(Dto entityDto)
        {
            var entity = mapper.Map<Entity>(entityDto);
            return repository.Add(entity);
        }

        public async Task<Dto> GetByIdAsync(Guid entityDtoId)
        {
            var entity = await repository.GetByIdAsync(entityDtoId);
            return mapper.Map<Dto>(entity);
        }

        public async Task<List<Dto>> GetListAsync()
        {
            var entityList = await repository.GetListAsync();
            return mapper.Map<List<Dto>>(entityList);
        }

        public Task Remove(Guid entityDtoId) =>
            repository.Remove(entityDtoId);

        public Task Update(Dto entityDto)
        {
            var entity = mapper.Map<Entity>(entityDto);
            return repository.Update(entity);
        }

    }
}
