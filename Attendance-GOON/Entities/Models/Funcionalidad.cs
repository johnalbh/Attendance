using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class Funcionalidad
    {
        public Funcionalidad()
        {
            FuncionalidadRoles = new HashSet<FuncionalidadRoles>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Url { get; set; }
        public string Tipo { get; set; }
        public int Orden { get; set; }

        public virtual ICollection<FuncionalidadRoles> FuncionalidadRoles { get; set; }
    }
}
