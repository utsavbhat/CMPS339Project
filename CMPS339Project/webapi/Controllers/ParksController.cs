using Microsoft.AspNetCore.Mvc;
using webapi.Contracts;
using webapi.Models;

namespace webapi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ParksController : ControllerBase
    {
        private readonly IParksRepository _parkRepository;
        public ParksController(IParksRepository parksRepository)
        {
            _parkRepository = parksRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetParks()
        {
            try
            {
                var users = await _parkRepository.GetParks();
                return Ok(users);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetPark(int id)
        {
            try
            {
                var user = await _parkRepository.GetPark(id);
                return Ok(user);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> SavePark([FromBody] Parks form)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = await _parkRepository.SavePark(form);
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

        [HttpGet]
        public async Task<IActionResult> DeletePark(int id)
        {
            var deleteUser = await _parkRepository.DeletePark(id);
            return Ok(deleteUser);
        }
    }
}
