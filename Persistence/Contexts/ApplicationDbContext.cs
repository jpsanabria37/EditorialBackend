using Application.Interfaces;
using Domain.Common;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Persistence.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IDateTimeService _dataTime;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IDateTimeService dateTime) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            _dataTime= dateTime;
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Producto> Productos { get; set; }
<<<<<<< HEAD
        public DbSet<Servicio> Servicios { get; set; }
=======
        public DbSet<CategoriaVehiculo> CategoriaVehiculos { get; set; }
>>>>>>> febf07acb1a4761cc051f95d44f6b76dec5cea8f

        public DbSet<TipoDocumento> TipoDocumentos { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableBaseEntity>())
            {
                switch(entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Created = _dataTime.NowUtc;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModified = _dataTime.NowUtc;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
