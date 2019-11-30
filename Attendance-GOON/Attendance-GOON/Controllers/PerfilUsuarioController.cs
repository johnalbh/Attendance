using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using Entities.DTO.Persona;
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
        private IRepositoryWrapper _repository;
        private IMapper _mapper;
        private ILoggerManager _logger;
        public PerfilUsuarioController(UserManager<ApplicationUser> userManager, ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _userManager = userManager;
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }
        [HttpGet]
        [Authorize]
        public async Task<Object> GetPerfilUsuario()
        {
            try
            {
                string userId = User.Claims.First(c => c.Type == "UserID").Value;
                var user = await _userManager.FindByIdAsync(userId);
                var persona = await _repository.Persona.GetPersonaByUserId(userId);
                _logger.LogInfo($"Regresa el perfil del usuario.");
                var personaResult = _mapper.Map<PersonaWithUserDTO>(persona);

                if (personaResult != null)
                {
                    PersonaUsuarioAplanadoDTO PersonaAplanado = new PersonaUsuarioAplanadoDTO();
                    PersonaAplanado.PrimerNombre = personaResult.PrimerNombre;
                    PersonaAplanado.SegundoNombre = personaResult.SegundoNombre;
                    PersonaAplanado.PrimerApellido = personaResult.PrimerApellido;
                    PersonaAplanado.SegundoApellido = personaResult.SegundoApellido;
                    PersonaAplanado.TipoIdentificacion = personaResult.TipoIdentificacion;
                    PersonaAplanado.NumeroIdentificacion = personaResult.NumeroIdentificacion;
                    PersonaAplanado.email = personaResult.ApplicationUser.email;
                    PersonaAplanado.userName = personaResult.ApplicationUser.userName;
                    PersonaAplanado.UrlFoto = personaResult.UrlFoto;
                    PersonaAplanado.NombreCompleto = personaResult.PrimerNombre + ' ' + personaResult.PrimerApellido;
                    return Ok(PersonaAplanado);
                }
                else
                {
                    return Ok();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError($"Algo paso al consultar el perfil: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
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