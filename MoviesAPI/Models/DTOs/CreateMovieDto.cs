using MoviesAPI.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Models.DTOs
{
    public class CreateMovieDto
    {
        [Required(ErrorMessage ="{0} is required!")]
        public string Name { get; set; }
        public string Descripcion { get; set; }
        public int Duraion { get; set; }
        public Classification Classification { get; set; }
        public DateTime DateOfCreation { get; set; }

        [Required(ErrorMessage ="{0} is required!")]
        public int CategoryId { get; set; }
    }
}
