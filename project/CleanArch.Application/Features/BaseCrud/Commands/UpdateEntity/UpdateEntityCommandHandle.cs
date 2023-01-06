using CleanArch.Domain.DomainObjects;
using CleanArch.Domain.Interfaces;
using MediatR;

namespace CleanArch.Application.Features.BaseCrud.Commands.UpdateEntity
{
    public class UpdateEntityCommandHandle<T> : IRequestHandler<UpdateEntityCommand<T>, Guid>
        where T : EntityBase
    {
        private readonly IBaseRepository<T> _repository;

        public UpdateEntityCommandHandle(IBaseRepository<T> repository)
        {
            _repository = repository;
        }

        public virtual async Task<Guid> Handle(UpdateEntityCommand<T> request, CancellationToken cancellationToken)
        {
            await _repository.UpdateAsync(request.Entity, cancellationToken);
            return request.Entity.Id;
        }

    }
}
