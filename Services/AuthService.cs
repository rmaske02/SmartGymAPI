using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SmartGymAPI.Data;
using SmartGymAPI.DTOs;
using SmartGymAPI.Helpers;
using SmartGymAPI.Model;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SmartGymAPI.Services
{
    public class AuthService : IAuthService
    {

        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _config;

        public AuthService(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _config = configuration;
        }

        public async Task<string> Register(RegisterDTO registerDTO)
        {
            var exists = await _context.Users.AnyAsync(u=>u.Email == registerDTO.Email) ;
            if (exists)
            {
                return $"{registerDTO.Email} already exists!!" ;
            }

            var user = new User
            {
                Name = registerDTO.Name,
                Email = registerDTO.Email,
                PasswordHash = PasswordHelper.HashPassword(registerDTO.Password),
                Role = string.IsNullOrEmpty(registerDTO.Role)?"User":registerDTO.Role,
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return $"{user.Name} is Register Successfully!";
        }

        public async Task<string> Login(LoginDTO loginDTO)
        {
            var user = await _context.Users.FirstOrDefaultAsync(a=>a.Email == loginDTO.Email);
            if (user == null)
            {
                return "Invalid Credentials";
            }
            var hashed = PasswordHelper.HashPassword(loginDTO.Password);
            if (user.PasswordHash != hashed)
            {
                return "Invalid Credentials!";
            }
            return GenereateJwtToken(user);
        }

        private string GenereateJwtToken(User user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JwtSettings:Key"]));

            var creds = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Role, user.Role),
            };

            var token = new JwtSecurityToken(
                issuer: _config["JwtSettings:Issuer"],
                audience: _config["JwtSettings:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(2),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
