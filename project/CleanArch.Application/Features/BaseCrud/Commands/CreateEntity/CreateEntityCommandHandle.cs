using CleanArch.Domain.DomainObjects;
using CleanArch.Domain.Interfaces;
using MediatR;

namespace CleanArch.Application.Features.BaseCrud.Commands.CreateEntity
{
    public class CreateEntityCommandHandle<T> : IRequestHandler<CreateEntityCommand<T>, Guid>
        where T : EntityBase
    {
        private readonly IBaseRepository<T> _repository;

        public CreateEntityCommandHandle(IBaseRepository<T> repository)
        {
            _repository = repository;
        }

        public virtual async Task<Guid> Handle(CreateEntityCommand<T> request, CancellationToken cancellationToken)
        {
            await _repository.AddAsync(request.Entity, cancellationToken);
            return request.Entity.Id;
        }

    }
}
