using H3LibraryProject.API.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace H3LibraryProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialController : ControllerBase
    {
        ////private readonly  IMaterialService _service; 

        //public MaterialController(/*IMaterialService _service*/)
        //{
        //    // _service = service;
        //}

        //[HttpGet]
        //public async Task<IActionResult> GetAllMaterials()
        //{
        //    try
        //    {
        //        List<MaterialResponse> materialList = await _service.GetAllMaterials();
        //        if (materialList.Count > 0)
        //        {
        //            return Ok(materialList);
        //        }
        //        return NoContent();
        //    }
        //    catch (Exception ex)
        //    {

        //        return Problem(ex.Message);
        //    }
        //}



        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetMaterialById([FromRoute] int id)
        //{
        //    try
        //    {
        //        MaterialResponse material = await _service.GetMaterialById(id);
        //        if (material != null)
        //        {
        //            return Ok(material);
        //        }
        //        return NotFound();
        //    }
        //    catch (Exception ex)
        //    {

        //        return Problem(ex.Message);
        //    }
        //}

        //[HttpPost]
        //public async Task<IActionResult> CreateMaterial([FromBody] MaterialRequest newMaterial)
        //{
        //    try
        //    {
        //        MaterialResponse createdMaterial = await _service.CreateMaterial(newMaterial);
        //        if (createdMaterial == null)
        //        {
        //            return NotFound();
        //        }
        //        return Ok(createdMaterial);
        //    }
        //    catch (Exception ex)
        //    {

        //        return Problem(ex.Message);
        //    }
        //}

        //[HttpPut("{id}")]
        //public async Task<IActionResult> UpdateMaterial([FromRoute] int id, [FromBody] MaterialRequest material)
        //{
        //    if (id <= 0)
        //    {
        //        return BadRequest();
        //    }
        //    try
        //    {
        //        MaterialResponse materialResult = await _service.UpdateMaterial(id, material);
        //        if (materialResult != null)
        //        {
        //            return Ok(materialResult);
        //        }
        //        return NotFound();
        //    }
        //    catch (Exception ex)
        //    {

        //        return Problem(ex.Message);
        //    }
        //}

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteMaterial([FromRoute] int id)
        //{
        //    try
        //    {
        //        MaterialResponse materialResult = await _service.DeleteMaterial(id);

        //        if (materialResult != null)
        //        {
        //            return Ok(materialResult);
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
