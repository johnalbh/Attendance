using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Entities.DTO;
using Entities.DTO.Clase;
using Entities.DTO.Grupo;
using Entities.DTO.Materia;
using Entities.DTO.Persona;
using Entities.DTO.Profesor;
using Entities.Models;

namespace Attendance_GOON
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Grupo, GrupoDTO>();
            CreateMap<GrupoDTO, Grupo>();
            CreateMap<CreateGrupoDTO, Grupo>();
            CreateMap<Dominio, DominioDTO>();
            CreateMap<DominioDTO, Dominio>();
            CreateMap<Parametro, ParametroDTO>();
            CreateMap<ParametroDTO, Parametro>();
            CreateMap<Profesor, ProfesorDTO>();
            CreateMap<Clase, ClaseDTO>();
            CreateMap<GrupoHorario, GrupoHorarioDTO>()
                .ForMember(dest => dest.Grupo, opt => opt.MapFrom(src => src.IdGrupoNavigation))
                .ForMember(dest => dest.Horario, opt => opt.MapFrom(src => src.IdHorarioNavigation)); 
            ; ; ;
            CreateMap<Calendario, CalendarioDTO>();
            CreateMap<Calendario, ConsultaCalendarioSlimDTO>();
            /* DTO de Consulta */
            CreateMap<Clase, ConsultaClaseDTO>().ForMember(dest => dest.Calendario, opt => opt.MapFrom(src => src.IdFechaNavigation)); ;
            CreateMap<Clase, ConsultaClaseSlimDTO>()
                .ForMember(dest => dest.IdClase, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.FechaClase, opt => opt.MapFrom(src => src.IdFechaNavigation.Fecha.Date))
                .ForMember(dest => dest.Materia, opt => opt.MapFrom(src => src.IdNavigation.IdGrupoNavigation.IdMateriaNavigation.Nombre))
                .ForMember(dest => dest.HoraInicio, opt => opt.MapFrom(src => src.IdNavigation.IdHorarioNavigation.HoraInicio))
                .ForMember(dest => dest.HoraFin, opt => opt.MapFrom(src => src.IdNavigation.IdHorarioNavigation.HoraFin))
                .ForMember(dest => dest.Grupo, opt => opt.MapFrom(src => src.IdNavigation.IdGrupo))
                .ForMember(dest => dest.profesor, opt => opt.MapFrom(src => src.IdNavigation.IdGrupoNavigation.Profesor.Persona))
                ; ;
            CreateMap<Clase, ConsultaOnlyClaseSlimDTO>()
                .ForMember(dest => dest.IdClase, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.FechaClase, opt => opt.MapFrom(src => src.IdFechaNavigation.Fecha.Date))
                .ForMember(dest => dest.Materia, opt => opt.MapFrom(src => src.IdNavigation.IdGrupoNavigation.IdMateriaNavigation.Nombre))
                .ForMember(dest => dest.HoraInicio, opt => opt.MapFrom(src => src.IdNavigation.IdHorarioNavigation.HoraInicio))
                .ForMember(dest => dest.HoraFin, opt => opt.MapFrom(src => src.IdNavigation.IdHorarioNavigation.HoraFin))
                .ForMember(dest => dest.Grupo, opt => opt.MapFrom(src => src.IdNavigation))
                ; ;
            CreateMap<Grupo, ConsultaGrupoDTO>()
                    .ForMember(dest => dest.Materia, opt => opt.MapFrom(src => src.IdMateriaNavigation));
            CreateMap<Materia, ConsultaMateriaDTO>();
            CreateMap<Grupo, ConsultaGrupoDTO>();
            CreateMap<Persona, ConsultarPersonaDTO>();
            CreateMap<Persona, ConsultarPersonaSlimDTO>();
            CreateMap<Grupo, ConsultaGrupoMateriaDTO>();
            CreateMap<Grupo, ConsultaGrupoSinMateriaDTO>();
            CreateMap<GrupoHorario, ConsultaGrupoHorarioSlimDTO>()
                .ForMember( dest => dest.Horario, opt => opt.MapFrom(src => src.IdHorarioNavigation) );
                ;
            CreateMap<Materia, ConsultarMateriaGrupoSlimDTO>();
            CreateMap<Horario, HorarioConDiaDTO>();
            CreateMap<Materia, ConsultarMateriaSlimDTO>();
            CreateMap<Profesor, ProfesorWithMateriaDTO>();
            CreateMap<GrupoHorario, ConsultarGrupoHorarioGrupoSlimDTO>()
                .ForMember(dest => dest.DetalleGrupo, opt => opt.MapFrom(src => src.IdGrupoNavigation)); ;
            CreateMap<Grupo, ConsultarGrupoSimpleSlimDTO>()

                ;
            /* DTO Creación */
            CreateMap<CrearProfesorDTO, Profesor>();
            /* Actualizar */
            CreateMap<UpdateProfesorDTO, Profesor>();
            CreateMap<UpdatePersonaDTO, Persona> ();
            CreateMap<UpdateGrupoDTO, Grupo>();
            CreateMap<MarcarClaseDTO, Clase>();

        }
    }
}
