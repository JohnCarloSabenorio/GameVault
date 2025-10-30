using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.Models;

namespace server.Interfaces
{
    public interface IGameImageRepo
    {
        Task<List<Image>> GetGameImages(long gameId);
        Task<GameImage> CreateAsync(long gameId, long imageId);
        Task<GameImage?> DeleteAsync(long gameId, long imageId);
        Task<bool> GameImageExists(long gameId, long imageId);
    }
}