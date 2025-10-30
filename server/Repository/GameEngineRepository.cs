using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using server.Data;
using server.Interfaces;
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
        public async Task<GameEngine> CreateAsync(long gameId, long engineId)
        {
            var newGameEngine = new GameEngine { GameId = gameId, EngineId = engineId };

            await _context.GameEngine.AddAsync(newGameEngine);
            await _context.SaveChangesAsync();

            return newGameEngine;
        }

        public async Task<GameEngine?> DeleteAsync(long gameId, long engineId)
        {
            var deletedGameEngine = await _context.GameEngine.FirstOrDefaultAsync(x => x.GameId == gameId && x.EngineId == engineId);

            if (deletedGameEngine == null)
            {
                return null;
            }

            _context.GameEngine.Remove(deletedGameEngine);
            await _context.SaveChangesAsync();

            return deletedGameEngine;
        }

        public async Task<bool> GameEngineExists(long gameId, long engineId)
        {
            return await _context.GameEngine.AnyAsync(x => x.GameId == gameId && x.EngineId == engineId);
        }

        public async Task<List<Engine>> GetGameEngines(long gameId)
        {
            return await _context.GameEngine.Where(x => x.GameId == gameId).Select(x => new Engine
            {
                Name = x.Engine.Name,
                Description = x.Engine.Description,
                LogoId = x.Engine.LogoId,
            }).ToListAsync();
        }
    }
}