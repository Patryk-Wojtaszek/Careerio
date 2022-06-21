using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Careerio.Authentication;
using Careerio.Data;
using Careerio.Dtos;
using Careerio.Exceptions;
using Careerio.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using AutoMapper;

namespace Careerio.Services
{
    public class AccountService : IAccount
    {
        private readonly CareerioDbContext _context;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly AuthenticationSettings _authenticationSettings;
        private readonly IMapper _mapper;

        public AccountService(CareerioDbContext context, IPasswordHasher<User> passwordHasher, AuthenticationSettings authenticationSettings, IMapper mapper)
        {
            _context = context;
            _passwordHasher = passwordHasher;
            _authenticationSettings = authenticationSettings;
            _mapper = mapper;
        }
        public string RegisterUser(RegisterUserDto dto)
        {
            var newUser = new User()
            {
                Email = dto.Email,
                Login = dto.Login,
                RoleId = dto.RoleId

            };
            var hashedPassword = _passwordHasher.HashPassword(newUser, dto.Password);
            newUser.PasswordHash = hashedPassword;
            _context.Users.Add(newUser);
            _context.SaveChanges();
            var user = _context.Users
                .Include(x => x.Role)
                .FirstOrDefault(x => x.Login == dto.Login);

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name,$"{user.Login}"),
                new Claim(ClaimTypes.Role,$"{user.Role.Name}")
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationSettings.JwtKey));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(_authenticationSettings.JwtExpireDays);

            var token = new JwtSecurityToken(_authenticationSettings.JwtIssuer, _authenticationSettings.JwtIssuer,
                claims, expires: expires, signingCredentials: cred);

            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenString = tokenHandler.WriteToken(token);
            GetUserByToken(tokenString);
            return tokenHandler.WriteToken(token);

        }
        public string GenerateJwt(LoginDto dto)
        {
            var user = _context.Users
                .Include(x => x.Role)
                .FirstOrDefault(x => x.Login == dto.Login);
            if (user is null)
            {
                throw new BadRequestException("Niepoprawny login lub hasło.");
            }
            var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, dto.Password);
            if (result == PasswordVerificationResult.Failed)
            {
                throw new BadRequestException("Niepoprawny login lub hasło.");
            }
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name,$"{user.Login}"),
                new Claim(ClaimTypes.Role,$"{user.Role.Name}")
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationSettings.JwtKey));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(_authenticationSettings.JwtExpireDays);

            var token = new JwtSecurityToken(_authenticationSettings.JwtIssuer, _authenticationSettings.JwtIssuer,
                claims, expires: expires, signingCredentials: cred);

            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(token);
        }

        public UserDto GetUser(int id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            var userDto = _mapper.Map<UserDto>(user);
            return userDto;
        }

        public UserDto GetUserByToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var id = int.Parse(tokenHandler.ReadJwtToken(token).Claims.First(c => c.Type== ClaimTypes.NameIdentifier).Value);
            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            var userDto = _mapper.Map<UserDto>(user);
            return userDto;
            
              
        }
    }

}
