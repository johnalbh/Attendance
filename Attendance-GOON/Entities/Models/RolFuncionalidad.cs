using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class RolFuncionalidad
    {
        public int IdFuncionalidad { get; set; }
        public string IdRol { get; set; }

        public virtual Funcionalidad IdFuncionalidadNavigation { get; set; }
        public virtual AspNetRoles IdRolNavigation { get; set; }
    }
}
