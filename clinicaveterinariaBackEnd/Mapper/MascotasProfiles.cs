using AutoMapper;
using clinicaveterinariaBackEnd.Dtos.MascotaDtos;
using clinicaveterinariaBackEnd.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace clinicaveterinariaBackEnd.Mapper
{
    public class MascotasProfiles : Profile
    {
        public MascotasProfiles()
        {
            CreateMap<CreateMascotaDto, Mascota>()
                        .ForMember(dest => dest.IdPaciente,
                          opt => opt.MapFrom(o => o.id))
                        .ForMember(dest => dest.NombrePaciente,
                          opt => opt.MapFrom(o => o.nombre))
                        .ForMember(dest => dest.EspeciePaciente,
                          opt => opt.MapFrom(o => o.especie))
                        .ForMember(dest => dest.SexoPaciente,
                          opt => opt.MapFrom(o => o.sexo))
                        .ForMember(dest => dest.PesoPaciente,
                          opt => opt.MapFrom(o => o.peso))
                        .ForMember(dest => dest.Cliente,
                          opt => opt.MapFrom(o => o.cliente))
                        .ForMember(dest => dest.Alergias,
                          opt => opt.MapFrom(o => o.alergias));

        }
    }
}
