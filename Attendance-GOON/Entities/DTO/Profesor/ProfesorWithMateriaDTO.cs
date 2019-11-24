using System;
using System.Collections.Generic;
using System.Text;
using Entities.DTO.Grupo;
using Entities.DTO.Materia;
using Entities.DTO.Persona;

namespace Entities.DTO.Profesor
{
    public class ProfesorWithMateriaDTO
    {
        public string TipoIdentificacion { get; set; }
        public string NumeroIdentificacion { get; set; }
        public DateTime FechaIngreso { get; set; }
        public ICollection<ConsultaGrupoMateriaDTO> Grupo { get; set; }
    }
}
