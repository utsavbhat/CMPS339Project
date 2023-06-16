using Microsoft.AspNetCore.Mvc;
using webapi.Contracts;
using webapi.Models;

namespace webapi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepo;
        public UsersController(IUserRepository companyRepo)
        {
            _userRepo = companyRepo;
        }
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                var users = await _userRepo.GetUsers();
                return Ok(users);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetUser(int id)
        {
            try
            {
                var user = await _userRepo.GetUser(id);
                return Ok(user);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> SaveUser([FromBody] Users form)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = await _userRepo.SaveUser(form);
                    return Ok(user);
                }
                return StatusCode(500, "Invalid ModelState");
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
            
        }

        [HttpPost]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var deleteUser = await _userRepo.DeleteUser(id);
            return Ok(deleteUser);
        }


    }
}
