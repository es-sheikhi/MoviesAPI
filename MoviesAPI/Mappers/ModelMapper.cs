using AutoMapper;
using MoviesAPI.Models;
using MoviesAPI.Models.DTOs;

namespace MoviesAPI.Mappers
{
    public class ModelMapper:Profile
    {
        public ModelMapper()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Movie, MovieDto>().ReverseMap();
            CreateMap<Movie, CreateMovieDto>().ReverseMap();
        }
    }
}
