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
    public class MaterialController : ControllerBase
    {
        private readonly  IMaterialService _service; 

        public MaterialController(IMaterialService service)
        {
             _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMaterials([FromQuery] string searchTitle = "", [FromQuery] string location = "", [FromQuery] string genre = "", [FromQuery] string author = "")
        {
            
            try
            {
                List<MaterialResponse> materialList;
                if (searchTitle == null && location == null && genre == null && author == null)
                {
                    materialList = await _service.GetAllMaterials();
                }

                else
                {
                    materialList = await _service.SearchMaterial(searchTitle, location, genre, author);
                }

                if (materialList.Count > 0)
                {
                    return Ok(materialList);
                }
                return NoContent();
            }
            catch (Exception ex)
            {

                return Problem(ex.Message);
            }
        }



        [HttpGet("{id}")]
        public async Task<IActionResult> GetMaterialById([FromRoute] int id)
        {
            try
            {
                MaterialResponse material = await _service.GetMaterialById(id);
                if (material != null)
                {
                    return Ok(material);
                }
                return NotFound();
            }
            catch (Exception ex)
            {

                return Problem(ex.Message);
            }
        }

        [HttpGet("search/{searchText}")]
        public async Task<IActionResult> GetMaterialBySearch([FromQuery] string searchTitle = "", [FromQuery] string location = "", [FromQuery] string genre = "", [FromQuery] string author = "")
        {
            if (searchTitle == "" && location == "" && genre == "" && author == "")
            {
                return BadRequest();
            }
            try
            {
                List<MaterialResponse> materials = await _service.SearchMaterial(searchTitle, location, genre, author);
                if (materials.Count > 0)
                {
                    return Ok(materials);
                }
                return NoContent();
            }
            catch (Exception ex)
            {

                return Problem(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateMaterial([FromBody] MaterialRequest newMaterial)
        {
            try
            {
                MaterialResponse createdMaterial = await _service.CreateMaterial(newMaterial);
                if (createdMaterial == null)
                {
                    return NotFound();
                }
                return Ok(createdMaterial);
            }
            catch (Exception ex)
            {

                return Problem(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMaterial([FromRoute] int id, [FromBody] MaterialRequest material)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            try
            {
                MaterialResponse materialResult = await _service.UpdateMaterial(id, material);
                if (materialResult != null)
                {
                    return Ok(materialResult);
                }
                return NotFound();
            }
            catch (Exception ex)
            {

                return Problem(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMaterial([FromRoute] int id)
        {
            try
            {
                MaterialResponse materialResult = await _service.DeleteMaterial(id);

                if (materialResult != null)
                {
                    return Ok(materialResult);
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
