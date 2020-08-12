using LootInjection.Business.Interfaces;
using LootInjection.Data;
using LootInjection.Data.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace LootInjection.WebApp.MVC.Configurations
{
    public static class DependencyInjection
    {
        public static IServiceCollection ResolveDependencies(this ServiceCollection services)
        {
            services.AddScoped<Context>();

            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IContaRepository, ContaRepository>();
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();

            return services;
        }
    }
}