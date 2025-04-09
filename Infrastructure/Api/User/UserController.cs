using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.User.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Api.User
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {

        [HttpPost]
        public IActionResult CreateUser([FromBody] NewUserDto userDto)
        {
            if (userDto == null || string.IsNullOrEmpty(userDto.Name))
            {
                return BadRequest("Invalid user data.");
            }

            // Simulate user creation logic
            var createdUser = new
            {
                Id = Guid.NewGuid(),
                Name = userDto.Name,
                Email = userDto.Email
            };

            return CreatedAtAction(nameof(GetUser), new { id = createdUser.Id }, createdUser);
        }

        [HttpGet("{id}")]
        public IActionResult GetUser([FromQueryAttribute] Guid id)
        {

            return Ok($"Get user with id: {id}");
        }

        [HttpGet]
        public IActionResult GetAll()
        {

            return Ok("Get all users");
        }

    }
}