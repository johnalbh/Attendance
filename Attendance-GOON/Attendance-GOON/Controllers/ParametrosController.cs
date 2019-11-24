using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using Entities.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Attendance_GOON.Controllers
{
    [Route("api/parametros")]
    [ApiController]
    public class ParametrosController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public ParametrosController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;

        }

        [HttpGet]
        public async Task<IActionResult> GetAllParametros()
        {
            try
            {
                var parametros = await _repository.Parametro.GetAllParametros();

                _logger.LogInfo($"Returned all parametros from database.");
                var ownersResult = _mapper.Map<IEnumerable<ParametroDTO>>(parametros);
                return Ok(parametros);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllOwners action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{codigo}", Name = "ParametroByCodigo")]
        public async Task<IActionResult> GetOwnerById(int codigo)
        {
            try
            {
                var parametro = await  _repository.Parametro.GetParametroByCodigo(codigo);

                if (parametro == null)
                {
                    _logger.LogError($"Owner with id: {parametro }, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned owner with id: {parametro }");

                    var parametroResult = _mapper.Map<ParametroDTO>(parametro);
                    return Ok(parametroResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetOwnerById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}