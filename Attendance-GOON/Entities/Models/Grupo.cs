using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class Grupo
    {
        public Grupo()
        {
            GrupoHorario = new HashSet<GrupoHorario>();
        }

        public int Id { get; set; }
        public int NumGrupo { get; set; }
        public int IdMateria { get; set; }
        public string TipoIdentificacionEmpleado { get; set; }
        public string NumeroIdentificacionEmpleado { get; set; }

        public virtual Materia IdMateriaNavigation { get; set; }
        public virtual Profesor Profesor { get; set; }
        public virtual ICollection<GrupoHorario> GrupoHorario { get; set; }
    }
}
