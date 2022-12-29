
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

        public async Task<T2> AddAsync(T2 entityDto, CancellationToken cancellation)
        {
            var entity = mapper.Map<T1>(entityDto);
            await repository.AddAsync(entity, cancellation);
            return await GetByIdAsync(entity.Id, cancellation);
        }

        public async Task<T2> GetByIdAsync(Guid entityDtoId, CancellationToken cancellation)
        {
            var entity = await repository.GetByIdAsync(entityDtoId, cancellation);
            return mapper.Map<T2>(entity);
        }

        public async Task<List<T2>> ListAsync(int page, int size, CancellationToken cancellation)
        {
            var entityList = await repository.ListAsync(page, size, cancellation);
            return mapper.Map<List<T2>>(entityList);
        }

        public Task<int> CountAsync(CancellationToken cancellation)
        {
            return repository.CountAsync(cancellation);
        }

        public Task RemoveAsync(Guid entityDtoId, CancellationToken cancellation) =>
            repository.RemoveRecursivelyAsync(entityDtoId, cancellation);

        public async Task<T2> UpdateAsync(T2 entityDto, CancellationToken cancellation)
        {
            var entity = mapper.Map<T1>(entityDto);
            await repository.UpdateRecursivelyAsync(entity, cancellation);
            return await GetByIdAsync(entity.Id, cancellation);
        }

    }
}
