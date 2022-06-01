using H3LibraryProject.API.DTOs;
using H3LibraryProject.Services.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace H3LibraryProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {private readonly  IGenreService _service; 

        public GenreController(IGenreService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGenres()
        {
            try
            {
                List<GenreResponse> genreList = await _service.GetAllGenres();
                if (genreList.Count > 0)
                {
                    return Ok(genreList);
                }
                return NoContent();
            }
            catch (Exception ex)
            {

                return Problem(ex.Message);
            }
        }



        [HttpGet("{id}")]
        public async Task<IActionResult> GetGenreById([FromRoute] int id)
        {
            try
            {
                GenreResponse genre = await _service.GetGenreById(id);
                if (genre != null)
                {
                    return Ok(genre);
                }
                return NotFound();
            }
            catch (Exception ex)
            {

                return Problem(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateGenre([FromBody] GenreRequest newGenre)
        {
            try
            {
                GenreResponse createdGenre = await _service.CreateGenre(newGenre);
                if (createdGenre == null)
                {
                    return NotFound();
                }
                return Ok(createdGenre);
            }
            catch (Exception ex)
            {

                return Problem(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGenre([FromRoute] int id, [FromBody] GenreRequest genre)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            try
            {
                GenreResponse genreResult = await _service.UpdateGenre(id, genre);
                if (genreResult != null)
                {
                    return Ok(genreResult);
                }
                return NotFound();
            }
            catch (Exception ex)
            {

                return Problem(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGenre([FromRoute] int id)
        {
            try
            {
                GenreResponse genreResult = await _service.DeleteGenre(id);

                if (genreResult != null)
                {
                    return Ok(genreResult);
                }
                return NotFound();
            }
            catch (Exception ex)
            {

                return Problem(ex.Message);
            }
        }
    }
}
