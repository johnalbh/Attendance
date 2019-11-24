using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class FuncionalidadRoles
    {
        public int IdFuncionalidad { get; set; }
        public string IdRoles { get; set; }

        public virtual Funcionalidad IdFuncionalidadNavigation { get; set; }
    }
}
