using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class Profesor
    {
        public Profesor()
        {
            Grupo = new HashSet<Grupo>();
        }

        public string TipoIdentificacion { get; set; }
        public string NumeroIdentificacion { get; set; }
        public DateTime FechaIngreso { get; set; }

        public virtual Persona Persona { get; set; }
        public virtual ICollection<Grupo> Grupo { get; set; }
    }
}
