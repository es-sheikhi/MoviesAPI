using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Models.DTOs
{
    public class UserLoginDto
    {
        [Required(ErrorMessage ="{0} is required!")]
        public string UserName { get; set; }
        [Required(ErrorMessage ="{0} is required!")]
        public string Password { get; set; }
    }
}
