using H3LibraryProject.Repositories.Database;
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
                List<LoanerType> LoanerTypeList = await _service.GetAllLoanerTypes();
                if (LoanerTypeList.Count > 0)
                {
                    return Ok(LoanerTypeList);
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
                LoanerType loanerType = await _service.GetLoanerTypeById(id);
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
        public async Task<IActionResult> CreateLoanerType([FromBody] LoanerType newLoanerType)
        {
            try
            {
                LoanerType createdLoanerType = await _service.CreateLoanerType(newLoanerType);
                if (createdLoanerType == null)
                {
                    return NotFound();
                }
                return Ok(createdLoanerType);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
