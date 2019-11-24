using System;
using System.Collections.Generic;
using System.Text;
using Entities.Models;

namespace Entities.DTO
{
    public class CreateGrupoDTO
    {
        public int NumGrupo { get; set; }
        public int IdMateria { get; set; }
        public string TipoIdentificacionEmpleado { get; set; }
        public string NumeroIdentificacionEmpleado { get; set; }

        public virtual Models.Materia IdMateriaNavigation { get; set; }
        public virtual Models.Profesor Profesor { get; set; }
        public virtual ICollection<GrupoHorario> GrupoHorario { get; set; }

        public CreateGrupoDTO( int numGrupo, int idMateria, string tipoIdentificacionEmpleado, string numeroIdentificacionEmpleado, Models.Materia idMateriaNavigation, Models.Profesor profesor, ICollection<GrupoHorario> grupoHorario)
        {
            NumGrupo = numGrupo;
            IdMateria = idMateria;
            TipoIdentificacionEmpleado = tipoIdentificacionEmpleado;
            NumeroIdentificacionEmpleado = numeroIdentificacionEmpleado;
            IdMateriaNavigation = idMateriaNavigation;
            Profesor = profesor;
            GrupoHorario = grupoHorario;
        }
    }
}
