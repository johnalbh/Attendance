using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTO.Profesor
{
    public class UpdateProfesorDTO
    {
        public DateTime FechaIngreso { get; set; }
        public virtual UpdatePersonaDTO Persona { get; set; }
    }
}
