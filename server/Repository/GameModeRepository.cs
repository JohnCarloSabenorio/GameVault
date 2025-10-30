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
    public class GameModeRepository : IGameModeRepo
    {
        private readonly ApplicationDBContext _context;
        public GameModeRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<GameMode> CreateAsync(long gameId, long modeId)
        {
            var newGameMode = new GameMode { GameId = gameId, ModeId = modeId };

            await _context.GameMode.AddAsync(newGameMode);
            await _context.SaveChangesAsync();
            return newGameMode;
        }

        public async Task<GameMode?> DeleteAsync(long gameId, long modeId)
        {
            var deletedGameMode = await _context.GameMode.FirstOrDefaultAsync(x => x.GameId == gameId && x.ModeId == modeId);

            if (deletedGameMode == null)
            {
                return null;
            }

            _context.GameMode.Remove(deletedGameMode);
            await _context.SaveChangesAsync();

            return deletedGameMode;
        }

        public async Task<bool> GameModeExists(long gameId, long modeId)
        {
            return await _context.GameMode.AnyAsync(x => x.GameId == gameId && x.ModeId == modeId);
        }

        public async Task<List<Mode>> GetGameModes(long gameId)
        {
            return await _context.GameMode.Where(x => x.GameId == gameId).Select(x => new Mode { Name = x.Mode.Name }).ToListAsync();
        }
    }
}