using Application.Features.Clientes.Commands.CreateClientCommand;
using Domain.Entities;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Validaciones
{
    public class ClienteEmailUnicoValidator 
    {
        private readonly ApplicationDbContext _context;

        public ClienteEmailUnicoValidator(ApplicationDbContext context)
        {
            _context = context;

            
        }

        private async Task<bool> BeUnique(CreateClientCommand cliente, string email, CancellationToken cancellationToken)
        {
            return !await _context.Clientes.AnyAsync(c => c.Email == email);
        }
    }
}
