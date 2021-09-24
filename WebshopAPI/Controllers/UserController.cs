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
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
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
                List<UserResponse> Users = await _userService.GetAllUsers();
                if (Users == null)
                {
                    return Problem("Got Nothing.. Unexpected");
                }
                //Return 204 code
                if (Users.Count == 0)
                {
                    return NoContent();
                }

                //Return 200 code
                return Ok(Users);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpGet("Roles")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetUserRoles()
        {
            try
            {
                //Return 500 code
                List<UserRoleResponse> Roles = await _userService.GetUserRoles();
                if (Roles == null)
                {
                    return Problem("Got Nothing.. Unexpected");
                }
                //Return 204 code
                if (Roles.Count == 0)
                {
                    return NoContent();
                }

                //Return 200 code
                return Ok(Roles);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        //GetById
        [HttpGet("{UserId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> GetById([FromRoute] int UserId)
        {
            try
            {
                UserResponse User = await _userService.GetById(UserId);
                if (User == null)
                {
                    return NotFound();
                }
                return Ok(User);
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
        public async Task<IActionResult> Create([FromBody] NewUser newUser)
        {
            try
            {
                UserResponse User = await _userService.Create(newUser);

                if (User == null)
                {
                    return Problem("User was not created, unexpected");
                }
                return Ok(User);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        //Update
        [HttpPut("{UserId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update([FromRoute] int UserId, [FromBody] UpdateUser updateUser)
        {
            try
            {
                UserResponse User = await _userService.Update(UserId, updateUser);

                if (User == null)
                {
                    return Problem("User was not updated, unexpected");
                }
                return Ok(User);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
        //Delete
        [HttpDelete("{UserId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete([FromRoute] int UserId)
        {
            try
            {
                bool result = await _userService.Delete(UserId);

                if (!result)
                {
                    return Problem("User was not deleted, unexpected");
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
