using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCore.MongoDb.Models;
using AspNetCore.MongoDb.Services;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore.MongoDb.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly UserService _service;

        public UsersController(UserService service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> Get() 
        {
            try
            {
                var result = await _service.GetUsersAsync();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] User user) 
        {
            await _service.CreateAsync(user);

            return CreatedAtAction(nameof(Post), new { Name = user.Name }, user);
        }
    }
}