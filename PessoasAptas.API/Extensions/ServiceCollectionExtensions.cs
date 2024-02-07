using CriteriosAptas.Infrastructure.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;
using PessoasAptas.Core.Repositories;
using PessoasAptas.Infrastructure.Persistence.Repositories;

namespace PessoasAptas.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<ICriterioRepository, CriterioRepository>();
            services.AddScoped<IPessoaRepository, PessoaRepository>();
            services.AddScoped<IPessoaCriterioRepository, PessoaCriterioRepository>();

            return services;
        }
    }
}
