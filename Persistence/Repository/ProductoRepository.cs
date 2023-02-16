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
    public class ProductoRepository : RepositoryBaseCustom, IRepository<Producto>
    {
        public ProductoRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Task<Producto> AddAsync(Producto entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Producto entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Producto>> GetAllAsync()
        {
            return await _context.Set<Producto>().Include(p => p.Categoria).ToListAsync();
        }

        public Task<Producto> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Producto entity)
        {
            throw new NotImplementedException();
        }
    }
}
