using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.DTOs.GameEngine;
using server.Helpers;
using server.Models;

namespace server.Interfaces
{
    public interface IGameEngineRepo
    {
        Task<List<GameEngine>> GetAllAsync(GameEngineQueryObject gameEngineQueryObject);
        Task<GameEngine?> GetByIdAsync(long id);
        Task<GameEngine> CreateAsync(CreateGameEngineDTO createGameEngineDTO);
        Task<GameEngine?> UpdateAsync(long id, UpdateGameEngineDTO updateGameEngineDTO);
        Task<GameEngine?> DeleteAsync(long id);
    }
}