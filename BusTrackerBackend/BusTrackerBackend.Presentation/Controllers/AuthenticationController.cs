using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BusTrackerBackend.Presentation.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IServiceManager _service;
        public AuthenticationController(IServiceManager service) => _service = service;

        //[HttpPost]
        //public async Task<IActionResult> RegisterUser([FromBody] UserForRegistrationDto userForRegistration)
        //{
        //    var result = await
        //    _service.AuthenticationService.RegisterUser(userForRegistration);
        //    if (!result.Succeeded)
        //    {
        //        foreach (var error in result.Errors)
        //        {
        //            ModelState.TryAddModelError(error.Code, error.Description);
        //        }
        //        return BadRequest(ModelState);
        //    }
        //    return StatusCode(201);
        //}

        [HttpPost]
        public async Task<IActionResult> RegisterUser([FromBody] UserForRegistrationDto userForRegistration)
        {
            // Check if Roles is null or empty and set default role to "customer"
            if (userForRegistration.Roles == null || !userForRegistration.Roles.Any())
            {
                userForRegistration = userForRegistration with { Roles = new List<string> { "customer" } }; // Default to customer role
            }

            var result = await _service.AuthenticationService.RegisterUser(userForRegistration);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }

            return StatusCode(201);
        }


        //[HttpPost("login")]
        //public async Task<IActionResult> Authenticate([FromBody] UserForAuthenticationDto user)
        //{
        //    if (!await _service.AuthenticationService.ValidateUser(user))
        //        return Unauthorized();

        //    return Ok(new
        //    {
        //        Token = await _service
        //        .AuthenticationService.CreateToken()
        //    });
        //}
        [HttpPost("login")]
        public async Task<IActionResult> Authenticate([FromBody] UserForAuthenticationDto user)
        {
            List<Claim> claims;
            try
            {
                // Validate user and retrieve claims
                claims = await _service.AuthenticationService.GetUserRoleClaims(user);
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized("Invalid username or password");
            }

            // Generate the JWT token (which already includes the role and first name in claims)
            var token = await _service.AuthenticationService.CreateToken();

            // Extract role and first name from claims
            var role = claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
            var firstName = claims.FirstOrDefault(c => c.Type == "FirstName")?.Value;

            // Return the token, role, and firstName in the response
            return Ok(new
            {
                Token = token,
                Role = role,
                FirstName = firstName // This should now correctly return the first name
            });
        }




        [HttpGet("users")]
        public async Task<IActionResult> GetUserDetails()
        {
            var username = User.Identity?.Name; // Get the username from token claims

            if (username == null)
                return Unauthorized("User not authenticated");

            try
            {
                // Get user details using the GetUserDetailsAsync method
                var userDetails = await _service.AuthenticationService.GetUserDetailsAsync(username);
                return Ok(userDetails); // Return the user details
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized("User not found");
            }
        }


    }

}
