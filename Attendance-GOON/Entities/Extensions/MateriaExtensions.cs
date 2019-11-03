using System;
using System.Collections.Generic;
using System.Text;
using Entities.Models;

namespace Entities.Extensions
{
    public static class MateriaExtensions
    {
        public static void Map(this Materia dbMateria, Materia materia)
        {
            dbMateria.Nombre = materia.Nombre;
            dbMateria.Grupo = materia.Grupo;
        }
    }
}
