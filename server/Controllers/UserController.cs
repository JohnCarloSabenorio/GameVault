using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using server.Data;
using server.DTOs.User;
using server.Interfaces;
using server.Mappers;
using server.Models;

namespace server.Controllers;

[Route("api/user")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserRepo _userRepo;
    public UserController(IUserRepo userRepo)
    {
        _userRepo = userRepo;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserDTO>>> GetAll()
    {
        var users = await _userRepo.GetAllAsync();

        var usersDTO = users.Select(s => s.ToUserDTO());

        return Ok(usersDTO);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserDTO>> GetById(long id)
    {
        var user = await _userRepo.GetByIdAsync(id);

        if (user == null)
        {
            return NotFound();
        }

        return Ok(user.ToUserDTO());
    }

    [HttpPost]
    public async Task<ActionResult<UserDTO>> Create(CreateUserDTO userDTO)
    {
        var userModel = userDTO.ToUserFromCreateDTO();

        var userData = await _userRepo.CreateAsync(userModel);

        return CreatedAtAction(nameof(GetById), new { id = userData.Id }, userData.ToUserDTO());
    }

    [HttpPut("{id}")]

    public async Task<IActionResult> Update(long id, UpdateUserDTO updateDTO)
    {

        var userModel = await _userRepo.UpdateAsync(id, updateDTO);

        if (userModel == null)
        {
            return NotFound();
        }

        return Ok(userModel.ToUserDTO());
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(long id)
    {
        // Find user
        var user = await _userRepo.DeleteAsync(id);
        // Check if user exists
        if (user == null)
        {
            return NotFound();
        }

        return NoContent();
    }

}