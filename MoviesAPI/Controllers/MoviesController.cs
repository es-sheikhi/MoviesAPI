using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Models;
using MoviesAPI.Models.DTOs;
using MoviesAPI.Repositories;
using MoviesAPI.Repositories.Interfaces;

namespace MoviesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;
        public MoviesController(IMovieRepository repository, IMapper mapper)
        {
            _movieRepository = repository;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public IActionResult GetMovies()
        {
            var movies = _movieRepository.GetMovies().Select(_mapper.Map<MovieDto>);
            return Ok(movies);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetMovie(int id)
        {
            var movie = _movieRepository.GetMovie(id);
            if (movie == null)
            {
                return NotFound();
            }
            var movieDto = _mapper.Map<MovieDto>(movie);
            return Ok(movieDto);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Create(CreateMovieDto movieDTO)
        {
            if (!ModelState.IsValid || movieDTO == null)
            {
                return BadRequest(ModelState);
            }

            if (_movieRepository.ExistMovie(movieDTO.Name))
            {
                return BadRequest(ModelState);
            }

            var movie = _mapper.Map<Movie>(movieDTO);
            if (!_movieRepository.CreateMovie(movie))
            {
                return StatusCode(500, ModelState);
            }
            return CreatedAtAction(nameof(GetMovie), new { id = movie.Id }, movie);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Update(CreateMovieDto movieDTO)
        {
            if (!ModelState.IsValid || movieDTO == null)
            {
                return BadRequest(ModelState);
            }

            var movie=_mapper.Map<Movie>(movieDTO);
            if (!_movieRepository.UpdateMovie(movie))
            {
                return StatusCode(500, movie);
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
            var movie = _movieRepository.GetMovie(id);
            if (movie == null)
            {
                return NotFound();
            }

            if (!_movieRepository.DeleteMovie(movie))
            {
                return StatusCode(500);
            }

            return NoContent();
        }
    }
}
