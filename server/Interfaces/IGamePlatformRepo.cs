using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.DTOs.Platform;
using server.Helpers;
using server.Models;
namespace server.Interfaces
{
    public interface IGamePlatformRepo
    {
        Task<List<GamePlatform>> GetAllAsync(GamePlatformQueryObject gamePlatformQueryObject);
        Task<GamePlatform?> GetByIdAsync(long id);
        Task<GamePlatform> CreateAsync(CreateGamePlatformDTO createGamePlatformDTO);
        Task<GamePlatform?> UpdateAsync(long id, UpdateGamePlatformDTO updateGamePlatformDTO);
        Task<GamePlatform?> DeleteAsync(long id);
    }
}