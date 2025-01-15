namespace MoviesAPI.Models.DTOs
{
    public class UserLoginResponseDto
    {
        public User User { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }
    }
}
