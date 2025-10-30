using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.Models;

namespace server.Interfaces
{
    public interface IGamePlatformRepo
    {
        Task<List<Platform>> GetGamePlatforms(long gameId);
        Task<GamePlatform> CreateAsync(long gameId, long platformId);
        Task<GamePlatform?> DeleteAsync(long gameId, long platformId);
        Task<bool> GamePlatformExists(long gameId, long platformId);
    }
}