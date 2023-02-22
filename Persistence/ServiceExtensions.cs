using Application.Features.Clientes.Commands.CreateClientCommand;
using Application.Interfaces;
using Domain.Entities;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;
using Persistence.Repository;
using Persistence.Validaciones;

namespace Persistence
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddPersistenceInfraestructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(
                options => options.UseMySQL(
                    configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly("WebApi"))
                );

            #region Repositories
            services.AddTransient(typeof(IRepositoryAsync<>), typeof(MyRepositoryAsync<>));
            services.AddTransient<IRepository<Cliente>, ClienteRepository>();
            services.AddTransient<IRepository<Producto>, ProductoRepository>();
            services.AddTransient<IRepository<CategoriaVehiculo>, CategoriaVehiculoRepository>();
            services.AddTransient<IClienteRepository, ClienteRepository>();
            services.AddTransient<IRepository<Servicio>, ServicioRepository>();


            services.AddTransient<IRepository<Marca>, MarcaRepository>();


            services.AddTransient <IRepository<TipoDocumento>,TipoDocumentoRepository>();
            #endregion

            #region Caching
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = configuration.GetValue<string>("Caching:RedisConnection");
            });
            #endregion

            //services.AddTransient<ClienteEmailUnicoValidator>();

            return services;

        }  
    }
}
