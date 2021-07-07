using AutoMapper;
using clinicaveterinariaBackEnd.Dtos.ClienteDtos;
using clinicaveterinariaBackEnd.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace clinicaveterinariaBackEnd.Mapper
{
    public class ClienteProfiles : Profile
    {
        public ClienteProfiles()
        {
            CreateMap<Cliente, ClienteDto>()
                       .ForMember(dest => dest.id,
                         opt => opt.MapFrom(o => o.IdCliente))
                       .ForMember(dest => dest.cedula,
                         opt => opt.MapFrom(o => o.CedulaCliente))
                       .ForMember(dest => dest.nombre,
                         opt => opt.MapFrom(o => o.NombreCliente))
                       .ForMember(dest => dest.apellidos,
                         opt => opt.MapFrom(o => o.ApellidoCliente))
                       .ForMember(dest => dest.direccion,
                         opt => opt.MapFrom(o => o.DireccionCliente))
                       .ForMember(dest => dest.email,
                         opt => opt.MapFrom(o => o.EmailCliente))
                       .ForMember(dest => dest.Mascotas,
                         opt => opt.MapFrom(o => o.Mascotas));

            CreateMap<ClienteDto, Cliente> ()
                       .ForMember(dest => dest.IdCliente,
                         opt => opt.MapFrom(o => o.id))
                       .ForMember(dest => dest.CedulaCliente,
                         opt => opt.MapFrom(o => o.cedula))
                       .ForMember(dest => dest.NombreCliente,
                         opt => opt.MapFrom(o => o.nombre))
                       .ForMember(dest => dest.ApellidoCliente,
                         opt => opt.MapFrom(o => o.apellidos))
                       .ForMember(dest => dest.DireccionCliente,
                         opt => opt.MapFrom(o => o.direccion))
                       .ForMember(dest => dest.EmailCliente,
                         opt => opt.MapFrom(o => o.email))
                       .ForMember(dest => dest.Mascotas,
                         opt => opt.MapFrom(o => o.Mascotas));
        }
    }
}
