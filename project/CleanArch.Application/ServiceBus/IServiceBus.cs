using MediatR;

namespace CleanArch.Application.ServiceBus
{
    public interface IServiceBus
    {
        Task<TResponse> Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken);
        Task Publish<TNotification>(TNotification notification, CancellationToken cancellationToken) where TNotification : INotification;
    }
}
