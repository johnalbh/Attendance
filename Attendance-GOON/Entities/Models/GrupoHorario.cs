using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class GrupoHorario
    {
        public GrupoHorario()
        {
            Clase = new HashSet<Clase>();
        }

        public int IdGrupo { get; set; }
        public int IdHorario { get; set; }
        public bool Asistencia { get; set; }

        public virtual Grupo IdGrupoNavigation { get; set; }
        public virtual Horario IdHorarioNavigation { get; set; }
        public virtual ICollection<Clase> Clase { get; set; }
    }
}
