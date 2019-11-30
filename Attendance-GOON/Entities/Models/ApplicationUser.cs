using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace Entities.Models
{
    public class ApplicationUser: IdentityUser
    {
        [Column(TypeName = "nvarchar(50)")]
        public string FullName { get; set; }

        public virtual Persona Persona { get; set; }
    }
}
