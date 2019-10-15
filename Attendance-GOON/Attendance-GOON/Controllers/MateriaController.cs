using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Attendance_GOON.Controllers
{
    [Route("api/materia")]
    [ApiController]
    public class MateriaController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        public MateriaController(ILoggerManager logger, IRepositoryWrapper repository)
        {
            _logger = logger;
            _repository = repository;
        }
        // GET: api/Materia
        [HttpGet]
        public async Task<IActionResult> GetAllMaterias()
        {
            try
            {
                var materias = await _repository.Materia.GetAllMaterias();

                _logger.LogInfo($"Regresa todas las materia de la Base de Datos.");

                return Ok(materias);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Algo paso al consultar las materias: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
