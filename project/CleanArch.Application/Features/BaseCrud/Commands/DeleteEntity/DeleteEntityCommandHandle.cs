using CleanArch.Domain.DomainObjects;
using CleanArch.Domain.Interfaces;
using MediatR;

namespace CleanArch.Application.Features.BaseCrud.Commands.DeleteEntity
{
    public class DeleteEntityCommandHandle<T> : IRequestHandler<DeleteEntityCommand<T>>
            where T : EntityBase
    {
        private readonly IBaseRepository<T> _repository;

        public DeleteEntityCommandHandle(IBaseRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteEntityCommand<T> request, CancellationToken cancellationToken)
        {
            await _repository.RemoveAsync(request.EntityId, cancellationToken);
            return Unit.Value;
        }
    }
}
