using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using Entities.DTO;
using Entities.DTO.Profesor;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Attendance_GOON.Controllers
{
    [Route("api/profesor")]
    [ApiController]
    public class ProfesorController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public ProfesorController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllProfesores()
        {
            try
            {
                var profesores = await _repository.Profesor.GetAllProfesores();

                _logger.LogInfo($"Returned all owners from database.");

                return Ok(profesores);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllOwners action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpGet("{TipoIdentificacion}/{NumeroIdentificacion}", Name = "ProfesorById")]
        public async Task<IActionResult> GetProfesorById(string TipoIdentificacion, string NumeroIdentificacion)
        {
            try
            {
                var profesor = await _repository.Profesor.GetProfesorById(TipoIdentificacion, NumeroIdentificacion);

                if (profesor == null)
                {
                    _logger.LogError($"Persona con el Número de Identificación: {NumeroIdentificacion}, No se encontró en la BD.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned la persona con el número de identificación: {NumeroIdentificacion}");

                    var ownerResult = _mapper.Map<ProfesorDTO>(profesor);
                    return Ok(ownerResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetOwnerById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpGet("{TipoIdentificacion}/{NumeroIdentificacion}/materias", Name = "ProfesorByMateriasId")]
        public async Task<IActionResult> GetProfesorByIdWithMateria(string TipoIdentificacion, string NumeroIdentificacion)
        {
            try
            {
                var profesor = await _repository.Profesor.GetProfesorByIdWithMaterias(TipoIdentificacion, NumeroIdentificacion);

                if (profesor == null)
                {
                    _logger.LogError($"Persona con el Número de Identificación: {NumeroIdentificacion}, No se encontró en la BD.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned la persona con el número de identificación: {NumeroIdentificacion}");

                    var ownerResult = _mapper.Map<ProfesorWithMateriaDTO>(profesor);
                    return Ok(ownerResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetOwnerById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateProfesor([FromBody]CrearProfesorDTO profesor)
        {
            try
            {
                if (profesor == null)
                {
                    _logger.LogError("Owner object sent from client is null.");
                    return BadRequest("Owner object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid owner object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var profesorEntity = _mapper.Map<Profesor>(profesor);

                _repository.Profesor.CreateProfesor(profesorEntity);
                await _repository.SaveAsync();

                var createdProfesor = _mapper.Map<ProfesorDTO>(profesorEntity);

                return CreatedAtRoute("ProfesorById", new
                {
                    TipoIdentificacion = createdProfesor.TipoIdentificacion,
                    NumeroIdentificacion = createdProfesor.NumeroIdentificacion
                }, createdProfesor);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateOwner action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpPut("{TipoIdentificacion}/{NumeroIdentificacion}")]
        public async Task<IActionResult> UpdateProfesor(string TipoIdentificacion, string NumeroIdentificacion, [FromBody]UpdateProfesorDTO profesor)
        {
            try
            {
                if (profesor == null)
                {
                    _logger.LogError("Owner object sent from client is null.");
                    return BadRequest("Owner object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid owner object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var profesorEntity = await _repository.Profesor.GetProfesorById(TipoIdentificacion, NumeroIdentificacion);
                if (profesorEntity == null)
                {
                    _logger.LogError($"Owner with id: {TipoIdentificacion} /{NumeroIdentificacion}, hasn't been found in db.");
                    return NotFound();
                }

                _mapper.Map(profesor, profesorEntity);

                _repository.Profesor.UpdateProfesor(profesorEntity);
                await _repository.SaveAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateOwner action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

    }
}