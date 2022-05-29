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
    public class NationalityController : ControllerBase
    {
        private readonly INationalityService _service;

        public NationalityController(INationalityService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllNationalitys()
        {
            try
            {
                List<NationalityResponse> nationalityList = await _service.GetAllNationalitys();
                if (nationalityList.Count > 0)
                {
                    return Ok(nationalityList);
                }
                return NoContent();
            }
            catch (Exception ex)
            {

                return Problem(ex.Message);
            }
        }



        [HttpGet("{id}")]
        public async Task<IActionResult> GetNationalityById([FromRoute] int id)
        {
            try
            {
                NationalityResponse nationality = await _service.GetNationalityById(id);
                if (nationality != null)
                {
                    return Ok(nationality);
                }
                return NotFound();
            }
            catch (Exception ex)
            {

                return Problem(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateNationality([FromBody] NationalityRequest newNationality)
        {
            try
            {
                NationalityResponse createdNationality = await _service.CreateNationality(newNationality);
                if (createdNationality == null)
                {
                    return NotFound();
                }
                return Ok(createdNationality);
            }
            catch (Exception ex)
            {

                return Problem(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateNationality([FromRoute] int id, [FromBody] NationalityRequest nationality)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            try
            {
                NationalityResponse nationalityResult = await _service.UpdateNationality(id, nationality);
                if (nationalityResult != null)
                {
                    return Ok(nationalityResult);
                }
                return NotFound();
            }
            catch (Exception ex)
            {

                return Problem(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNationality([FromRoute] int id)
        {
            try
            {
                NationalityResponse nationalityResult = await _service.DeleteNationality(id);

                if (nationalityResult != null)
                {
                    return Ok(nationalityResult);
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
