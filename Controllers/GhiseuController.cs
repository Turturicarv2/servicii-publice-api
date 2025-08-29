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
        public async Task<IEnumerable<Ghiseu>> GetAllGhisee()
        {
            return await _unitOfWork.Ghisee.GetAllGhiseuAsync();
        }
    }
}
