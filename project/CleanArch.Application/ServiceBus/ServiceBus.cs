using MediatR;

namespace CleanArch.Application.ServiceBus
{
    public class ServiceBus : IServiceBus
    {
        private readonly IMediator _mediator;

        public ServiceBus(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Task Publish<TNotification>(TNotification notification, CancellationToken cancellationToken) where TNotification : INotification =>
            _mediator.Send(notification, cancellationToken);

        public Task<TResponse> Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken) =>
            _mediator.Send(request, cancellationToken);

    }
}
