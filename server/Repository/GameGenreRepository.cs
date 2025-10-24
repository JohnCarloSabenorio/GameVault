using Microsoft.EntityFrameworkCore;
using server.Data;
using server.Interfaces;
using server.Models;

namespace server.Repository;


public class GameGenreRepository : IGameGenreRepo
{

    private readonly ApplicationDBContext _context;
    public GameGenreRepository(ApplicationDBContext context)
    {
        _context = context;
    }

    public async Task<GameGenre> CreateAsync(long gameId, long genreId)
    {
        var newGameGenre = new GameGenre { GameId = gameId, GenreId = genreId };

        await _context.GameGenre.AddAsync(newGameGenre);
        await _context.SaveChangesAsync();

        return newGameGenre;
    }

    public async Task<GameGenre?> DeleteAsync(long gameId, long genreId)
    {
        var gameGenre = await _context.GameGenre.FirstOrDefaultAsync(x => x.GameId == gameId && x.GenreId == genreId);

        if (gameGenre == null)
        {
            return null;
        }

        _context.GameGenre.Remove(gameGenre);
        await _context.SaveChangesAsync();

        return gameGenre;
    }

    public async Task<List<Genre>> GetGameGenres(long gameId)
    {
        return await _context.GameGenre.Where(x => x.GameId == gameId).Select(genre => new Genre
        {
            Id = genre.GenreId,
            Name = genre.Genre.Name
        }).ToListAsync();
    }

    public async Task<bool> GameGenreExists(long gameId, long genreId)
    {
        return await _context.GameGenre.AnyAsync(vg => vg.GameId == gameId && vg.GenreId == genreId);
    }

}