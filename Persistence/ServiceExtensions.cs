using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;
using Persistence.Repository;
using CloudSql;

namespace Persistence
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddPersistenceInfraestructure(this IServiceCollection services, IConfiguration configuration)
        {

           /* var connectionString = MySqlTcp.NewMysqlTCPConnectionString().ConnectionString;

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors()
                    );
           */
            var connection = configuration.GetConnectionString("DATABASE_URL");
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 28));

            services.AddDbContext<ApplicationDbContext>(opts => opts.UseMySql(connection, serverVersion, b => b.MigrationsAssembly("WebApi")));


            #region Repositories
            services.AddTransient(typeof(IRepositoryAsync<>), typeof(MyRepositoryAsync<>));
            services.AddTransient<IRepository<Cliente>, ClienteRepository>();
            services.AddTransient<IRepository<Producto>, ProductoRepository>();
            services.AddTransient<IRepository<CategoriaVehiculo>, CategoriaVehiculoRepository>();
            services.AddTransient<IClienteRepository, ClienteRepository>();
            services.AddTransient<IRepository<Servicio>, ServicioRepository>();
            services.AddTransient<IRepository<Marca>, MarcaRepository>();
            services.AddTransient<IRepository<TipoDocumento>,TipoDocumentoRepository>();
            services.AddTransient<IRepository<Vehiculo>, VehiculoRepository>();
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
