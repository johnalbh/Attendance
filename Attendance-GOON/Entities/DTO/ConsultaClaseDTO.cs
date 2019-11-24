using System;
using System.Collections.Generic;
using System.Text;
using Entities.Models;

namespace Entities.DTO
{
    public class ConsultaClaseDTO
    {
        public int Id { get; set; }
        public int IdGrupo { get; set; }
        public int IdHorario { get; set; }
        public int IdFecha { get; set; }
        public bool? Asistencia { get; set; }
        public virtual CalendarioDTO Calendario { get; set; }
        public virtual GrupoHorarioDTO GrupoHorario { get; set; }
    }
}
