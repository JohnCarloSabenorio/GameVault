using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using server.Data;
using server.DTOs.GameEngine;
using server.Helpers;
using server.Interfaces;
using server.Mappers;
using server.Models;

namespace server.Repository
{
    public class GameEngineRepository : IGameEngineRepo
    {
        private readonly ApplicationDBContext _context;
        public GameEngineRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<GameEngine> CreateAsync(CreateGameEngineDTO createGameEngineDTO)
        {
            var newGameEngine = createGameEngineDTO.ToGameEngineFromCreateDTO();

            await _context.GameEngine.AddAsync(newGameEngine);
            await _context.SaveChangesAsync();

            await _context.Entry(newGameEngine).Reference(g => g.Logo).LoadAsync();
            return newGameEngine;
        }

        public async Task<GameEngine?> DeleteAsync(long id)
        {
            var gameEngine = await _context.GameEngine.FindAsync(id);

            if (gameEngine == null)
            {
                return null;
            }

            _context.GameEngine.Remove(gameEngine);
            await _context.SaveChangesAsync();

            return gameEngine;
        }

        public Task<List<GameEngine>> GetAllAsync(GameEngineQueryObject gameEngineQueryObject)
        {

            var gameEngines = _context.GameEngine.AsQueryable();
            if (!string.IsNullOrEmpty(gameEngineQueryObject.SortBy))
            {
                if (gameEngineQueryObject.SortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    gameEngines = gameEngineQueryObject.IsDescending ? gameEngines.OrderByDescending(g => g.Name) : gameEngines.OrderBy(g => g.Name);
                }
            }

            var skipNumber = (gameEngineQueryObject.PageNumber - 1) * gameEngineQueryObject.PageSize;

            return gameEngines.Skip(skipNumber).Take(gameEngineQueryObject.PageSize).Include(g => g.Logo).ToListAsync();
        }

        public async Task<GameEngine?> GetByIdAsync(long id)
        {
            var gameEngine = await _context.GameEngine.Include(g => g.Logo).FirstOrDefaultAsync(g => g.Id == id);

            if (gameEngine == null)
            {
                return null;
            }

            return gameEngine;
        }

        public async Task<GameEngine?> UpdateAsync(long id, UpdateGameEngineDTO updateGameEngineDTO)
        {
            var gameEngine = await _context.GameEngine.FindAsync(id);

            if (gameEngine == null)
            {
                return null;
            }

            _context.Entry(gameEngine).CurrentValues.SetValues(updateGameEngineDTO);

            var updatedGameEngine = await _context.GameEngine.Include(g => g.Logo).FirstOrDefaultAsync(g => g.Id == id);

            return updatedGameEngine;
        }
    }
}