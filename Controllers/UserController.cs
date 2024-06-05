using BOOKSTORE.Exception;
using BOOKSTORE.Interface;
using BOOKSTORE.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BOOKSTORE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser _userService;
        private readonly ILogger<UserController> _logger;

        public UserController(IUser userService, ILogger<UserController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [HttpPost]
        public async Task<ActionResult<User>> AddUser([FromBody] User user)
        {
            try
            {
                var addedUser = await _userService.AddUser(user);
                return CreatedAtAction(nameof(GetUserById), new { id = addedUser.UserId }, addedUser);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "Error adding user");
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<User>> UpdateUser(int id, [FromBody] User user)
        {
            if (id != user.UserId)
            {
                return BadRequest("User ID mismatch");
            }

            try
            {
                var updatedUser = await _userService.UpdateUser(user);
                return Ok(updatedUser);
            }
            catch (NoUserException ex)
            {
                _logger.LogError(ex, "User not found");
                return NotFound(ex.Message);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "Error updating user");
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteUser(int id)
        {
            try
            {
                var result = await _userService.DeleteUser(id);
                if (result)
                {
                    return Ok(result);
                }
                return NotFound("User not found");
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "Error deleting user");
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            try
            {
                var user = await _userService.GetUserById(id);
                return Ok(user);
            }
            catch (NoUserException ex)
            {
                _logger.LogError(ex, "User not found");
                return NotFound(ex.Message);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "Error retrieving user");
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {
            try
            {
                var users = await _userService.GetAllUsers();
                return Ok(users);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "Error retrieving users");
                return BadRequest(ex.Message);
            }
        }
    }
}
