using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebshopAPI.DTO;
using WebshopAPI.Helpers;
using WebshopAPI.Responses;
using WebshopAPI.Services;
using WebshopAPI.Authorization;

namespace WebshopAPI.Controllers
{
    [Authorize]
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
        [Authorize(Role.Admin)]   
        [AllowAnonymous]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAll()
        {

            var currentUser = (UserResponse)HttpContext.Items["User"];
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

        //GetById
        [Authorize(Role.Customer, Role.Employee, Role.Admin, Role.SuperUser)]
        [HttpGet("{UserId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> GetById([FromRoute] int UserId)
        {
            try
            {
                var currentUser = (UserResponse)HttpContext.Items["User"];
                if (currentUser == null                    
                    || (UserId != currentUser.UserId && currentUser.Role != Role.Admin)
                    || (UserId != currentUser.UserId && currentUser.Role != Role.SuperUser))
                {
                    return Unauthorized(new { message = "Unauthorized" });
                }
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

        [AllowAnonymous]
        [HttpPost("authenticate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Authenticate(NewLogin login)
        {
            try
            {
                LoginResponse response = await _userService.Authenticate(login);

                if (response == null)
                {
                    return Unauthorized();
                }

                return Ok(response);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

    }
}
