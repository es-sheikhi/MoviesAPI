using Microsoft.AspNetCore.Identity;

namespace MoviesAPI.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string Name { get; set; }
    }
}
