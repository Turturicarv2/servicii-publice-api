using Microsoft.AspNetCore.Mvc;
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
    }
}
