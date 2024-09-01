using FitnessWorkoutTracker.Application.Common.Models;
using FitnessWorkoutTracker.Application.Services.Interfaces;
using FitnessWorkoutTracker.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FitnessWorkoutTracker.Infrastructure.Implementations
{
    public class AuthService : IAuthService
    {
        // inject Identity Managers
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _configuration;

        public AuthService(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
            _signInManager = signInManager;
        }

        public async Task<string> GenerateJwtToken(ApplicationUser user, IEnumerable<string> roles)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_configuration["JwtSettings:Key"]);
                var issuer = _configuration["JwtSettings:Issuer"];
                var audience = _configuration["JwtSettings:Audience"];

                var claimList = new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.Sub, user.Id),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                    new Claim(JwtRegisteredClaimNames.Name, user.FullName),
                };

                claimList.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Audience = audience,
                    Issuer = issuer,
                    IssuedAt = DateTime.UtcNow,
                    Expires = DateTime.UtcNow.AddHours(12),
                    Subject = new ClaimsIdentity(claimList),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);
                return tokenHandler.WriteToken(token);
            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<string> LoginAsync(LoginModel model)
        {
            try
            {
                // sign in this user
                await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);

                // getting this user
                var user = await _userManager.FindByEmailAsync(model.Email);

                // getting role this user
                var roles = await _userManager.GetRolesAsync(user);

                // return token
                return GenerateJwtToken(user, roles).GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task RegisterAsync(RegisterModel model)
        {
            try
            {
                ApplicationUser user = new()
                {
                    Email = model.Email,
                    FullName = model.FullName,
                    UserName = model.Email
                };

                // create user
                await _userManager.CreateAsync(user, model.Password);

                // assign role
                await _userManager.AddToRoleAsync(user, model.RoleName);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
