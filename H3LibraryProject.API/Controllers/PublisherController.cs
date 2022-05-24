using H3LibraryProject.API.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace H3LibraryProject.API.Controllers
{
    public class PublisherController : ControllerBase
    {
        //private readonly  IPublisherService _service; 

        public PublisherController(/*IPublisherService _service*/)
        {
            // _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPublishers()
        {
            try
            {
                List<PublisherResponse> publisherList = await _service.GetAllPublishers();
                if (publisherList.Count > 0)
                {
                    return Ok(publisherList);
                }
                return NoContent();
            }
            catch (Exception ex)
            {

                return Problem(ex.Message);
            }
        }



        [HttpGet("{id}")]
        public async Task<IActionResult> GetPublisherById([FromRoute] int id)
        {
            try
            {
                PublisherResponse publisher = await _service.GetPublisherById(id);
                if (publisher != null)
                {
                    return Ok(publisher);
                }
                return NotFound();
            }
            catch (Exception ex)
            {

                return Problem(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreatePublisher([FromBody] PublisherRequest newPublisher)
        {
            try
            {
                PublisherResponse createdPublisher = await _service.CreatePublisher(newPublisher);
                if (createdPublisher == null)
                {
                    return NotFound();
                }
                return Ok(createdPublisher);
            }
            catch (Exception ex)
            {

                return Problem(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePublisher([FromRoute] int id, [FromBody] PublisherRequest publisher)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            try
            {
                PublisherResponse publisherResult = await _service.UpdatePublisher(id, publisher);
                if (publisherResult != null)
                {
                    return Ok(publisherResult);
                }
                return NotFound();
            }
            catch (Exception ex)
            {

                return Problem(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePublisher([FromRoute] int id)
        {
            try
            {
                PublisherResponse publisherResult = await _service.DeletePublisher(id);

                if (publisherResult != null)
                {
                    return Ok(publisherResult);
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
