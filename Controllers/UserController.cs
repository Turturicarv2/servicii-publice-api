using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiciiPubliceBackend.DTOs;
using ServiciiPubliceBackend.Models;
using ServiciiPubliceBackend.UnitOfWork;

namespace ServiciiPubliceBackend.Controllers
{
    [Route("api/[Controller]/[Action]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        
        public UserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //[HttpGet]
        //public ActionResult Index()
        //{
        //    return View();
        //}

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserDTO userDTO)
        {
            try
            {
                User user = new User
                { 
                    Username = userDTO.Username,
                    Password = userDTO.Password,
                    Role = "user"
                };

                bool result = await _unitOfWork.Users.AddUserAsync(user);
                if (result)
                {
                    return Ok();
                }
                else
                {
                    return StatusCode(500, "Internal Server Error: Error while trying to insert the user");
                }
            }
            catch (Exception ex) 
            {
                return StatusCode(500, "Internal Server Error: " + ex.Message);
            }
        }
    }
}
