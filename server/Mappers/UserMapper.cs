
using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using server.DTOs.User;
using server.Models;
namespace server.Mappers;

public static class UserMapper
{
    public static UserDTO ToUserDTO(this User userModel)
    {
        return new UserDTO { Id = userModel.Id, Username = userModel.Username, Email = userModel.Email };
    }

    public static User ToUserFromCreateDTO(this CreateUserDTO userDTO)
    {
        return new User { Username = userDTO.Username, Email = userDTO.Email, Password = userDTO.Password };
    }


}