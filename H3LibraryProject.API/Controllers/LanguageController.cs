using H3LibraryProject.API.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace H3LibraryProject.API.Controllers
{
    public class LanguageController : ControllerBase
    {
        //private readonly  ILanguageService _service; 

        public LanguageController(/*ILanguageService _service*/)
        {
            // _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLanguages()
        {
            try
            {
                List<LanguageResponse> languageList = await _service.GetAllLanguages();
                if (languageList.Count > 0)
                {
                    return Ok(languageList);
                }
                return NoContent();
            }
            catch (Exception ex)
            {

                return Problem(ex.Message);
            }
        }



        [HttpGet("{id}")]
        public async Task<IActionResult> GetLanguageById([FromRoute] int id)
        {
            try
            {
                LanguageResponse language = await _service.GetLanguageById(id);
                if (language != null)
                {
                    return Ok(language);
                }
                return NotFound();
            }
            catch (Exception ex)
            {

                return Problem(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateLanguage([FromBody] LanguageRequest newLanguage)
        {
            try
            {
                LanguageResponse createdLanguage = await _service.CreateLanguage(newLanguage);
                if (createdLanguage == null)
                {
                    return NotFound();
                }
                return Ok(createdLanguage);
            }
            catch (Exception ex)
            {

                return Problem(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLanguage([FromRoute] int id, [FromBody] LanguageRequest language)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            try
            {
                LanguageResponse languageResult = await _service.UpdateLanguage(id, language);
                if (languageResult != null)
                {
                    return Ok(languageResult);
                }
                return NotFound();
            }
            catch (Exception ex)
            {

                return Problem(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLanguage([FromRoute] int id)
        {
            try
            {
                LanguageResponse languageResult = await _service.DeleteLanguage(id);

                if (languageResult != null)
                {
                    return Ok(languageResult);
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
