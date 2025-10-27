



using server.DTOs.GameDeveloper;
using server.Models;

namespace server.Interfaces;

public interface IGameDeveloperRepo
{
    // Get all
    Task<List<Developer>> GetGameDevelopers(long gameId);
    // Create
    Task<GameDeveloper> CreateGameDeveloper(long gameId, long developerId);
    // Delete
    Task<GameDeveloper?> DeleteGameDeveloper(long gameId, long developerId);

    // Game dev exists
    Task<bool> GameDeveloperExists(long gameId, long developerId);


}