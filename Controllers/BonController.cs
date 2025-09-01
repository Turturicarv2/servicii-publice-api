using Microsoft.AspNetCore.Mvc;
using ServiciiPubliceBackend.DTOs;
using ServiciiPubliceBackend.Models;
using ServiciiPubliceBackend.UnitOfWork;

namespace ServiciiPubliceBackend.Controllers
{
    [Route("api/[Controller]/[Action]")]
    [ApiController]
    public class BonController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public BonController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bon>>> GetAllBonuri()
        {
            try
            {
                var result = await _unitOfWork.Bonuri.GetAllAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error: " + ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateBon(int ghiseuId)
        {
            try
            {
                Bon bon = new Bon
                {
                    IdGhiseu = ghiseuId,
                    Stare = "in asteptare",
                    CreatedAt = DateTime.Now
                };

                bool created = await _unitOfWork.Bonuri.AddAsync(bon);

                if (!created)
                {
                    return StatusCode(500, "Failed to add ghiseu");
                }

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error: " + ex.Message);
            }
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> MarkBonAsInProgress(int id)
        {
            try
            {
                bool updated = await _unitOfWork.Bonuri.MarkBonAsInProgressAsync(id);

                if (!updated)
                {
                    return NotFound("Bon not found!");
                }

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error: " + ex.Message);
            }
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> MarkBonAsReceived(int id)
        {
            try
            {
                bool updated = await _unitOfWork.Bonuri.MarkBonAsRecievedAsync(id);

                if (!updated)
                {
                    return NotFound("Bon not found!");
                }

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error: " + ex.Message);
            }
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> MarkBonAsClosed(int id)
        {
            try
            {
                bool updated = await _unitOfWork.Bonuri.MarkBonAsClosedAsync(id);

                if (!updated)
                {
                    return NotFound("Bon not found!");
                }

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error: " + ex.Message);
            }
        }
    }
}
