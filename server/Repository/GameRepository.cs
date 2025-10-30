

using Microsoft.EntityFrameworkCore;
using server.Data;
using server.DTOs.Game;
using server.Interfaces;
using server.Mappers;
using server.Models;

namespace server.Repository;


public class GameRepository : IGameRepo
{

    private readonly ApplicationDBContext _context;
    public GameRepository(ApplicationDBContext context)
    {
        _context = context;
    }
    public async Task<Game> CreateAsync(CreateGameDTO createGameDTO)
    {
        // Convert the createDTO
        var gameData = createGameDTO.ToGameFromCreateDTO();

        await _context.Game.AddAsync(gameData);
        await _context.SaveChangesAsync();

        return gameData;
    }

    public async Task<Game?> DeleteAsync(long id)
    {
        var game = await _context.Game.FindAsync(id);
        if (game == null)
        {
            return null;
        }
        _context.Game.Remove(game);
        await _context.SaveChangesAsync();

        return game;
    }

    public async Task<List<Game>> GetAllAsync(GameQueryObject queryObject)
    {
        var games = _context.Game.AsQueryable();


        if (!string.IsNullOrEmpty(queryObject.Name))
        {
            games = games.Where(u => u.Name != null && u.Name.Contains(queryObject.Name));
        }

        if (!string.IsNullOrEmpty(queryObject.SortBy))
        {
            if (queryObject.SortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
            {
                games = queryObject.IsDescending ? games.OrderByDescending(v => v.Name) : games.OrderBy(v => v.Name);
            }
        }

        var skipNumber = (queryObject.PageNumber - 1) * queryObject.PageSize;



        return await games.Skip(skipNumber).Take(queryObject.PageSize).Include(v => v.Reviews).ThenInclude(r => r.User).ToListAsync();
    }

    public async Task<Game?> GetByIdAsync(long id)
    {
        return await _context.Game.Include(v => v.Reviews).ThenInclude(r => r.User).FirstOrDefaultAsync(v => v.Id == id);
    }

    public async Task<Game?> UpdateAsync(long id, UpdateGameDTO updateGameDTO)
    {
        var game = await _context.Game.FindAsync(id);

        if (game == null)
        {
            return null;
        }

        _context.Entry(game).CurrentValues.SetValues(updateGameDTO);

        await _context.SaveChangesAsync();

        return game;
    }

    public async Task<bool> GameExists(long id)
    {
        return await _context.Game.AnyAsync(v => v.Id == id);
    }
}