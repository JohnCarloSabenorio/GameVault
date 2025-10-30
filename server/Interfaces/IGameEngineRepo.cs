using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.Models;
namespace server.Interfaces
{
    public interface IGameEngineRepo
    {
        Task<List<Engine>> GetGameEngines(long gameId);

        Task<GameEngine> CreateAsync(long gameId, long engineId);
        Task<GameEngine?> DeleteAsync(long gameId, long engineId);
        Task<bool> GameEngineExists(long gameId, long engineId);
    }
}