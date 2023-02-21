using Application.DTOs;
using Application.DTOs.TipoDocumentos;
using Application.Features.Clientes.Commands.CreateClientCommand;
using Application.Features.TipoDocumentos.Commands.CreateTipoDocumentoCommand;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            #region Cliente
            CreateMap<Cliente, ClienteDto>();
            #endregion
            #region Commands
            CreateMap<CreateClientCommand, Cliente>()
             .ForMember(dest => dest.Edad, opt => opt.MapFrom(src =>
                 new DateTime(DateTime.Now.Subtract(src.FechaNacimiento).Ticks).Year - 1));
            CreateMap<CreateTipoDocumentoCommand, TipoDocumento>();
            #endregion

            #region
            CreateMap<TipoDocumento, TipoDocumentoDto>();
            #endregion
        }
    }
}
