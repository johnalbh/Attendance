using System;
using System.Collections.Generic;
using System.Text;
using Entities.Models;

namespace Entities.DTO
{
    public class ProfesorDTO
    {

        public string TipoIdentificacion { get; set; }
        public string NumeroIdentificacion { get; set; }
        public DateTime FechaIngreso { get; set; }

        public virtual Persona Persona { get; set; }
        public virtual ICollection<Grupo> Grupo { get; set; }

        public ProfesorDTO(string tipoIdentificacion, string numeroIdentificacion, DateTime fechaIngreso, Persona persona, ICollection<Grupo> grupo)
        {
            TipoIdentificacion = tipoIdentificacion;
            NumeroIdentificacion = numeroIdentificacion;
            FechaIngreso = fechaIngreso;
            Persona = persona;
            Grupo = grupo;
        }
    }
}
