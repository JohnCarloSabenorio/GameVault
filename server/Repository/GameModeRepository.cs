using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.Data;
using server.DTOs.GameMode;
using server.Helpers;
using server.Interfaces;
using server.Models;
using server.Mappers;
using Microsoft.EntityFrameworkCore;

namespace server.Repository
{
    public class GameModeRepository : IGameModeRepo
    {
        private readonly ApplicationDBContext _context;
        public GameModeRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<GameMode> CreateAsync(CreateGameModeDTO createGameModeDTO)
        {
            var newGameMode = createGameModeDTO.ToGameModeFromCreateDTO();

            await _context.GameMode.AddAsync(newGameMode);
            await _context.SaveChangesAsync();

            return newGameMode;
        }

        public async Task<GameMode?> DeleteAsync(long id)
        {
            var deletedGameMode = await _context.GameMode.FindAsync(id);

            if (deletedGameMode == null)
            {
                return null;
            }

            _context.GameMode.Remove(deletedGameMode);
            await _context.SaveChangesAsync();

            return deletedGameMode;
        }

        public async Task<List<GameMode>> GetAllAsync(GameModeQueryObject gameModeQueryObject)
        {
            var gameModes = _context.GameMode.AsQueryable();
            if (!string.IsNullOrEmpty(gameModeQueryObject.SortBy))
            {
                if (gameModeQueryObject.SortBy.Equals("name", StringComparison.OrdinalIgnoreCase))
                {
                    gameModes = gameModeQueryObject.IsDescending ? gameModes.OrderByDescending(m => m.Name) : gameModes.OrderBy(m => m.Name);
                }
            }

            var skipNumber = (gameModeQueryObject.PageNumber - 1) * gameModeQueryObject.PageSize;

            return await gameModes.Skip(skipNumber).Take(gameModeQueryObject.PageSize).ToListAsync();
        }

        public async Task<GameMode?> GetByIdAsync(long id)
        {
            var gameMode = await _context.GameMode.FirstOrDefaultAsync(m => m.Id == id);

            if (gameMode == null)
            {
                return null;
            }

            return gameMode;
        }

        public async Task<GameMode?> UpdateAsync(long id, UpdateGameModeDTO updateGameModeDTO)
        {
            var updatedGameMode = await _context.GameMode.FirstOrDefaultAsync(m => m.Id == id);

            if (updatedGameMode == null)
            {
                return null;
            }

            _context.Entry(updatedGameMode).CurrentValues.SetValues(updateGameModeDTO);
            await _context.SaveChangesAsync();

            return updatedGameMode;
        }
    }
}