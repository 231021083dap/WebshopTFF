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
    public class ItemController : ControllerBase
    {
        private readonly IItemService _itemService;

        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
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
                List<ItemResponse> Items = await _itemService.GetAllItems();
                if (Items == null)
                {
                    return Problem("Got Nothing.. Unexpected");
                }
                //Return 204 code
                if (Items.Count == 0)
                {
                    return NoContent();
                }

                //Return 200 code
                return Ok(Items);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpGet("OnSale")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllOnSale()
        {
            try
            {
                //Return 500 code
                List<ItemResponse> Items = await _itemService.GetAllOnSale();
                if (Items == null)
                {
                    return Problem("Got Nothing.. Unexpected");
                }
                //Return 204 code
                if (Items.Count == 0)
                {
                    return NoContent();
                }

                //Return 200 code
                return Ok(Items);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        //GetById
        [HttpGet("{ItemId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> GetById([FromRoute] int ItemId)
        {
            try
            {
                ItemResponse Item = await _itemService.GetById(ItemId);
                if (Item == null)
                {
                    return NotFound();
                }
                return Ok(Item);
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
        public async Task<IActionResult> Create([FromBody] NewItem newItem)
        {
            try
            {
                ItemResponse Item = await _itemService.Create(newItem);

                if (Item == null)
                {
                    return Problem("Item was not created, unexpected");
                }
                return Ok(Item);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        //Update
        [HttpPut("{ItemId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update([FromRoute] int ItemId, [FromBody] UpdateItem updateItem)
        {
            try
            {
                ItemResponse Item = await _itemService.Update(ItemId, updateItem);

                if (Item == null)
                {
                    return Problem("Item was not updated, unexpected");
                }
                return Ok(Item);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
        //Delete
        [HttpDelete("{ItemId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete([FromRoute] int ItemId)
        {
            try
            {
                bool result = await _itemService.Delete(ItemId);

                if (!result)
                {
                    return Problem("Item was not deleted, unexpected");
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
