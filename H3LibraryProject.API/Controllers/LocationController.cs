using H3LibraryProject.API.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace H3LibraryProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        ////private readonly  ILocationService _service; 

        //public LocationController(/*ILocationService _service*/)
        //{
        //    // _service = service;
        //}

        //[HttpGet]
        //public async Task<IActionResult> GetAllLocations()
        //{
        //    try
        //    {
        //        List<LocationResponse> locationList = await _service.GetAllLocations();
        //        if (locationList.Count > 0)
        //        {
        //            return Ok(locationList);
        //        }
        //        return NoContent();
        //    }
        //    catch (Exception ex)
        //    {

        //        return Problem(ex.Message);
        //    }
        //}



        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetLocationById([FromRoute] int id)
        //{
        //    try
        //    {
        //        LocationResponse location = await _service.GetLocationById(id);
        //        if (location != null)
        //        {
        //            return Ok(location);
        //        }
        //        return NotFound();
        //    }
        //    catch (Exception ex)
        //    {

        //        return Problem(ex.Message);
        //    }
        //}

        //[HttpPost]
        //public async Task<IActionResult> CreateLocation([FromBody] LocationRequest newLocation)
        //{
        //    try
        //    {
        //        LocationResponse createdLocation = await _service.CreateLocation(newLocation);
        //        if (createdLocation == null)
        //        {
        //            return NotFound();
        //        }
        //        return Ok(createdLocation);
        //    }
        //    catch (Exception ex)
        //    {

        //        return Problem(ex.Message);
        //    }
        //}

        //[HttpPut("{id}")]
        //public async Task<IActionResult> UpdateLocation([FromRoute] int id, [FromBody] LocationRequest location)
        //{
        //    if (id <= 0)
        //    {
        //        return BadRequest();
        //    }
        //    try
        //    {
        //        LocationResponse locationResult = await _service.UpdateLocation(id, location);
        //        if (locationResult != null)
        //        {
        //            return Ok(locationResult);
        //        }
        //        return NotFound();
        //    }
        //    catch (Exception ex)
        //    {

        //        return Problem(ex.Message);
        //    }
        //}

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteLocation([FromRoute] int id)
        //{
        //    try
        //    {
        //        LocationResponse locationResult = await _service.DeleteLocation(id);

        //        if (locationResult != null)
        //        {
        //            return Ok(locationResult);
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
