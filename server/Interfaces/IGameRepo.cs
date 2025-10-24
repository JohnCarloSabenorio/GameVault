

using server.DTOs.Game;
using server.Models;

namespace server.Interfaces;

public interface IGameRepo
{


    Task<List<Game>> GetAllAsync(GameQueryObject gameQueryObject);

    Task<Game?> GetByIdAsync(long id);
    Task<Game> CreateAsync(CreateGameDTO createGameDTO);

    Task<Game?> UpdateAsync(long id, UpdateGameDTO gameDTO);

    Task<Game?> DeleteAsync(long id);

    Task<bool> GameExists(long id);


}