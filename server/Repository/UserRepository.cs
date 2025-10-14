using Microsoft.EntityFrameworkCore;
using server.Data;
using server.DTOs.User;
using server.Interfaces;
using server.Mappers;
using server.Models;

namespace server.Repository;


public class UserRepository : IUserRepo
{
    private readonly ApplicationDBContext _context;
    public UserRepository(ApplicationDBContext context)
    {
        _context = context;
    }

    public async Task<User> CreateAsync(User userData)
    {
        await _context.User.AddAsync(userData);
        await _context.SaveChangesAsync();

        return userData;
    }

    public async Task<User?> DeleteAsync(long id)
    {
        var user = await _context.User.FindAsync(id);

        if (user == null)
        {
            return null;
        }

        _context.User.Remove(user);
        await _context.SaveChangesAsync();

        return user;
    }

    public async Task<List<User>> GetAllAsync()
    {
        return await _context.User.Include(u => u.Reviews).ToListAsync();
    }

    public async Task<User?> GetByIdAsync(long id)
    {
        return await _context.User.Include(u => u.Reviews).FirstOrDefaultAsync(u => u.Id == id);

    }

    public async Task<User?> UpdateAsync(long id, UpdateUserDTO userDTO)
    {
        var user = await _context.User.FindAsync(id);

        if (user == null)
        {
            return null;
        }

        _context.Entry(user).CurrentValues.SetValues(userDTO);


        await _context.SaveChangesAsync();

        return user;
    }


    public async Task<bool> UserExists(long id)
    {
        return await _context.User.AnyAsync(u => u.Id == id);
    }
}
