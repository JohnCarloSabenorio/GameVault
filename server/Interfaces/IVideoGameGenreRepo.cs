using server.Models;

namespace server.Interfaces;


public interface IVideoGameGenreRepo
{

    public Task<List<Genre>> GetVideoGameGenres(long videoGameId);

    public Task<bool> VideoGameGenreExists(long videoGameId, long genreId);

    public Task<VideoGameGenre> CreateAsync(long videoGameId, long genreId);

    public Task<VideoGameGenre?> DeleteAsync(long videoGameId, long genreId);
}