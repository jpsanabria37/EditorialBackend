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

        public async Task<bool> NoExisteClienteConMismoTipoYNumeroDocumento(int tipoDocumentoId, string numeroDocumento)
        {
            // Verificar si existe algún cliente con los mismos valores de tipo y número de documento
            return await _context.Set<Cliente>().AllAsync(c => c.TipoDocumentoId != tipoDocumentoId || c.NumeroDocumento != numeroDocumento);

        }



        public async Task<IEnumerable<Cliente>> GetAllAsync()
        {
            return await _context.Set<Cliente>().Include(x => x.TipoDocumento).ToListAsync();
        }

        public async Task<Cliente> GetByIdAsync(int id)
        {
            return await _context.Set<Cliente>().Include(c => c.TipoDocumento).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task UpdateAsync(Cliente entity)
        {
            _context.Set<Cliente>().Update(entity);
            await SaveAsync();
        }


        public async Task<Cliente> GetByNumeroDocumentoTipoDocumentoAsync(string numeroDocumento, int tipoDocumento)
        {
            return await _context.Set<Cliente>()
                .FirstOrDefaultAsync(c => c.NumeroDocumento == numeroDocumento && c.TipoDocumentoId == tipoDocumento);
        }


        public async Task<Cliente> ObtenerPorEmail(string email)
        {
            return await _context.Clientes.FirstOrDefaultAsync(c => c.Email == email);
        }
    }
}
