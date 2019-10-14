using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class Persona
    {
        public string TipoIdentificacion { get; set; }
        public string NumeroIdentificacion { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string UrlFoto { get; set; }
        public DateTime FechaNacimiento { get; set; }

        public virtual Profesor Profesor { get; set; }
    }
}
