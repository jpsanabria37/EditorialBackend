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
    public class ServicioRepository : RepositoryBaseCustom, IRepository<Servicio>
    {
        public ServicioRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Servicio> AddAsync(Servicio entity)
        {
            await _context.Set<Servicio>().AddAsync(entity);
            await SaveAsync();

            return await _context.Set<Servicio>().FirstOrDefaultAsync(e => e == entity);
        }

        public async Task DeleteAsync(Servicio entity)
        {
            _context.Set<Servicio>().Remove(entity);
            await SaveAsync();
        }

        public async Task<IEnumerable<Servicio>> GetAllAsync()
        {
            return await _context.Set<Servicio>().Include(s => s.CategoriaVehiculo).ToListAsync();
        }

        public async Task<Servicio> GetByIdAsync(int id)
        {
            return await _context.Set<Servicio>().FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task UpdateAsync(Servicio entity)
        {
            _context.Set<Servicio>().Update(entity);
            await SaveAsync();
        }
    }
}
