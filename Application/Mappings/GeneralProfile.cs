using Application.DTOs;
using Application.DTOs.Cliente;
using Application.DTOs.Vehiculo;
using Application.Features.Clientes.Commands.CreateClientCommand;
using Application.Features.Reparaciones.Commands.CreateCommandReparacion;
using Application.Features.Servicios.Commands.CreateServicioCommand;
using Application.Features.Vehiculo.Commands.CreateVehiculoCommand;
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
            CreateMap<CreateServicioCommand, Servicio>();
            CreateMap<CreateVehiculoCommand, Vehiculo>();
            CreateMap<CreateCommandReparacion, Reparacion>();
            #endregion
            #region Cliente
            CreateMap<Cliente, ClienteDto>();
            CreateMap<Cliente, ClienteIncludeTipoVehiculoDto>();
            #endregion
            #region TipoDocumento
            CreateMap<TipoDocumento, TipoDocumentoDto>();
            #endregion
            #region CategoriaVehiculo
            CreateMap<CategoriaVehiculo, CategoriaVehiculoDto>();
            #endregion
           
            #region Servicio
            CreateMap<Servicio, ServicioDto>();
            #endregion
            #region Vehiculo
            CreateMap<Vehiculo, VehiculoDto>();
            CreateMap<Vehiculo, VehiculoIncludeClienteDto>();
            #endregion


        }
    }
}
