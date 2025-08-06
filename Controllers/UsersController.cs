using UserManagementAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace UserManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private static List<User> _users = new();


        [HttpGet]
        public ActionResult<IEnumerable<User>> GetAll()
        {
            try
            {
                return Ok(_users.AsReadOnly());
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            try
            {
                var user = _users.FirstOrDefault(u => u.Id == id);
                return user == null ? NotFound($"User with id {id} not found.") : Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public ActionResult<User> Create(User user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            user.Id = _users.Count + 1;
            _users.Add(user);
            return CreatedAtAction(nameof(Get), new { id = user.Id }, user);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, User updatedUser)
        {
            try
            {
                var user = _users.FirstOrDefault(u => u.Id == id);

                if (user == null)
                    return NotFound($"User with id {id} not found.");

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                user.FirstName = updatedUser.FirstName;
                user.LastName = updatedUser.LastName;
                user.Email = updatedUser.Email;

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var user = _users.FirstOrDefault(u => u.Id == id);

                if (user == null)
                    return NotFound($"User with id {id} not found.");          

        
                _users.Remove(user);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }      

        
        }
    }

}