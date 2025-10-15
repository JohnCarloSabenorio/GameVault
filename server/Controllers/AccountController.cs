

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.General;
using server.DTOs.Account;
using server.Models;
namespace server.Controllers;

[Route("api/account")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly UserManager<User> _userManager;
    public AccountController(UserManager<User> userManager)
    {
        _userManager = userManager;
    }

    [HttpPost("register")]

    public async Task<IActionResult> Register([FromBody] RegisterDTO registerDTO)
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
                    return Ok("User created");
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
}