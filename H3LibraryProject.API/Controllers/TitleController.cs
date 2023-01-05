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
    public class TitleController : ControllerBase
    {
        private readonly  ITitleService _service; 

        public TitleController(ITitleService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTitles()
        {
            try
            {
                List<TitleResponse> titleList = await _service.GetAllTitles();
                if (titleList.Count > 0)
                {
                    return Ok(titleList);
                }
                return NoContent();
            }
            catch (Exception ex)
            {

                return Problem(ex.Message);
            }
        }



        [HttpGet("{id}")]
        public async Task<IActionResult> GetTitleById([FromRoute] int id)
        {
            try
            {
                TitleResponse title = await _service.GetTitlesById(id);
                if (title != null)
                {
                    return Ok(title);
                }
                return NotFound();
            }
            catch (Exception ex)
            {

                return Problem(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateTitle([FromBody] TitleRequest newTitle)
        {
            try
            {
                TitleResponse createdTitle = await _service.CreateTitle(newTitle);
                if (createdTitle == null)
                {
                    return NotFound();
                }
                return Ok(createdTitle);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTitle([FromRoute] int id, [FromBody] TitleRequest title)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            try
            {
                TitleResponse titleResult = await _service.UpdateTitle(id, title);
                if (titleResult != null)
                {
                    return Ok(titleResult);
                }
                return NotFound();
            }
            catch (Exception ex)
            {

                return Problem(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTitle([FromRoute] int id)
        {
            try
            {
                TitleResponse titleResult = await _service.DeleteTitle(id);

                if (titleResult != null)
                {
                    return Ok(titleResult);
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
