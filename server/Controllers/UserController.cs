using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using server.Data;
using server.DTOs.User;
using server.Mappers;
using server.Models;

namespace server.Controllers;

[Route("api/user")]
public class UserController : ControllerBase
{
    private readonly ApplicationDBContext _context;
    public UserController(ApplicationDBContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserDTO>>> GetAll()
    {
        var users = await _context.User.Select(u => u.ToUserDTO()).ToListAsync();


        return users;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserDTO>> GetById(long id)
    {
        var user = await _context.User.FindAsync(id);

        if (user == null)
        {
            return NotFound();
        }

        return user.ToUserDTO();
    }

    [HttpPost]
    public async Task<ActionResult<UserDTO>> Create(CreateUserDTO userDTO)
    {
        var userModel = userDTO.ToUserFromCreateDTO();

        await _context.User.AddAsync(userModel);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new { id = userModel.Id }, userModel.ToUserDTO());
    }

    [HttpPut("{id}")]

    public async Task<IActionResult> Update(long id, UpdateUserDTO updateDTO)
    {

        var userModel = await _context.User.FirstOrDefaultAsync(x => x.Id == id);

        if (userModel == null)
        {
            return NotFound();
        }

        userModel.Username = updateDTO.Username;
        userModel.Email = updateDTO.Email;
        userModel.Password = updateDTO.Password;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.User.Any(u => u.Id == id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return Ok(userModel.ToUserDTO());
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(long id)
    {
        // Find user
        var user = await _context.User.FindAsync(id);
        // Check if user exists
        if (user == null)
        {
            return NotFound();
        }
        // Delete the user
        _context.User.Remove(user);
        // Save changes
        await _context.SaveChangesAsync();

        return NoContent();
    }

}