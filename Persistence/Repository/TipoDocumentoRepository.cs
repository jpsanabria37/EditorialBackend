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
    public class TipoDocumentoRepository : RepositoryBaseCustom, IRepository<TipoDocumento>
    {
        public TipoDocumentoRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<TipoDocumento> AddAsync(TipoDocumento entity)
        {
            await _context.Set<TipoDocumento>().AddAsync(entity);
            await SaveAsync();

            return await _context.Set<TipoDocumento>().FirstOrDefaultAsync(e => e == entity);
        }

        public async Task DeleteAsync(TipoDocumento entity)
        {
            _context.Set<TipoDocumento>().Remove(entity);
            await SaveAsync();
        }

        public async Task<IEnumerable<TipoDocumento>> GetAllAsync()
        {
            return await _context.Set<TipoDocumento>().ToListAsync();
        }

        public async Task<TipoDocumento> GetByIdAsync(int id)
        {
            return await _context.Set<TipoDocumento>().FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task UpdateAsync(TipoDocumento entity)
        {
            _context.Set<TipoDocumento>().Update(entity);
            await SaveAsync();
        }
    }
}
