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
        public async Task<IEnumerable<Bon>> GetAllBonuri()
        {
            return await _unitOfWork.Bonuri.GetAllAsync();
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
    }
}
