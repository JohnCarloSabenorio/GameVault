namespace server.Interfaces;

using server.DTOs.User;
using server.Helpers;
using server.Models;


public interface IUserRepo
{
    Task<List<User>> GetAllAsync(UserQueryObject queryObject);

    Task<User?> GetByIdAsync(long id);

    Task<User> CreateAsync(User userData);
    Task<User?> UpdateAsync(long id, UpdateUserDTO userDTO);
    Task<User?> DeleteAsync(long id);

    Task<bool> UserExists(long id);


}