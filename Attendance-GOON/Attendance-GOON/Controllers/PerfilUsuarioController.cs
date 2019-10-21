﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Attendance_GOON.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerfilUsuarioController : ControllerBase
    {
        private UserManager<ApplicationUser> _userManager;
        public PerfilUsuarioController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        [Authorize]
        public async Task<Object> GetPerfilUsuario()
        {
            string userId = User.Claims.First(c => c.Type == "UserID").Value;
            var user = await _userManager.FindByIdAsync(userId);
            return new
            {
                user.FullName,
                user.Email,
                user.UserName
            };
        }

        [HttpGet]
        [Authorize(Roles = "Administrador")]
        [Route("ForAdmin")]
        public string GetForAdmin()
        {
            return "Web Method fo Admin";
        }
        [HttpGet]
        [Authorize(Roles = "Docente")]
        [Route("Docente")]
        public string GetForDocente()
        {
            return "Web Method fo Docente";
        }
        [HttpGet]
        [Authorize(Roles = "Administrador, Docente")]
        [Route("ForAdminOrDocente")]
        public string GetForAdminOrDocente()
        {
            return "Web Method Admin or Docente";
        }
    }
}