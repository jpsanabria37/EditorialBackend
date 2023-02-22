using Application.DTOs;
<<<<<<< HEAD
using Application.DTOs.TipoDocumentos;
using Application.Features.CategoriaVehiculo.Commands.CreateCategoriaVehiculoCommand;
using Application.Features.Clientes.Commands.CreateClientCommand;
using Application.Features.Marca.Commands.CreateMarcaCommand;
using Application.Features.Servicios.Commands.CreateServicioCommand;
using Application.Features.TipoDocumentos.Commands.CreateTipoDocumentoCommand;
=======
 
using Application.Features.CategoriaVehiculo.Commands.CreateCategoriaVehiculoCommand;
using Application.Features.Clientes.Commands.CreateClientCommand;

using Application.Features.Servicios.Commands.CreateServicioCommand;

using Application.Features.Marca.Commands.CreateMarcaCommand;


using Application.DTOs.TipoDocumentos;
using Application.Features.Clientes.Commands.CreateClientCommand;
using Application.Features.TipoDocumentos.Commands.CreateTipoDocumentoCommand;

>>>>>>> b87abe92cc000a20ceff5524ae795b9d8c14cf1b
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
           
            #region Commands
            CreateMap<CreateClientCommand, Cliente>()
             .ForMember(dest => dest.Edad, opt => opt.MapFrom(src =>
                 new DateTime(DateTime.Now.Subtract(src.FechaNacimiento).Ticks).Year - 1));
<<<<<<< HEAD
            CreateMap<CreateCategoriaVehiculoCommand, CategoriaVehiculo>();
            CreateMap<CreateServicioCommand, Servicio>();
            CreateMap<CreateMarcaCommand, Marca>();
            CreateMap<CreateTipoDocumentoCommand, TipoDocumento>();
=======

            CreateMap<CreateCategoriaVehiculoCommand, CategoriaVehiculo>();

            CreateMap<CreateServicioCommand, Servicio>();


            CreateMap<CreateMarcaCommand, Marca>();

            CreateMap<CreateTipoDocumentoCommand, TipoDocumento>();

>>>>>>> b87abe92cc000a20ceff5524ae795b9d8c14cf1b
            #endregion
            #region Cliente
            CreateMap<Cliente, ClienteDto>();
            #endregion
            #region TipoDocumento
            CreateMap<TipoDocumento, TipoDocumentoDto>();
            #endregion
            #region CategoriaVehiculo
<<<<<<< HEAD
            CreateMap<CategoriaVehiculo, CategoriaVehiculoDto>();            
=======

            CreateMap<CategoriaVehiculo, CategoriaVehiculoDto>();            

            CreateMap<CategoriaVehiculo, CategoriaVehiculoDto>();
            CreateMap<CreateCategoriaVehiculoCommand, CategoriaVehiculo>();

>>>>>>> b87abe92cc000a20ceff5524ae795b9d8c14cf1b
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
