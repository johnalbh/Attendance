using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class Horario
    {
        public Horario()
        {
            GrupoHorario = new HashSet<GrupoHorario>();
        }

        public int Id { get; set; }
        public int Dia { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }

        public virtual ICollection<GrupoHorario> GrupoHorario { get; set; }
    }
}
