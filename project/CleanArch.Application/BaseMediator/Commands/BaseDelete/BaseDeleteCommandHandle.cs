using CleanArch.Domain.DomainObjects;
using CleanArch.Domain.Interfaces;
using MediatR;

namespace CleanArch.Application.BaseMediator.Commands.BaseDelete
{
    public class BaseDeleteCommandHandle<T> : IRequestHandler<BaseDeleteCommand<T>>
            where T : EntityBase
    {
        private readonly IBaseRepository<T> _repository;

        public BaseDeleteCommandHandle(IBaseRepository<T> repository)
        {
            _repository = repository;
        }

        public virtual async Task<Unit> Handle(BaseDeleteCommand<T> request, CancellationToken cancellationToken)
        {
            await _repository.RemoveAsync(request.EntityId, cancellationToken);
            return Unit.Value;
        }
    }
}
