using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;


namespace Persistence.Repository
{
    public class ReparacionRepository : RepositoryBaseCustom, IRepository<Reparacion>
    {
        public ReparacionRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Reparacion> AddAsync(Reparacion entity)
        {
            await _context.Set<Reparacion>().AddAsync(entity);
            await SaveAsync();

            return await _context.Set<Reparacion>().FirstOrDefaultAsync(e => e == entity);
        }

        public Task DeleteAsync(Reparacion entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Reparacion>> GetAllAsync()
        {
            return await _context.Set<Reparacion>().ToListAsync();
        }

        public Task<Reparacion> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Reparacion entity)
        {
            throw new NotImplementedException();
        }
    }
}
