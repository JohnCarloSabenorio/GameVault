using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.Models;

namespace server.Interfaces
{
    public interface IGameModeRepo
    {
        Task<List<Mode>> GetGameModes(long gameId);
        Task<GameMode> CreateAsync(long gameId, long modeId);
        Task<GameMode?> DeleteAsync(long gameId, long modeId);
        Task<bool> GameModeExists(long gameId, long modeId);
    }
}