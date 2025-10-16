using server.Models;

namespace server.Interfaces;


public interface IVideoGameGenreRepo
{

    public Task<List<Genre>> GetVideoGameGenres(long videoGameId);
}