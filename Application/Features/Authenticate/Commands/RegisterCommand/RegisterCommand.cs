﻿using Application.DTOs.Users;
using Application.Interfaces;
using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Authenticate.Commands.RegisterCommand
{
    public class RegisterCommand : IRequest<Response<string>>
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Username { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
        public string Email { get; set; }

        public string Origin { get; set; }
    }

    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, Response<string>>
    {
        private readonly IAccountService _accountService;

        public RegisterCommandHandler(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public async Task<Response<string>> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            return await _accountService.RegisterAsync(new RegisterRequest
            {
                Nombre = request.Nombre,
                Apellido = request.Apellido,
                UserName = request.Username,
                Password = request.Password,
                ConfirmPassword = request.ConfirmPassword,
                Email = request.Email,
            }, request.Origin);
        }
    }
}