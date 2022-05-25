using H3LibraryProject.API.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace H3LibraryProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {


        ////private readonly  IAuthorService _service; 

        //public AuthorController(/*IAuthorService _service*/)
        //{
        //   // _service = service;
        //}

        //[HttpGet]
        //public async Task<IActionResult> GetAllAuthors()
        //{
        //    try
        //    {
        //        List<AuthorResponse> authorList = await _service.GetAllAuthors();
        //        if (authorList.Count > 0)
        //        {
        //            return Ok(authorList);
        //        }
        //        return NoContent();
        //    }
        //    catch (Exception ex)
        //    {

        //        return Problem(ex.Message);
        //    }
        //}



        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetAuthorById([FromRoute] int id)
        //{
        //    try
        //    {
        //        AuthorResponse author = await _service.GetAuthorById(id);
        //        if (author != null)
        //        {
        //            return Ok(author);
        //        }
        //        return NotFound();
        //    }
        //    catch (Exception ex)
        //    {

        //        return Problem(ex.Message);
        //    }
        //}

        //[HttpPost]
        //public async Task<IActionResult> CreateAuthor([FromBody] AuthorRequest newAuthor)
        //{
        //    try
        //    {
        //        AuthorResponse createdAuthor = await _service.CreateAuthor(newAuthor);
        //        if (createdAuthor == null)
        //        {
        //            return NotFound();
        //        }
        //        return Ok(createdAuthor);
        //    }
        //    catch (Exception ex)
        //    {

        //        return Problem(ex.Message);
        //    }
        //}

        //[HttpPut("{id}")]
        //public async Task<IActionResult> UpdateAuthor([FromRoute] int id, [FromBody] AuthorRequest author)
        //{
        //    if (id <= 0)
        //    {
        //        return BadRequest();
        //    }
        //    try
        //    {
        //        AuthorResponse authorResult = await _service.UpdateAuthor(id, author);
        //        if (authorResult != null)
        //        {
        //            return Ok(authorResult);
        //        }
        //        return NotFound();
        //    }
        //    catch (Exception ex)
        //    {

        //        return Problem(ex.Message);
        //    }
        //}

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteAuthor([FromRoute] int id)
        //{
        //    try
        //    {
        //        AuthorResponse authorResult = await _service.DeleteAuthor(id);

        //        if (authorResult != null)
        //        {
        //            return Ok(authorResult);
        //        }
        //        return NotFound();
        //    }
        //    catch (Exception ex)
        //    {

        //        return Problem(ex.Message);
        //    }
        //}
    }
}
