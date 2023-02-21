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
    public class MarcaRepository : RepositoryBaseCustom, IRepository<Marca>
    {
        public MarcaRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Marca> AddAsync(Marca entity)
        {
            await _context.Set<Marca>().AddAsync(entity);
            await SaveAsync();

            return await _context.Set<Marca>().FirstOrDefaultAsync(e => e == entity);
        }

        public async Task DeleteAsync(Marca entity)
        {
            _context.Set<Marca>().Remove(entity);
            await SaveAsync();
        }

        public async Task<IEnumerable<Marca>> GetAllAsync()
        {
            return await _context.Set<Marca>().ToListAsync();
        }

        public async Task<Marca> GetByIdAsync(int id)
        {
            return await _context.Set<Marca>().FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task UpdateAsync(Marca entity)
        {
            _context.Set<Marca>().Update(entity);
            await SaveAsync();
        }
    }
}
