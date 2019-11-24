using System;
using System.Collections.Generic;
using System.Text;
using Entities.Models;

namespace Entities.DTO.Grupo
{
    public class ConsultaGrupoSinMateriaDTO
    {
        public int Id { get; set; }
        public int NumGrupo { get; set; }
        public virtual ProfesorDTO Profesor { get; set; }
        public virtual ICollection<ConsultaGrupoHorarioSlimDTO> GrupoHorario { get; set; }
    }
}
