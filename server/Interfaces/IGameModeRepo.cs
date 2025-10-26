using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.DTOs.GameMode;
using server.Helpers;
using server.Models;

namespace server.Interfaces
{
    public interface IGameModeRepo
    {
        Task<List<GameMode>> GetAllAsync(GameModeQueryObject gameModeQueryObject);
        Task<GameMode?> GetByIdAsync(long id);
        Task<GameMode> CreateAsync(CreateGameModeDTO createGameModeDTO);
        Task<GameMode?> UpdateAsync(long id, UpdateGameModeDTO updateGameModeDTO);
        Task<GameMode?> DeleteAsync(long id);
    }
}