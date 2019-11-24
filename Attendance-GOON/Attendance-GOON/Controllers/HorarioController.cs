using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Attendance_GOON.Controllers
{
    [Route("api/horario")]
    [ApiController]
    public class HorarioController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;

        public HorarioController(ILoggerManager logger, IRepositoryWrapper repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAllHorariosSinDia()
        {
            try
            {
                var horarios = _repository.Horario.GetAllHorarios();


                _logger.LogInfo($"Returned all owners from database.");

                return Ok(horarios);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllOwners action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpGet("connombredia")]
        public IActionResult GetAllHorariosconDia()
        {
            try
            {
                var horarios = _repository.Horarios.GetAllHorarios();


                _logger.LogInfo($"Returned all owners from database.");

                return Ok(horarios);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllOwners action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}


