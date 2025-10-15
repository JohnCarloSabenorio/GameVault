

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.General;
using server.DTOs.Account;
using server.Interfaces;
using server.Models;
using server.Services;
namespace server.Controllers;

[Route("api/account")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly UserManager<User> _userManager;

    private readonly ITokenService _tokenService;

    private readonly SignInManager<User> _signInManager;
    public AccountController(UserManager<User> userManager, ITokenService tokenService, SignInManager<User> signInManager)
    {
        _userManager = userManager;
        _tokenService = tokenService;
        _signInManager = signInManager;
    }

    [HttpPost("register")]
    public async Task<ActionResult<NewUserDTO>> Register([FromBody] RegisterDTO registerDTO)
    {

        try
        {
            // Check if the inputs are valid
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Create new user data
            var user = new User
            {
                UserName = registerDTO.Username,
                Email = registerDTO.Email

            };
            var createdUser = await _userManager.CreateAsync(user, registerDTO.Password);

            if (createdUser.Succeeded)
            {
                var roleResult = await _userManager.AddToRoleAsync(user, "User");
                if (roleResult.Succeeded)
                {
                    return Ok(new NewUserDTO
                    {
                        UserName = user.UserName,
                        Email = user.Email,
                        Token = _tokenService.CreateToken(user)
                    });
                }
                else
                {
                    return StatusCode(500, roleResult.Errors);
                }
            }
            else
            {
                return StatusCode(500, createdUser.Errors);
            }
        }
        catch (Exception e)
        {
            return StatusCode(500, e);
        }
    }


    [HttpPost("login")]

    public async Task<IActionResult> Login(LoginDTO loginDTO)
    {

        // Check if inputs are valid
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        // Find the user
        var user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == loginDTO.UserName);

        // Check if user exists
        if (user == null) return Unauthorized("Invalid username or password!");

        // Check if password is correct
        var result = await _signInManager.CheckPasswordSignInAsync(user, loginDTO.Password, false);
        if (!result.Succeeded) return Unauthorized("Invalid username or password!");

        return Ok(new NewUserDTO { UserName = user.UserName, Email = user.Email, Token = _tokenService.CreateToken(user) });
    }
}