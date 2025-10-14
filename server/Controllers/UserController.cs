// using System.Data;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.CodeAnalysis.CSharp.Syntax;
// using Microsoft.EntityFrameworkCore;
// using server.Data;
// using server.DTOs.User;
// using server.Helpers;
// using server.Interfaces;
// using server.Mappers;
// using server.Models;

// namespace server.Controllers;

// [Route("api/user")]
// [ApiController]
// public class UserController : ControllerBase
// {
//     private readonly IUserRepo _userRepo;
//     public UserController(IUserRepo userRepo)
//     {
//         _userRepo = userRepo;
//     }

//     [HttpGet]
//     public async Task<ActionResult<IEnumerable<UserDTO>>> GetAll([FromQuery] UserQueryObject queryObject)
//     {
//         var users = await _userRepo.GetAllAsync(queryObject);

//         var usersDTO = users.Select(s => s.ToUserDTO());

//         return Ok(usersDTO);
//     }

//     [HttpGet("{id:long}")]
//     public async Task<ActionResult<UserDTO>> GetById(long id)
//     {
//         var user = await _userRepo.GetByIdAsync(id);

//         if (user == null)
//         {
//             return NotFound("User does not exist.");
//         }

//         return Ok(user.ToUserDTO());
//     }

//     [HttpPost]
//     public async Task<ActionResult<UserDTO>> Create(CreateUserDTO userDTO)
//     {
//         if (!ModelState.IsValid)
//             return BadRequest(ModelState);
//         var userModel = userDTO.ToUserFromCreateDTO();

//         var userData = await _userRepo.CreateAsync(userModel);

//         return CreatedAtAction(nameof(GetById), new { id = userData.Id }, userData.ToUserDTO());
//     }

//     [HttpPut("{id:long}")]

//     public async Task<IActionResult> Update(long id, UpdateUserDTO updateDTO)
//     {
//         if (!ModelState.IsValid)
//             return BadRequest(ModelState);

//         var userModel = await _userRepo.UpdateAsync(id, updateDTO);

//         if (userModel == null)
//         {
//             return NotFound("User does not exist.");
//         }

//         return Ok(userModel.ToUserDTO());
//     }

//     [HttpDelete("{id:long}")]
//     public async Task<IActionResult> Delete(long id)
//     {
//         // Find user
//         var user = await _userRepo.DeleteAsync(id);
//         // Check if user exists
//         if (user == null)
//         {
//             return NotFound("User does not exist.");
//         }

//         return NoContent();
//     }

// }