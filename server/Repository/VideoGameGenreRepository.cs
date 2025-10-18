using Microsoft.EntityFrameworkCore;
using server.Data;
using server.Interfaces;
using server.Models;

namespace server.Repository;


public class VideoGameGenreRepository : IVideoGameGenreRepo
{

    private readonly ApplicationDBContext _context;
    public VideoGameGenreRepository(ApplicationDBContext context)
    {
        _context = context;
    }

    public async Task<VideoGameGenre> CreateAsync(long videoGameId, long genreId)
    {
        var newVideoGameGenre = new VideoGameGenre { VideoGameId = videoGameId, GenreId = genreId };

        await _context.VideoGameGenre.AddAsync(newVideoGameGenre);
        await _context.SaveChangesAsync();

        return newVideoGameGenre;
    }

    public async Task<VideoGameGenre?> DeleteAsync(long videoGameId, long genreId)
    {
        var videoGameGenre = await _context.VideoGameGenre.FirstOrDefaultAsync(x => x.VideoGameId == videoGameId && x.GenreId == genreId);

        if (videoGameGenre == null)
        {
            return null;
        }

        _context.VideoGameGenre.Remove(videoGameGenre);
        await _context.SaveChangesAsync();

        return videoGameGenre;
    }

    public async Task<List<Genre>> GetVideoGameGenres(long videoGameId)
    {
        return await _context.VideoGameGenre.Where(x => x.VideoGameId == videoGameId).Select(genre => new Genre
        {
            Id = genre.GenreId,
            Name = genre.Genre.Name
        }).ToListAsync();
    }

    public async Task<bool> VideoGameGenreExists(long videoGameId, long genreId)
    {
        return await _context.VideoGameGenre.AnyAsync(vg => vg.VideoGameId == videoGameId && vg.GenreId == genreId);
    }

}