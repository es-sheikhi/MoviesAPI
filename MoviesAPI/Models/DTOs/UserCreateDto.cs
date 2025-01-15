using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Models.DTOs
{
    public class UserCreateDto
    {
        [Required(ErrorMessage ="{0} is required!")]
        public string UserName { get; set; }
        [Required(ErrorMessage ="{0} is required!")]
        public string Name { get; set; }
        [Required(ErrorMessage ="{0} is required!")]
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
