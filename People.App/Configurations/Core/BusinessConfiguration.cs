using MediatR;
using Microsoft.Extensions.DependencyInjection;
using People.Business.Contacts;

namespace People.App.Configurations.Core
{
    internal static class BusinessConfiguration
    {
        internal static IServiceCollection AddBusinessLayer(this IServiceCollection services)
        {
            services.AddMediatR(typeof(Business.AssemblyReference).Assembly);

            services.AddSingleton<IRepository, InMemoryRepository>();

            return services;
        }
    }
}
