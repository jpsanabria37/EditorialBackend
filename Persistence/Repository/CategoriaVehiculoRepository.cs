using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repository
{
    public class CategoriaVehiculoRepository : RepositoryBaseCustom, IRepository<CategoriaVehiculo>
    {
        public CategoriaVehiculoRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<CategoriaVehiculo> AddAsync(CategoriaVehiculo entity)
        {
            await _context.Set<CategoriaVehiculo>().AddAsync(entity);
            await SaveAsync();

            return await _context.Set<CategoriaVehiculo>().FirstOrDefaultAsync(e => e == entity);
        }

        public Task DeleteAsync(CategoriaVehiculo entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CategoriaVehiculo>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<CategoriaVehiculo> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(CategoriaVehiculo entity)
        {
            throw new NotImplementedException();
        }
    }
}
