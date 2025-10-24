

using server.DTOs.VideoGame;
using server.Models;

namespace server.Interfaces;

public interface IGameRepo
{


    Task<List<Game>> GetAllAsync(GameQueryObject videoGameQueryObject);

    Task<Game?> GetByIdAsync(long id);
    Task<Game> CreateAsync(CreateGameDTO createVideoGameDTO);

    Task<Game?> UpdateAsync(long id, UpdateGameDTO videoGameDTO);

    Task<Game?> DeleteAsync(long id);

    Task<bool> VideoGameExists(long id);


}