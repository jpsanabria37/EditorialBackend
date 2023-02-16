using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using Application.Interfaces;

namespace Persistence.Repository
{
    public class ClienteRepository : RepositoryBaseCustom, IRepository<Cliente>, IClienteRepository
    {
        public ClienteRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Cliente> AddAsync(Cliente entity)
        {
            await _context.Set<Cliente>().AddAsync(entity);
            await SaveAsync();

            return await _context.Set<Cliente>().FirstOrDefaultAsync(e => e == entity);
        }

        public async Task DeleteAsync(Cliente entity)
        {
            _context.Set<Cliente>().Remove(entity);
            await SaveAsync();

        }

        public async Task<bool> ExisteEmail(string email)
        {
            return await _context.Set<Cliente>().AnyAsync(x => x.Email == email);
        }

        public async Task<IEnumerable<Cliente>> GetAllAsync()
        {
            return await _context.Set<Cliente>().ToListAsync();
        }

        public async Task<Cliente> GetByIdAsync(int id)
        {
            return await _context.Set<Cliente>().FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task UpdateAsync(Cliente entity)
        {
            _context.Set<Cliente>().Update(entity);
            await SaveAsync();
        }
    }
}
