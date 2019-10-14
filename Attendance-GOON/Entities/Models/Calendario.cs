using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class Calendario
    {
        public Calendario()
        {
            Clase = new HashSet<Clase>();
        }

        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int NumeroDia { get; set; }

        public virtual ICollection<Clase> Clase { get; set; }
    }
}
