using AutoMapper;
using MoviesAPI.Models;
using MoviesAPI.Models.DTOs;

namespace MoviesAPI.Mappers
{
    public class CategoryMapper:Profile
    {
        public CategoryMapper()
        {
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Category, CreateCategoryDTO>().ReverseMap();
        }
    }
}
