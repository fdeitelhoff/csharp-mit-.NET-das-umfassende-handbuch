using Microsoft.AspNetCore.Mvc;

namespace WebApiProjekt.Controllers
{
    //[ApiController]
    //[Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        // POST: api/users
        //[HttpPost]
        public IActionResult CreateUser([FromBody] CreateUserRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Beispiel: Benutzer anlegen (hier nur simuliert)
            var createdUser = new
            {
                Id = Guid.NewGuid(),
                request.FirstName,
                request.LastName,
                request.Email
            };

            // Gibt 201 Created zurück mit der Benutzer-Info
            return CreatedAtAction(nameof(GetUser), new { id = createdUser.Id }, createdUser);
        }

        // GET: api/users/{id}
        //[HttpGet("{id}")]
        public IActionResult GetUser(Guid id)
        {
            // Hier nur ein Dummy-Rückgabewert
            return Ok(new { Id = id, FirstName = "Max", LastName = "Mustermann", Email = "max@example.com" });
        }
    } 
}
