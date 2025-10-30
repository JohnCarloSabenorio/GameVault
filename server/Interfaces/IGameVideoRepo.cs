using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.Models;

namespace server.Interfaces
{
    public interface IGameVideoRepo
    {
        Task<List<Video>> GetGameVideos(long gameId);
        Task<GameVideo> CreateAsync(long gameId, long videoId);
        Task<GameVideo?> DeleteAsync(long gameId, long videoId);
        Task<bool> GameVideoExists(long gameId, long videoId);
    }
}