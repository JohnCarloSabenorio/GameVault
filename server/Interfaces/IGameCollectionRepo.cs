using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.DTOs.GameCOllection;
using server.Helpers;
using server.Models;

namespace server.Interfaces
{
    public interface IGameCollectionRepo
    {
        Task<List<GameCollection>> GetAllAsync(GameCollectionQueryObject gameCollectionQueryObject);
        Task<GameCollection?> GetByIdAsync(long id);
        Task<GameCollection> CreateAsync(CreateGameCollectionDTO createGameCollectionDTO);
        Task<GameCollection?> DeleteAsync(long id);
        Task<GameCollection?> UpdateAsync(long id, UpdateGameCollectionDTO updateGameCollectionDTO);
    }
}