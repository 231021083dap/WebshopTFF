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
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersService _orderService;

        public OrdersController(IOrdersService orderService)
        {
            _orderService = orderService;
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
                List<OrderResponse> Orders = await _orderService.GetAllOrders();
                if (Orders == null)
                {
                    return Problem("Got Nothing.. Unexpected");
                }
                //Return 204 code
                if (Orders.Count == 0)
                {
                    return NoContent();
                }

                //Return 200 code
                return Ok(Orders);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        //GetById
        [HttpGet("{OrderId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> GetById([FromRoute] int OrderId)
        {
            try
            {
                OrderResponse Order = await _orderService.GetById(OrderId);
                if (Order == null)
                {
                    return NotFound();
                }
                return Ok(Order);
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
        public async Task<IActionResult> Create([FromBody] NewOrder newOrder)
        {
            try
            {
                OrderResponse Order = await _orderService.Create(newOrder);

                if (Order == null)
                {
                    return Problem("Order was not created, unexpected");
                }
                return Ok(Order);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        //Update
        [HttpPut("{OrderId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update([FromRoute] int OrderId, [FromBody] UpdateOrder updateOrder)
        {
            try
            {
                OrderResponse Order = await _orderService.Update(OrderId, updateOrder);

                if (Order == null)
                {
                    return Problem("Order was not updated, unexpected");
                }
                return Ok(Order);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
        //Delete
        [HttpDelete("{OrderId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete([FromRoute] int OrderId)
        {
            try
            {
                bool result = await _orderService.Delete(OrderId);

                if (!result)
                {
                    return Problem("Order was not deleted, unexpected");
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
