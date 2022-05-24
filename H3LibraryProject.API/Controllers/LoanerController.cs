using H3LibraryProject.API.DTOs;
using H3LibraryProject.Services.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace H3LibraryProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanerController : ControllerBase
    {
        private readonly ILoanerService _service;

        public LoanerController(ILoanerService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLoaners()
        {
            try
            {
                List<LoanerResponse> loanerList = await _service.GetAllLoaners();
                if (loanerList.Count > 0)
                {
                    return Ok(loanerList);
                }
                return NoContent();
            }
            catch (Exception ex)
            {

                return Problem(ex.Message);
            }
        }



        [HttpGet("{id}")]
        public async Task<IActionResult> GetLoanerById([FromRoute] int id)
        {
            try
            {
                LoanerResponse loaner = await _service.GetLoanerById(id);
                if (loaner != null)
                {
                    return Ok(loaner);
                }
                return NotFound();
            }
            catch (Exception ex)
            {

                return Problem(ex.Message);
            }
        }

        //[HttpGet("{name}")]
        //public async Task<IActionResult> GetLoanerByName([FromRoute] string name)
        //{
        //    try
        //    {
        //        List<LoanerResponse> loanerList = await _service.GetLoanerByName(name);
        //        if (loanerList != null)
        //        {
        //            return Ok(loanerList);
        //        }
        //        return NotFound();
        //    }
        //    catch (Exception ex)
        //    {

        //        return Problem(ex.Message);
        //    }
        //}

        [HttpPost]
        public async Task<IActionResult> CreateLoaner([FromBody] LoanerRequest newLoaner)
        {
            try
            {
                LoanerResponse createdLoaner = await _service.CreateLoaner(newLoaner);
                if (createdLoaner == null)
                {
                    return NotFound();
                }
                return Ok(createdLoaner);
            }
            catch (Exception ex)
            {

                return Problem(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLoaner([FromRoute] int id, [FromBody] LoanerRequest loaner)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            try
            {
                LoanerResponse loanerResult = await _service.UpdateLoaner(id, loaner);
                if (loanerResult != null)
                {
                    return Ok(loanerResult);
                }
                return NotFound();
            }
            catch (Exception ex)
            {

                return Problem(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLoaner([FromRoute] int id)
        {
            try
            {
                LoanerResponse loanerResult = await _service.DeleteLoaner(id);

                if (loanerResult != null)
                {
                    return Ok(loanerResult);
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
