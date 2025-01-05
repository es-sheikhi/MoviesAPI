using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Models;
using MoviesAPI.Models.DTOs;
using MoviesAPI.Repositories.Interfaces;

namespace MoviesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoriesController(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public IActionResult GetCategories()
        {
            var categories = _categoryRepository.GetCategories().Select(_mapper.Map<CategoryDTO>);
            return Ok(categories);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetCategory(int id)
        {
            var category = _categoryRepository.GetCategory(id);
            if(category == null)
            {
                return NotFound();
            }
            var categoryDto = _mapper.Map<CategoryDTO>(category);
            return Ok(categoryDto);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Create(CreateCategoryDTO categoryDTO)
        {
            if (!ModelState.IsValid || categoryDTO == null)
            {
                return BadRequest(ModelState);
            }

            if (_categoryRepository.ExistCategory(categoryDTO.Name))
            {
                return BadRequest(ModelState);
            }

            var category = _mapper.Map<Category>(categoryDTO);
            if (!_categoryRepository.CreateCategory(category))
            {
                return StatusCode(500, ModelState);
            }
            return CreatedAtAction(nameof(GetCategory), new { id = category.Id }, category);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Update(int id, CategoryDTO categoryDTO)
        {
            if(!ModelState.IsValid || categoryDTO==null || id != categoryDTO.Id)
            {
                return BadRequest(ModelState);
            }

            if (!_categoryRepository.ExistCategory(id))
            {
                return NotFound();
            }

            var category = _mapper.Map<Category>(categoryDTO);
            if (!_categoryRepository.UpdateCategory(category))
            {
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Delete(int id)
        {
            var category = _categoryRepository.GetCategory(id);
            if (category==null)
            {
                return NotFound();
            }

            if (!_categoryRepository.DeleteCategory(category))
            {
                return StatusCode(500);
            }

            return NoContent();
        }
    }
}
