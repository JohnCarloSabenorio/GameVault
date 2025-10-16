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
    public async Task<List<Genre>> GetVideoGameGenres(long videoGameId)
    {
        return await _context.VideoGameGenre.Where(x => x.VideoGameId == videoGameId).Select(genre => new Genre
        {
            Id = genre.GenreId,
            Name = genre.Genre.Name
        }).ToListAsync();
    }
}