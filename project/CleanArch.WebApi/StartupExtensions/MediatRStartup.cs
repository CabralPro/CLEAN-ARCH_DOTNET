using CleanArch.Application.Dtos;
using CleanArch.Application.Features.Clients.Commands.CreateClient;
using CleanArch.Application.Features.Clients.Commands.DeleteClient;
using CleanArch.Application.Features.Clients.Commands.RemoveInternalDeletedEntitiesClient;
using CleanArch.Application.Features.Clients.Commands.UpdateClient;
using CleanArch.Application.Features.Clients.Queries.GetClientById;
using CleanArch.Application.Features.Clients.Queries.GetClientList;
using MediatR;

namespace CleanArch.WebApi.StartupExtensions
{
    public static class MediatRStartup
    {
        public static IServiceCollection AddMediatRConfig(this IServiceCollection services)
        {
            /* CLIENT REGISTERS */
            services.AddTransient<IRequestHandler<GetClientByIdQuery, ClientDto>, GetClientByIdQueryHandle>();
            services.AddTransient<IRequestHandler<GetClientListQuery, (IEnumerable<ClientDto>, int)>, GetClientListQueryHandle>();
            services.AddTransient<IRequestHandler<CreateClientCommand, ClientDto>, CreateClientCommandHandle>();
            services.AddTransient<IRequestHandler<DeleteClientCommand, Unit>, DeleteClientCommandHandle>();
            services.AddTransient<IRequestHandler<UpdateClientCommand, ClientDto>, UpdateClientCommandHandle>();
            services.AddTransient<IRequestHandler<RemoveInternalDeletedEntitiesClientCommand, ClientDto>, RemoveInternalDeletedEntitiesClientCommandHandle>();

            /* ABCD REGISTERS */
            // ...

            return services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}
