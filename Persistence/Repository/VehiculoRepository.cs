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
    public class VehiculoRepository : RepositoryBaseCustom, IRepository<Vehiculo>
    {
        public VehiculoRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Vehiculo> AddAsync(Vehiculo entity)
        {
            await _context.Set<Vehiculo>().AddAsync(entity);
            await SaveAsync();

            return await _context.Set<Vehiculo>().FirstOrDefaultAsync(e => e == entity);
        }

        public async Task DeleteAsync(Vehiculo entity)
        {
            _context.Set<Vehiculo>().Remove(entity);
            await SaveAsync();
        }

        public async Task<IEnumerable<Vehiculo>> GetAllAsync()
        {
            return await _context.Set<Vehiculo>().ToListAsync();
        }

        public async Task<Vehiculo> GetByIdAsync(int id)
        {
            return await _context.Set<Vehiculo>().Include(v => v.Cliente).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task UpdateAsync(Vehiculo entity)
        {
            _context.Set<Vehiculo>().Update(entity);
            await SaveAsync();
        }
    }
}
