using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Contracts;
using Entities.DTO;
using Entities.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;

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

        [HttpGet("{Id_Materia}", Name = "MateriaById")]
        public async Task<IActionResult> GetMateriaById(int Id_Materia)
        {
            try
            {
                var materia = await _repository.Materia.GetMateriaById(Id_Materia);

                if (materia == null)
                {
                    _logger.LogError($"La materia con el ID: {Id_Materia}, no se encontró en la BD.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Materia con el ID: {Id_Materia}");
                    return Ok(materia);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Algo fallo al intentar ejecutar GetMateriaById: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateMateria([FromBody]Materia materia)
        {
            try
            {
                if (materia == null)
                {
                    _logger.LogError("El objto Materia esta Null.");
                    return BadRequest("El objeto materia esta Null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Objeto Materia Invalido para enviar desde el clientes.");
                    return BadRequest("Modelo de Objeto Invalido");
                }

                await _repository.Materia.CrearMateria(materia);
                return CreatedAtRoute("MateriaById", new { Id_Materia = materia.Id }, materia);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Algo fallo al crear una nueva Materia {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMateria(int id, [FromBody]Materia materia)
        {
            try
            {
                if (materia == null)
                {
                    _logger.LogError("El objeto Materia esta Null.");
                    return BadRequest("El objeto Materia es null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid owner object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var dbMateria = await _repository.Materia.GetMateriaById(id);
                /* if (dbMateria.IsEmptyObject())
                {
                    _logger.LogError($"Owner with id: {id}, hasn't been found in db.");
                    return NotFound();
                }*/

                await _repository.Materia.UpdateMateria(dbMateria, materia);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Algo fallo al actualizar la Materia: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("import")]
        public async Task<ReponseExcel<List<Materia>>> Import([FromForm(Name = "formFile")] IFormFile formFile, CancellationToken cancellationToken)
        {
            if (formFile == null || formFile.Length <= 0)
            {
                return ReponseExcel<List<Materia>>.GetResult(-1, "formfile is empty");
            }

            if (!Path.GetExtension(formFile.FileName).Equals(".xlsx", StringComparison.OrdinalIgnoreCase))
            {
                return ReponseExcel<List<Materia>>.GetResult(-1, "Not Support file extension");
            }

            var list = new List<Materia>();

            using (var stream = new MemoryStream())
            {
                await formFile.CopyToAsync(stream, cancellationToken);

                using (var package = new ExcelPackage(stream))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                    var rowCount = worksheet.Dimension.Rows;

                    for (int row = 1; row <= rowCount; row++)
                    {
                        list.Add(new Materia
                        {
                            Nombre = worksheet.Cells[row, 1].Value.ToString().Trim()
                            
                        });
                    }
                }
            }

            if (list.Count == 0)
            {
                return ReponseExcel<List<Materia>>.GetResult(500, "Faild", list);
            }
            else
            {
                foreach (var x in list)
                {
                    await _repository.Materia.CrearMateria(x);
                }
            }

            
            // here just read and return  

            return ReponseExcel<List<Materia>>.GetResult(0, "OK", list);
        }
    }
}
