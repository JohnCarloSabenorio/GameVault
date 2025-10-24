using server.Models;

namespace server.Interfaces;


public interface IGameGenreRepo
{

    public Task<List<Genre>> GetGameGenres(long gameId);

    public Task<bool> GameGenreExists(long gameId, long genreId);

    public Task<GameGenre> CreateAsync(long gameId, long genreId);

    public Task<GameGenre?> DeleteAsync(long gameId, long genreId);
}