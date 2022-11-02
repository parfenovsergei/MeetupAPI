using MeetupAPI.DAL.Interfaces;
using MeetupAPI.Domain.Entity;
using MeetupAPI.Domain.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MeetupAPI.BLL.Services.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly IBaseRepository<User> _userRepository;
        private readonly IConfiguration _configuration;
        public AuthService(IBaseRepository<User> userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        public async Task<string> Register(User user)
        {
            try
            {
                var checkUser = await _userRepository.GetAll().FirstOrDefaultAsync(u => u.Email == user.Email);
                if (checkUser != null)
                    return "Пользователь с таким email уже существует.";

                User newUser = new User
                {
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Password = HashPasswordHelper.HashPassowrd(user.Password),
                    Role = "User"
                };

                await _userRepository.Create(newUser);

                return "Регистрация прошла успешно";
            }
            catch (Exception)
            {
                return "Ошибка регистрации";
            }
        }

        public async Task<string> Login(User user)
        {
            try
            {
                var loginUser = await _userRepository.GetAll().FirstOrDefaultAsync(u => u.Email == user.Email);
                if (loginUser == null)
                    return "Пользователь не найден.";

                if (loginUser.Password != HashPasswordHelper.HashPassowrd(user.Password))
                    return "Неверный пароль.";

                string token = CreateToken(loginUser);

                return token;
            }
            catch (Exception)
            {
                return "Ошибка входа.";
            }
        }

        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Email),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(20),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}
