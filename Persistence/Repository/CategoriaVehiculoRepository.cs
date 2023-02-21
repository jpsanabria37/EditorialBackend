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

        public async Task<IEnumerable<CategoriaVehiculo>> GetAllAsync()
        {
            return await _context.Set<CategoriaVehiculo>().ToListAsync();
        }

        public async Task<CategoriaVehiculo> GetByIdAsync(int id)
        {
            return await _context.Set<CategoriaVehiculo>().FirstOrDefaultAsync(c => c.Id == id);
        }

        public Task UpdateAsync(CategoriaVehiculo entity)
        {
            throw new NotImplementedException();
        }
    }
}
