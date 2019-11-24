using System;
using System.Collections.Generic;
using System.Text;
using Entities.DTO.Persona;

namespace Entities.DTO.Profesor
{
    public class CrearProfesorDTO
    {
        public string TipoIdentificacion { get; set; }
        public string NumeroIdentificacion { get; set; }
        public DateTime FechaIngreso { get; set; }
        public virtual Models.Persona Persona { get; set; }
    }
}
