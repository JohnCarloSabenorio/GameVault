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
    public class GamePlatformRepository : IGamePlatformRepo
    {
        private readonly ApplicationDBContext _context;
        public GamePlatformRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<GamePlatform> CreateAsync(long gameId, long platformId)
        {
            var newGamePlatfrom = new GamePlatform { GameId = gameId, PlatformId = platformId };

            await _context.GamePlatform.AddAsync(newGamePlatfrom);
            await _context.SaveChangesAsync();

            return newGamePlatfrom;
        }

        public async Task<GamePlatform?> DeleteAsync(long gameId, long platformId)
        {
            var deletedGamePlatform = await _context.GamePlatform.FirstOrDefaultAsync(x => x.GameId == gameId && x.PlatformId == platformId);

            if (deletedGamePlatform == null)
            {
                return null;
            }

            _context.GamePlatform.Remove(deletedGamePlatform);
            await _context.SaveChangesAsync();

            return deletedGamePlatform;
        }

        public async Task<bool> GamePlatformExists(long gameId, long platformId)
        {
            return await _context.GamePlatform.AnyAsync(x => x.GameId == gameId && x.PlatformId == platformId);
        }

        public async Task<List<Platform>> GetGamePlatforms(long gameId)
        {
            return await _context.GamePlatform.Where(x => x.GameId == gameId).Select(x => new Platform { Name = x.Platform.Name, Generation = x.Platform.Generation, Summary = x.Platform.Summary, Url = x.Platform.Url, Logo = x.Platform.Logo }).ToListAsync();
        }
    }
}