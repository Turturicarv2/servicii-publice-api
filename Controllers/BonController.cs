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

        [HttpGet("{GhiseuId}")]
        public async Task<ActionResult<IEnumerable<Bon>>> GetAllBonuriByGhiseuId(int GhiseuId)
        {
            try
            {
                var result = await _unitOfWork.Bonuri.GetAllByGhiseuIdAsync(GhiseuId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error: " + ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateBon([FromBody] CreateBonDTO bonDTO)
        {
            try
            {
                Bon bon = new Bon
                {
                    IdGhiseu = bonDTO.GhiseuId,
                    Stare = "in asteptare",
                    CreatedAt = DateTime.Now,
                    UserId = bonDTO.UserId
                };

                int id = await _unitOfWork.Bonuri.AddAsync(bon);

                return Ok(id);
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
