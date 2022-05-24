using H3LibraryProject.Repositories.Database;
using H3LibraryProject.Services.DTO;
using H3LibraryProject.Services.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace H3LibraryProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanerTypeController : ControllerBase
    {
        private readonly ILoanerTypeService _service;

        public LoanerTypeController(ILoanerTypeService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllLoanerTypes()
        {
            try
            {
                List<LoanerTypeResponse> loanerTypeList = await _service.GetAllLoanerTypes();
                if (loanerTypeList.Count > 0)
                {
                    return Ok(loanerTypeList);
                }
                return NoContent();
            }
            catch (Exception ex)
            {

                return Problem(ex.Message);
            }
        }

        

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLoanerTypeById([FromRoute] int id)
        {
            try
            {
                LoanerTypeResponse loanerType = await _service.GetLoanerTypeById(id);
                if (loanerType != null)
                {
                    return Ok(loanerType);
                }
                return NotFound();
            }
            catch (Exception ex)
            {

                return Problem(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateLoanerType([FromBody] LoanerTypeRequest newLoanerType)
        {
            try
            {
                LoanerTypeResponse createdLoanerType = await _service.CreateLoanerType(newLoanerType);
                if (createdLoanerType == null)
                {
                    return NotFound();
                }
                return Ok(createdLoanerType);
            }
            catch (Exception ex)
            {

                return Problem(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLoanerType([FromRoute] int id, [FromBody] LoanerTypeRequest loanerType)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            try
            {
                LoanerTypeResponse loanerTypeResult = await _service.UpdateLoanerType(id, loanerType);
                if (loanerTypeResult != null)
                {
                    return Ok(loanerTypeResult);
                }
                return NotFound();
            }
            catch (Exception ex)
            {

                return Problem(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLoanerType([FromRoute] int id)
        {
            try
            {
                LoanerTypeResponse loanerTypeResult = await _service.DeleteLoanerType(id);

                if (loanerTypeResult != null)
                {
                    return Ok(loanerTypeResult);
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
