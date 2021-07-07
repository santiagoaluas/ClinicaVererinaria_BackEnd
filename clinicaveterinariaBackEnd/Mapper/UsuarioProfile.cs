using AutoMapper;
using clinicaveterinariaBackEnd.Dtos.UsuariosDtos;
using clinicaveterinariaBackEnd.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace clinicaveterinariaBackEnd.Mapper
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<Usuario, UsuarioDto>()
                       .ForMember(dest => dest.id,
                         opt => opt.MapFrom(o => o.IdUsuario))
                       .ForMember(dest => dest.cedula,
                         opt => opt.MapFrom(o => o.CedulaUsuario))
                       .ForMember(dest => dest.nombres,
                         opt => opt.MapFrom(o => o.NombresUsuario))
                       .ForMember(dest => dest.apellidos,
                         opt => opt.MapFrom(o => o.ApellidosUsuario))
                       .ForMember(dest => dest.cargo,
                         opt => opt.MapFrom(o => o.CargoUsuario))
                       .ForMember(dest => dest.email,
                         opt => opt.MapFrom(o => o.EmailUsuario))
                       .ForMember(dest => dest.telefono,
                         opt => opt.MapFrom(o => o.TelefonoUsuario))
                       .ForMember(dest => dest.empresa,
                         opt => opt.MapFrom(o => o.EmpresaUsuarios));

            CreateMap<UsuarioDto, Usuario> ()
                      .ForMember(dest => dest.IdUsuario,
                        opt => opt.MapFrom(o => o.id))
                      .ForMember(dest => dest.CedulaUsuario,
                        opt => opt.MapFrom(o => o.cedula))
                      .ForMember(dest => dest.NombresUsuario,
                        opt => opt.MapFrom(o => o.nombres))
                      .ForMember(dest => dest.ApellidosUsuario,
                        opt => opt.MapFrom(o => o.apellidos))
                      .ForMember(dest => dest.CargoUsuario,
                        opt => opt.MapFrom(o => o.cargo))
                      .ForMember(dest => dest.EmailUsuario,
                        opt => opt.MapFrom(o => o.email))
                      .ForMember(dest => dest.TelefonoUsuario,
                        opt => opt.MapFrom(o => o.telefono))
                      .ForMember(dest => dest.EmpresaUsuarios,
                        opt => opt.MapFrom(o => o.empresa));

            CreateMap<UsuarioGrabar, Usuario>()
                      .ForMember(dest => dest.CedulaUsuario,
                        opt => opt.MapFrom(o => o.cedula))
                      .ForMember(dest => dest.NombresUsuario,
                        opt => opt.MapFrom(o => o.nombres))
                      .ForMember(dest => dest.ApellidosUsuario,
                        opt => opt.MapFrom(o => o.apellidos))
                      .ForMember(dest => dest.CargoUsuario,
                        opt => opt.MapFrom(o => o.cargo))
                      .ForMember(dest => dest.EmailUsuario,
                        opt => opt.MapFrom(o => o.email))
                      .ForMember(dest => dest.TelefonoUsuario,
                        opt => opt.MapFrom(o => o.telefono))
                      .ForMember(dest => dest.EmpresaUsuarios,
                        opt => opt.MapFrom(o => o.empresa));
        }
    }
}
