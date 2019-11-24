using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using Entities.DTO;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Attendance_GOON.Controllers
{
    [Route("api/dominio")]
    [ApiController]
    public class DominioController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public DominioController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDominios()
        {
            try
            {
                var dominios = await _repository.Dominio.GetAllDominios();

                _logger.LogInfo($"Returned all owners from database.");
                var dominiosResult = _mapper.Map<IEnumerable<DominioDTO>>(dominios);

                return Ok(dominiosResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllOwners action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpGet("{dominio}/{valor}", Name = "OneDomain")]
        public IActionResult GetOneDominio(string dominio, string valor)
        {
            try
            {
                var dominioResultado = _repository.Dominio.GetOneDominio(dominio, valor);

                if (dominioResultado == null)
                {
                    _logger.LogError($"Owner with id: {dominio}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned owner with id: {dominio}");

                    var dominioResult = _mapper.Map<DominioDTO>(dominio);
                    return Ok(dominioResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetOwnerById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateDominio([FromBody]DominioDTO dominio)
        {
            try
            {
                if (dominio == null)
                {
                    _logger.LogError("Owner object sent from client is null.");
                    return BadRequest("Owner object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid owner object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var DominioEntity = _mapper.Map<Dominio>(dominio);

                _repository.Dominio.CreateDominio(DominioEntity);
                await _repository.SaveAsync();

                var createdDominio = _mapper.Map<DominioDTO>(DominioEntity);

                return CreatedAtRoute("OneDomain", new { dominio =  createdDominio.Dominio1, valor = createdDominio.Valor  }, createdDominio);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateOwner action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpGet("diaSemana")]
        
        public async Task<IActionResult> GetAllDiaSemanas()
        {
            try
            {
                var diasSemana = await _repository.Dominio.GetDiasSemana();

                _logger.LogInfo($"Returned all owners from database.");
                var diaSemanaResult = _mapper.Map<IEnumerable<DominioDTO>>(diasSemana);

                return Ok(diaSemanaResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllOwners action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpGet("tipoIdentificacion")]

        public async Task<IActionResult> GetTipoIdentificacion()
        {
            try
            {
                var tipoIdentificacion = await _repository.Dominio.GetTipoIdentificacion();

                _logger.LogInfo($"Returned all owners from database.");
                var tipoIdentificacionResult = _mapper.Map<IEnumerable<DominioDTO>>(tipoIdentificacion);

                return Ok(tipoIdentificacionResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllOwners action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}