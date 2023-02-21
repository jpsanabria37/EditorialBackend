using Application.DTOs;
<<<<<<< HEAD
using Application.Features.CategoriaVehiculo.Commands.CreateCategoriaVehiculoCommand;
using Application.Features.Clientes.Commands.CreateClientCommand;
<<<<<<< HEAD
using Application.Features.Servicios.Commands.CreateServicioCommand;
=======
using Application.Features.Marca.Commands.CreateMarcaCommand;
>>>>>>> febf07acb1a4761cc051f95d44f6b76dec5cea8f
=======
using Application.DTOs.TipoDocumentos;
using Application.Features.Clientes.Commands.CreateClientCommand;
using Application.Features.TipoDocumentos.Commands.CreateTipoDocumentoCommand;
>>>>>>> feature/YennerEdition
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
<<<<<<< HEAD
            CreateMap<CreateCategoriaVehiculoCommand, CategoriaVehiculo>();
=======
<<<<<<< HEAD
<<<<<<< HEAD
            CreateMap<CreateServicioCommand, Servicio>();
=======

            CreateMap<CreateMarcaCommand, Marca>();
=======
            CreateMap<CreateTipoDocumentoCommand, TipoDocumento>();
>>>>>>> 74f00a0a5e4a3f9d4d003e1bde112cd2a2eee654
            #endregion

            #region
            CreateMap<TipoDocumento, TipoDocumentoDto>();
>>>>>>> feature/YennerEdition
            #endregion
            #region CategoriaVehiculo
<<<<<<< HEAD
            CreateMap<CategoriaVehiculo, CategoriaVehiculoDto>();            
=======
            CreateMap<CategoriaVehiculo, CategoriaVehiculoDto>();
            CreateMap<CreateCategoriaVehiculoCommand, CategoriaVehiculo>();
>>>>>>> 74f00a0a5e4a3f9d4d003e1bde112cd2a2eee654
            #endregion
            #region Marca
            CreateMap<Marca, MarcaDto>();            
>>>>>>> febf07acb1a4761cc051f95d44f6b76dec5cea8f
            #endregion

            #region Servicio
            CreateMap<Servicio, ServicioDto>();
            #endregion


        }
    }
}
