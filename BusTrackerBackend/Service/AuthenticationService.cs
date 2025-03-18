using AutoMapper;
using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Service.Contracts;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Service
{
    internal sealed class AuthenticationService : IAuthenticationService
    {
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;

        private User? _user;

        public AuthenticationService(ILoggerManager logger, IMapper mapper,
        UserManager<User> userManager, IConfiguration configuration)
        {
            _logger = logger;
            _mapper = mapper;
            _userManager = userManager;
            _configuration = configuration;
        }

        //public async Task<IdentityResult> RegisterUser(UserForRegistrationDto userForRegistration)
        //{
        //    var user = _mapper.Map<User>(userForRegistration);

        //    var result = await _userManager.CreateAsync(user,
        //    userForRegistration.Password);

        //    if (result.Succeeded)
        //        await _userManager.AddToRolesAsync(user, userForRegistration.Roles);
        //    return result;
        //}

        public async Task<IdentityResult> RegisterUser(UserForRegistrationDto userForRegistration)
        {
            // Map the DTO to the User entity
            var user = _mapper.Map<User>(userForRegistration);

            // Create the user
            var result = await _userManager.CreateAsync(user, userForRegistration.Password);

            if (result.Succeeded)
            {
                // Assign roles to the user
                var roleResult = await _userManager.AddToRolesAsync(user, userForRegistration.Roles);

                if (!roleResult.Succeeded)
                {
                    return IdentityResult.Failed(roleResult.Errors.ToArray()); // Return errors if role assignment fails
                }
            }

            return result;
        }


        public async Task<bool> ValidateUser(UserForAuthenticationDto userForAuth)
        {
            _user = await _userManager.FindByNameAsync(userForAuth.UserName);

            var result = (_user != null && await _userManager.CheckPasswordAsync(_user, userForAuth.Password));
            if (!result)
                _logger.LogWarn($"{nameof(ValidateUser)}: Authentication failed. Wrong user name or password.");

            return result;
        }

        public async Task<string> CreateToken()
        {
            var signingCredentials = GetSigningCredentials();
            var claims = await GetClaims();

            // Add FirstName claim if not already included
            claims.Add(new Claim("FirstName", _user.FirstName));  // Add FirstName here

            var tokenOptions = GenerateTokenOptions(signingCredentials, claims);

            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        }



        private SigningCredentials GetSigningCredentials()
        {
            var key = Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("SECRET"));
            var secret = new SymmetricSecurityKey(key);

            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        private async Task<List<Claim>> GetClaims()
        {
            var claims = new List<Claim> 
            {
                new Claim(ClaimTypes.Name, _user.UserName),
                new Claim("FirstName", _user.FirstName)  
            };


            var roles = await _userManager.GetRolesAsync(_user);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            return claims;
        }

        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");

            var tokenOptions = new JwtSecurityToken
            (
                issuer: jwtSettings["validIssuer"],
                audience: jwtSettings["validAudience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings["expires"])),
                signingCredentials: signingCredentials
            );

            return tokenOptions;
        }

        public async Task<List<Claim>> GetUserRoleClaims(UserForAuthenticationDto userForAuth)
        {
            var result = await ValidateUser(userForAuth);

            if (!result)
                throw new UnauthorizedAccessException("Invalid credentials");

            return await GetClaims();
        }

        public async Task<UserDetailsDto> GetUserDetailsAsync(string username)
        {
            // Retrieve the user from the database
            var user = await _userManager.FindByNameAsync(username);

            if (user == null)
            {
                throw new UnauthorizedAccessException("User not found");
            }

            // Map the user details to the UserDetailsDto
            var userDetails = new UserDetailsDto
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Roles = await _userManager.GetRolesAsync(user) // Get roles associated with the user
            };

            return userDetails; // Return the UserDetailsDto
        }


    }
}
