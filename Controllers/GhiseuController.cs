using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
                var result = await _unitOfWork.Ghisee.GetAllGhiseuAsync();
                return Ok(result);
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
                bool updated = await _unitOfWork.Ghisee.EditGhiseu(ghiseuNou);

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

        [HttpPut("{id}")]
        public async Task<IActionResult> MarkGhiseuAsActive(int id)
        {
            try 
            {
                bool updated = await _unitOfWork.Ghisee.MarkGhiseuAsActive(id);

                if (!updated)
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
