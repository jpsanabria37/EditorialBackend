using Application.DTOs.Users;
using Application.Interfaces;
using Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Services
{
    public class AccountService : IAccountService
    {
        public Task<Response<AuthenticationResponse>> AuthenticateAsync(AuthenticationRequest request, string ipAddress)
        {
         
        }

        public Task<Response<string>> RegisterAsync(RegisterRequest request, string origin)
        {
            
        }
    }
}
