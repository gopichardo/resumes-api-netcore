using System.Threading.Tasks;
using Api.User.Dtos;
using Core.Usecase.Users;
using Microsoft.AspNetCore.Mvc;

namespace Api.User
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ICreateUserUseCase _createUserUseCase;
        private readonly IQueryUserUseCase _getUserUseCase;
        private readonly IQueryAllUsersUseCase _queryAllUsersUseCase;

        public UserController(ICreateUserUseCase createUserUseCase, IQueryUserUseCase getUserUseCase, IQueryAllUsersUseCase queryAllUsersUseCase)
        {
            _createUserUseCase = createUserUseCase;
            _getUserUseCase = getUserUseCase;
            _queryAllUsersUseCase = queryAllUsersUseCase;
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
        public async Task<IActionResult> GetUser([FromRoute] Guid id)
        {

            if (id == Guid.Empty)
            {
                return BadRequest("Invalid user ID.");
            }

            var user = await _getUserUseCase.QueryAsync(id);

            if (user == null)
            {
                return NotFound($"User with ID {id} was not found.");
            }

            return Ok(user);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _queryAllUsersUseCase.QueryAllAsync().Result;

            return Ok(users);
        }

    }
}