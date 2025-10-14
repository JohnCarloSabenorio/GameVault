

using server.DTOs.VideoGame;
using server.Models;

namespace server.Interfaces;

public interface IVideoGameRepo
{


    Task<List<VideoGame>> GetAllAsync(VideoGameQueryObject videoGameQueryObject);

    Task<VideoGame?> GetByIdAsync(long id);
    Task<VideoGame> CreateAsync(VideoGame videoGameData);

    Task<VideoGame?> UpdateAsync(long id, UpdateVideoGameDTO videoGameDTO);

    Task<VideoGame?> DeleteAsync(long id);

    Task<bool> VideoGameExists(long id);


}