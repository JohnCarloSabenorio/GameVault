

using Microsoft.EntityFrameworkCore;
using server.Data;
using server.DTOs.VideoGame;
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
        // Convert the createDTO to videoGameModel
        var videoGameData = createGameDTO.toVideoGameFromCreateDTO();

        await _context.Game.AddAsync(videoGameData);
        await _context.SaveChangesAsync();

        return videoGameData;
    }

    public async Task<Game?> DeleteAsync(long id)
    {
        var videoGame = await _context.Game.FindAsync(id);
        if (videoGame == null)
        {
            return null;
        }
        _context.Game.Remove(videoGame);
        await _context.SaveChangesAsync();

        return videoGame;
    }

    public async Task<List<Game>> GetAllAsync(GameQueryObject queryObject)
    {
        var videoGames = _context.Game.AsQueryable();


        if (!string.IsNullOrEmpty(queryObject.Name))
        {
            videoGames = videoGames.Where(u => u.Name != null && u.Name.Contains(queryObject.Name));
        }

        if (!string.IsNullOrEmpty(queryObject.SortBy))
        {
            if (queryObject.SortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
            {
                videoGames = queryObject.IsDescending ? videoGames.OrderByDescending(v => v.Name) : videoGames.OrderBy(v => v.Name);
            }
        }

        var skipNumber = (queryObject.PageNumber - 1) * queryObject.PageSize;



        return await videoGames.Skip(skipNumber).Take(queryObject.PageSize).Include(v => v.Reviews).ThenInclude(r => r.User).ToListAsync();
    }

    public async Task<Game?> GetByIdAsync(long id)
    {
        return await _context.Game.Include(v => v.Reviews).ThenInclude(r => r.User).FirstOrDefaultAsync(v => v.Id == id);
    }

    public async Task<Game?> UpdateAsync(long id, UpdateGameDTO updateGameDTO)
    {
        var videoGame = await _context.Game.FindAsync(id);

        if (videoGame == null)
        {
            return null;
        }

        _context.Entry(videoGame).CurrentValues.SetValues(updateGameDTO);

        await _context.SaveChangesAsync();

        return videoGame;
    }

    public async Task<bool> VideoGameExists(long id)
    {
        return await _context.Game.AnyAsync(v => v.Id == id);
    }
}