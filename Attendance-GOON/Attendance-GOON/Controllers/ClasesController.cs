using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using Entities.DTO;
using Entities.DTO.Clase;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Math;

namespace Attendance_GOON.Controllers
{
    [Route("api/clases")]
    [ApiController]
    public class ClasesController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public ClasesController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;

        }

        #region GET
        [HttpGet]
        public async Task<IActionResult> GetAllClases()
        {
            try
            {
                var clases = await _repository.Clases.GetAllClases();


                _logger.LogInfo($"Returned all owners from database.");
                var ownersResult = _mapper.Map<IEnumerable<ConsultaClaseSlimDTO>>(clases);

                return Ok(ownersResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllOwners action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetClaseById(int id)
        {
            try
            {
                var clase = await _repository.Clases.GetClaseById(id);

                if (clase == null)
                {
                    _logger.LogError($"Owner with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned owner with id: {id}");

                    var claseResult = _mapper.Map<ConsultaClaseSlimDTO>(clase);
                    return Ok(claseResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetOwnerById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpGet("{TipoIdentificacion}/{NumeroIdentificacion}", Name = "ClaseProfesorById")]
        public async Task<IActionResult> GetAllClasesByProfesor(string TipoIdentificacion, string NumeroIdentificacion)
        {
            try
            {
                var clases = await _repository.Clases.GetClaseByProfesor(TipoIdentificacion, NumeroIdentificacion);


                _logger.LogInfo($"Returned all owners from database.");
                var ownersResult = _mapper.Map<IEnumerable<ConsultaOnlyClaseSlimDTO>>(clases);

                return Ok(ownersResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllOwners action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        #endregion

        #region PUT

        [HttpPut("marcarAsistencia/{id}")]
        public async Task<IActionResult> MarcarClase(int id, [FromBody]MarcarClaseDTO clase)
        {
            try
            {
                if (clase == null)
                {
                    _logger.LogError("Owner object sent from client is null.");
                    return BadRequest("Owner object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid owner object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var ownerEntity = await _repository.Clases.GetClaseById(id);
                if (ownerEntity == null)
                {
                    _logger.LogError($"Owner with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _mapper.Map(clase, ownerEntity);

                _repository.Clases.UpdateClase(ownerEntity);
                await _repository.SaveAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateOwner action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        #endregion

    }
}