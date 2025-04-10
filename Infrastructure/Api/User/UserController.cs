using Api.User.Dtos;
using Core.Usecase;
using Microsoft.AspNetCore.Mvc;

namespace Api.User
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ICreateUserUseCase _createUserUseCase;

        public UserController(ICreateUserUseCase createUserUseCase)
        {
            _createUserUseCase = createUserUseCase;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] NewUserDto userDto)
        {
            if (userDto == null || string.IsNullOrEmpty(userDto.Name))
            {
                return BadRequest("Invalid user data.");
            }
            // Simulate user creation logic
            var createdUser = new Core.Entity.User
            {
                Id = Guid.NewGuid(),
                Name = userDto.Name,
                Email = userDto.Email
            };

            await _createUserUseCase.ExecuteAsync(createdUser);

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