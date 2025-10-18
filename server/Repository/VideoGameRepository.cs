

using Microsoft.EntityFrameworkCore;
using server.Data;
using server.DTOs.VideoGame;
using server.Interfaces;
using server.Mappers;
using server.Models;

namespace server.Repository;


public class VideoGameRepository : IVideoGameRepo
{

    private readonly ApplicationDBContext _context;
    public VideoGameRepository(ApplicationDBContext context)
    {
        _context = context;
    }
    public async Task<VideoGame> CreateAsync(CreateVideoGameDTO createVideoGameDTO)
    {
        // Convert the createDTO to videoGameModel
        var videoGameData = createVideoGameDTO.toVideoGameFromCreateDTO();

        await _context.VideoGame.AddAsync(videoGameData);
        await _context.SaveChangesAsync();

        return videoGameData;
    }

    public async Task<VideoGame?> DeleteAsync(long id)
    {
        var videoGame = await _context.VideoGame.FindAsync(id);
        if (videoGame == null)
        {
            return null;
        }
        _context.VideoGame.Remove(videoGame);
        await _context.SaveChangesAsync();

        return videoGame;
    }

    public async Task<List<VideoGame>> GetAllAsync(VideoGameQueryObject queryObject)
    {
        var videoGames = _context.VideoGame.AsQueryable();


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

    public async Task<VideoGame?> GetByIdAsync(long id)
    {
        return await _context.VideoGame.Include(v => v.Reviews).ThenInclude(r => r.User).FirstOrDefaultAsync(v => v.Id == id);
    }

    public async Task<VideoGame?> UpdateAsync(long id, UpdateVideoGameDTO updateVideoGameDTO)
    {
        var videoGame = await _context.VideoGame.FindAsync(id);

        if (videoGame == null)
        {
            return null;
        }

        _context.Entry(videoGame).CurrentValues.SetValues(updateVideoGameDTO);

        await _context.SaveChangesAsync();

        return videoGame;
    }

    public async Task<bool> VideoGameExists(long id)
    {
        return await _context.VideoGame.AnyAsync(v => v.Id == id);
    }
}