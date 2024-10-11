using Ecommerce.Dtos.Accounts;
using Ecommerce.Enums;
using Ecommerce.Interfaces;
using Ecommerce.Mapper;
using Ecommerce.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly ITokenServices _tokenServices;
        private readonly SignInManager<User> _signInManager;

        public UserController(UserManager<User> userManager, ITokenServices tokenServices, SignInManager<User> signInManager)
        {
            this._userManager = userManager;
            this._tokenServices = tokenServices;
            this._signInManager = signInManager;
        }
        [HttpPost("AdminRegister")]
        public async Task<IActionResult> AdminRegister([FromBody] RegisterDto registerDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(new { Error = ModelState });
                var user = new User
                {
                    FirstName = registerDto.FirstName,
                    LastName = registerDto.LastName,
                    UserName = registerDto.UserName,
                    Email = registerDto.Email
                };
                var createdUser = await _userManager.CreateAsync(user, registerDto.Password!);
                if (createdUser.Succeeded)
                {
                    var roleResult = await _userManager.AddToRoleAsync(user, UserRoles.Admin.ToString());
                    if (roleResult.Succeeded)
                    {
                        var token = await _tokenServices.createToken(user);
                        return Ok(
                            new
                            {
                                Message = "success",
                                UserName = user.UserName,
                                Email = user.Email,
                                Token = token,
                            }
                        );
                    }
                    else
                    {
                        return StatusCode(500, new { Message = "Failed to add role", Errors = roleResult.Errors });
                    }
                }
                else
                {
                    return StatusCode(500, new { Message = "User creation failed", Errors = createdUser.Errors });
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, new { Message = "An unexpected error occurred.", Error = e.Message });
            }
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(new { Error = ModelState });
                var user = new User
                {
                    FirstName = registerDto.FirstName,
                    LastName = registerDto.LastName,
                    UserName = registerDto.UserName,
                    Email = registerDto.Email
                };
                var createdUser = await _userManager.CreateAsync(user, registerDto.Password!);
                if (createdUser.Succeeded)
                {
                    var roleResult = await _userManager.AddToRoleAsync(user, UserRoles.User.ToString());
                    if (roleResult.Succeeded)
                    {
                        var token = await _tokenServices.createToken(user);
                        return Ok(
                            new
                            {
                                Message = "success",
                                UserName = user.UserName,
                                Email = user.Email,
                                Token = token,
                            }
                        );
                    }
                    else
                    {
                        return StatusCode(500, new { Message = "Failed to add role", Errors = roleResult.Errors });
                    }
                }
                else
                {
                    return StatusCode(500, new { Message = "User creation failed", Errors = createdUser.Errors });
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, new { Message = "An unexpected error occurred.", Error = e.Message });
            }
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { Error = ModelState });
            var user = await _userManager.Users.FirstOrDefaultAsync(U => U.Email == loginDto.Email);
            if (user == null) return Unauthorized(new { Error = "Invalid Email" });
            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password!, false);
            if (!result.Succeeded) return Unauthorized(new { Error = "Username not found and/or password incorrect" });
            var token = await _tokenServices.createToken(user);
            return Ok(
                new
                {
                    Message = "success",
                    UserName = user.UserName,
                    Email = user.Email,
                    Token = token
                }
            );
        }
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userManager.Users.ToListAsync();
            if (!users.Any())
            {
                return NotFound(new { Error = "No useres found" });
            }
            var usersDto = users.Select(S => S.ToUserDto());
            return Ok(new { Message = "sucess", Uesrs = usersDto });
        }
    }
}
