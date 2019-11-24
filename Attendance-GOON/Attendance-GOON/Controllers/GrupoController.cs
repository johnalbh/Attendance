using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using Entities.DTO;
using Entities.DTO.Grupo;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Attendance_GOON.Controllers
{
    [Route("api/grupo")]
    [ApiController]
    public class GrupoController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public GrupoController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGrupos()
         {
            try
            {
                var grupos = await _repository.Grupo.GetAllGrupos();
                _logger.LogInfo($"Returned all grupos from database.");
                var grupoResult = _mapper.Map<IEnumerable<GrupoDTO>>(grupos);
                return Ok(grupoResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllGrupos action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpGet("{id}", Name = "GrupoById")]
        public async Task<IActionResult> GetGrupoById(int id)
        {
            try
            {
                var grupo = await _repository.Grupo.GetGrupoById(id);

                if (grupo == null)
                {
                    _logger.LogError($"Grupo with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned grupo with id: {id}");

                    var ownerResult = _mapper.Map<GrupoDTO>(grupo);
                    return Ok(ownerResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetGrupoById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateGrupo([FromBody]CreateGrupoDTO grupo)
        {
            try
            {
                if (grupo == null)
                {
                    _logger.LogError("Grupo object sent from client is null.");
                    return BadRequest("Grupo object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid grupo object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var grupoEntity = _mapper.Map<Grupo>(grupo);

                _repository.Grupo.CreateGrupo(grupoEntity);
                await _repository.SaveAsync();

                var createdGrupo = _mapper.Map<GrupoDTO>(grupoEntity);

                return CreatedAtRoute("GrupoById", new { id = createdGrupo.Id }, createdGrupo);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateGrupo action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpGet("grupohorario/{idGrupo}/{idHorario}")]
        public IActionResult GetOwnerById(int IdGrupo, int IdHorario)
        {
            try
            {
                    var owner = _repository.GrupoHorario.GetGrupoHorarioById(IdGrupo, IdHorario);

                if (owner == null)
                {
                    _logger.LogError($"Owner with id: {IdGrupo}{IdHorario}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned owner with id: {IdGrupo}{IdHorario}");

                    var ownerResult = _mapper.Map<ConsultaGrupoHorarioDTO>(owner);
                    return Ok(ownerResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetOwnerById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }


        [HttpPut("{idGrupo}")]
        public async Task<IActionResult> UpdateGrupo(int idGrupo, [FromBody]UpdateGrupoDTO grupo)
        {
            try
            {
                if (grupo == null)
                {
                    _logger.LogError("Owner object sent from client is null.");
                    return BadRequest("Owner object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid owner object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var ownerEntity = await _repository.Grupo.GetGrupoById(idGrupo);
                if (ownerEntity == null)
                {
                    _logger.LogError($"Owner with id: {idGrupo}, hasn't been found in db.");
                    return NotFound();
                }

                _mapper.Map(grupo, ownerEntity);

                _repository.Grupo.UpdateGrupo(ownerEntity);
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