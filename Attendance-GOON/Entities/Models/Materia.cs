using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class Materia
    {
        public Materia()
        {
            Grupo = new HashSet<Grupo>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Grupo> Grupo { get; set; }
    }
}
