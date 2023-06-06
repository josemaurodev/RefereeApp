using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RefereeAPI.Data;
using RefereeAPI.DTOs;
using RefereeAPI.Entities;
using RefereeAPI.Interfaces;
using RefereeAPI.Services;

namespace RefereeAPI.Controllers
{

    public class AccountController : BaseApiController
    {
        private readonly DataContext _context;
        private readonly ITokenService _tokenService;

        public AccountController(DataContext context, ITokenService tokenService )
        {
            _context = context;
            _tokenService = tokenService;
        }

        [HttpPost("register")] // POST: api/account/register?username=dave&&password=pwd
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            if(await UsersExists(registerDto.Username))
                return BadRequest("Username is taken");

            using var hmac = new HMACSHA512();

            var user = new AppUser{
                UserName = registerDto.Username.ToLower(),
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
                PasswordSalt = hmac.Key
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return new UserDto
            {
                Username = user.UserName,
                Token = _tokenService.CreateToken(user)
            };
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            //CACTHES USERNAME
            var user = await _context.Users.SingleOrDefaultAsync(x => x.UserName == loginDto.Username.ToLower());

            //TEST IF USERNAME IS VALID
            if(user == null)
                return Unauthorized("Invalid Username");

            using var hmac = new HMACSHA512(user.PasswordSalt);

            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

            for(int i = 0; i < computedHash.Length; i++)
            {
                if(computedHash[i] != user.PasswordHash[i])
                    return Unauthorized("Invalid Password"); 
            }

            return new UserDto
            {
                Username = user.UserName,
                Token = _tokenService.CreateToken(user)
            };

        }

        //CHECK IF THERE IS ANY OTHER USER WITH THE SAME USERNAME
        private async Task<Boolean> UsersExists(string username)
        {
            return await _context.Users.AnyAsync(database => database.UserName == username.ToLower());
        }
    }
}