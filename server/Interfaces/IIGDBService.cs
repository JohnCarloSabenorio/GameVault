using server.Models;

namespace server.Interfaces;


public interface IIGDBService
{
    Task<string?> GetVideoGamesAsync();

}