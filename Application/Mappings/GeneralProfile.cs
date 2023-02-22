using Application.DTOs;
 
using Application.Features.CategoriaVehiculo.Commands.CreateCategoriaVehiculoCommand;
using Application.Features.Clientes.Commands.CreateClientCommand;

using Application.Features.Servicios.Commands.CreateServicioCommand;

using Application.Features.Marca.Commands.CreateMarcaCommand;


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

            CreateMap<CreateCategoriaVehiculoCommand, CategoriaVehiculo>();

            CreateMap<CreateServicioCommand, Servicio>();


            CreateMap<CreateMarcaCommand, Marca>();

            CreateMap<CreateTipoDocumentoCommand, TipoDocumento>();

            #endregion

            #region
            CreateMap<TipoDocumento, TipoDocumentoDto>();
            #endregion
            #region CategoriaVehiculo

            CreateMap<CategoriaVehiculo, CategoriaVehiculoDto>();            

            CreateMap<CategoriaVehiculo, CategoriaVehiculoDto>();
            CreateMap<CreateCategoriaVehiculoCommand, CategoriaVehiculo>();

            #endregion
            #region Marca
            CreateMap<Marca, MarcaDto>();            
            #endregion

            #region Servicio
            CreateMap<Servicio, ServicioDto>();
            #endregion


        }
    }
}
