using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Models.DTOs
{
    public class CreateCategoryDTO
    {
        [Required(ErrorMessage = "{0} is required!")]
        [MaxLength(10, ErrorMessage = "Max length is 10 characters")]
        public string Name { get; set; } = default!;
    }
}
