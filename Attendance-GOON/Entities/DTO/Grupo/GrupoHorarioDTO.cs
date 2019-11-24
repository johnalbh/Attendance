using System;
using System.Collections.Generic;
using System.Text;
using Entities.Models;

namespace Entities.DTO
{
    public class GrupoHorarioDTO
    {
        public int IdGrupo { get; set; }
        public int IdHorario { get; set; }

        public virtual ConsultaGrupoDTO Grupo { get; set; }
        public virtual HorarioConDiaDTO Horario { get; set; }

    }
}
