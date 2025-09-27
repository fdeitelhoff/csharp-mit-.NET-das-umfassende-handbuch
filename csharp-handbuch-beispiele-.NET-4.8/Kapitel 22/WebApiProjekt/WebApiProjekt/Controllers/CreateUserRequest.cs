using System.ComponentModel.DataAnnotations;

namespace WebApiProjekt.Controllers
{
    // Das Request-Model
    public class CreateUserRequest
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
