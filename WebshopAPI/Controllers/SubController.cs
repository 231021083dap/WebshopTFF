using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebshopAPI.DTO;
using WebshopAPI.Responses;
using WebshopAPI.Services;

namespace WebshopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubController : ControllerBase
    {
        private readonly ISubService _subService;

        public SubController(ISubService subService)
        {
            _subService = subService;
        }

        //Get Request
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                //Return 500 code
                List<SubResponse> Subs = await _subService.GetAllSubs();
                if (Subs == null)
                {
                    return Problem("Got Nothing.. Unexpected");
                }
                //Return 204 code
                if (Subs.Count == 0)
                {
                    return NoContent();
                }

                //Return 200 code
                return Ok(Subs);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        //GetById
        [HttpGet("{SubId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> GetById([FromRoute] int SubId)
        {
            try
            {
                SubResponse Sub = await _subService.GetById(SubId);
                if (Sub == null)
                {
                    return NotFound();
                }
                return Ok(Sub);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        //Create
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] NewSubCategory newSub)
        {
            try
            {
                SubResponse Sub = await _subService.Create(newSub);

                if (Sub == null)
                {
                    return Problem("Sub Category was not created, unexpected");
                }
                return Ok(Sub);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        //Update
        [HttpPut("{SubId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update([FromRoute] int SubId, [FromBody] UpdateSubCategory updateSub)
        {
            try
            {
                SubResponse Sub = await _subService.Update(SubId, updateSub);

                if (Sub == null)
                {
                    return Problem("Sub Category was not updated, unexpected");
                }
                return Ok(Sub);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
        //Delete
        [HttpDelete("{SubId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete([FromRoute] int SubId)
        {
            try
            {
                bool result = await _subService.Delete(SubId);

                if (!result)
                {
                    return Problem("Sub Category was not deleted, unexpected");
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
