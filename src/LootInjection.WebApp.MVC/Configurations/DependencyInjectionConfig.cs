using LootInjection.Business.Interfaces.Notification;
using LootInjection.Business.Interfaces.Repository;
using LootInjection.Business.Interfaces.Service;
using LootInjection.Business.Notification;
using LootInjection.Business.Services;
using LootInjection.Data;
using LootInjection.Data.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace LootInjection.WebApp.MVC.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<Context>();

            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IContaRepository, ContaRepository>();
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();

            services.AddScoped<INotificator, Notificador>();
            services.AddScoped<ICategoriaService, CategoriaService>();
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IContaService, ContaService>();

            return services;
        }
    }
}