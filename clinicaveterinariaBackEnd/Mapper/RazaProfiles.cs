using AutoMapper;
using clinicaveterinariaBackEnd.Dtos.RazaDtos;
using clinicaveterinariaBackEnd.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace clinicaveterinariaBackEnd.Mapper
{
    public class RazaProfiles : Profile
    {
        public RazaProfiles()
        {
            CreateMap<Raza, RazaDto>()
                        .ForMember(dest => dest.id,
                          opt => opt.MapFrom(o => o.IdRaza))
                        .ForMember(dest => dest.nombre,
                          opt => opt.MapFrom(o => o.NombreRaza))
                        .ForMember(dest => dest.descripcion,
                          opt => opt.MapFrom(o => o.DescripcionRaza))
                        .ForMember(dest => dest.mascotas,
                          opt => opt.MapFrom(o => o.Mascota));
        }
    }
}
