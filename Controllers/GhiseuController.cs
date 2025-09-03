using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiciiPubliceBackend.DTOs;
using ServiciiPubliceBackend.Models;
using ServiciiPubliceBackend.UnitOfWork;

namespace ServiciiPubliceBackend.Controllers
{
    [Route("api/[Controller]/[Action]")]
    [ApiController]
    public class GhiseuController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public GhiseuController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ghiseu>>> GetAllGhisee()
        {
            try
            {
                var result = await _unitOfWork.Ghisee.GetAllAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error: " + ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<int>> AddGhiseu([FromBody] CreateGhiseuDTO dto)
        {
            if (dto == null)
            {
                return BadRequest("Invalid Input");
            }

            try
            {
                Ghiseu ghiseu = new Ghiseu
                {
                    Cod = dto.Cod,
                    Denumire = dto.Denumire,
                    Descriere = dto.Descriere,
                    Icon = dto.Icon,
                    Activ = false
                };
                int id = await _unitOfWork.Ghisee.AddAsync(ghiseu);

                return Ok(id);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error: " + ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateGhiseu([FromBody] Ghiseu ghiseuNou)
        {
            try
            {
                bool updated = await _unitOfWork.Ghisee.EditGhiseuAsync(ghiseuNou);

                if (!updated)
                {
                    return NotFound("Ghiseu not found");
                }
                return Ok();
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error: " + ex.Message);
            }
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> MarkGhiseuAsActive(int id)
        {
            try 
            {
                bool updated = await _unitOfWork.Ghisee.MarkGhiseuAsActiveAsync(id);

                if (!updated)
                    return NotFound("Ghiseu not found!");

                return Ok();
            }
            catch (Exception exception)
            {
                return StatusCode(500, "Internal Server Error: " + exception.Message);
            }
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> MarkGhiseuAsInactive(int id)
        {
            try
            {
                bool updated = await _unitOfWork.Ghisee.MarkGhiseuAsInactiveAsync(id);

                if (!updated)
                    return NotFound("Ghiseu not found!");

                return Ok();
            }
            catch (Exception exception)
            {
                return StatusCode(500, "Internal Server Error: " + exception.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGhiseu(int id)
        {
            try
            {
                bool deleted = await _unitOfWork.Ghisee.DeleteGhiseuAsync(id);

                if (!deleted)
                    return NotFound("Ghiseu not found!");

                return Ok();
            }
            catch (Exception exception)
            {
                return StatusCode(500, "Internal Server Error: " + exception.Message);
            }
        }
    }
}
