using H3LibraryProject.API.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace H3LibraryProject.API.Controllers
{
    public class LoanController : ControllerBase
    {//private readonly  ILoanService _service; 

        public LoanController(/*ILoanService _service*/)
        {
            // _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLoans()
        {
            try
            {
                List<LoanResponse> loanList = await _service.GetAllLoans();
                if (loanList.Count > 0)
                {
                    return Ok(loanList);
                }
                return NoContent();
            }
            catch (Exception ex)
            {

                return Problem(ex.Message);
            }
        }



        [HttpGet("{id}")]
        public async Task<IActionResult> GetLoanById([FromRoute] int id)
        {
            try
            {
                LoanResponse loan = await _service.GetLoanById(id);
                if (loan != null)
                {
                    return Ok(loan);
                }
                return NotFound();
            }
            catch (Exception ex)
            {

                return Problem(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateLoan([FromBody] LoanRequest newLoan)
        {
            try
            {
                LoanResponse createdLoan = await _service.CreateLoan(newLoan);
                if (createdLoan == null)
                {
                    return NotFound();
                }
                return Ok(createdLoan);
            }
            catch (Exception ex)
            {

                return Problem(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLoan([FromRoute] int id, [FromBody] LoanRequest loan)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            try
            {
                LoanResponse loanResult = await _service.UpdateLoan(id, loan);
                if (loanResult != null)
                {
                    return Ok(loanResult);
                }
                return NotFound();
            }
            catch (Exception ex)
            {

                return Problem(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLoan([FromRoute] int id)
        {
            try
            {
                LoanResponse loanResult = await _service.DeleteLoan(id);

                if (loanResult != null)
                {
                    return Ok(loanResult);
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
