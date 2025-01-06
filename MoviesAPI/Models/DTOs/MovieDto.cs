﻿using MoviesAPI.Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoviesAPI.Models.DTOs
{
    public class MovieDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Descripcion { get; set; }
        public int Duraion { get; set; }
        public Classification Classification { get; set; }
        public DateTime DateOfCreation { get; set; }

        public int CategoryId { get; set; }
    }
}
