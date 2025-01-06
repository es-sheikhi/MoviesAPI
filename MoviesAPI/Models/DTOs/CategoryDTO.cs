using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Models.DTOs
{
    public class CategoryDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "{0} is required!")]
        [MaxLength(10, ErrorMessage = "Max length is 10 characters")]
        public string Name { get; set; } = default!;
        public DateTime DateOfCreation { get; set; }
    }
}
