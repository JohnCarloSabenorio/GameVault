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
    public class GameDeveloperRepository : IGameDeveloperRepo
    {
        private readonly ApplicationDBContext _context;
        public GameDeveloperRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<GameDeveloper> CreateAsync(long gameId, long developerId)
        {
            var newGameDeveloper = new GameDeveloper { GameId = gameId, DeveloperId = developerId };
            await _context.GameDeveloper.AddAsync(newGameDeveloper);
            await _context.SaveChangesAsync();


            return newGameDeveloper;
        }

        public async Task<GameDeveloper?> DeleteAsync(long gameId, long developerId)
        {
            var gameDeveloper = await _context.GameDeveloper.FirstOrDefaultAsync(x => x.GameId == gameId && x.DeveloperId == developerId);

            if (gameDeveloper == null)
            {
                return null;
            }

            _context.GameDeveloper.Remove(gameDeveloper);
            await _context.SaveChangesAsync();

            return gameDeveloper;
        }

        public async Task<bool> GameDeveloperExists(long gameId, long developerId)
        {
            return await _context.GameDeveloper.AnyAsync(x => x.GameId == gameId && x.DeveloperId == developerId);
        }

        public async Task<List<Developer>> GetGameDevelopers(long gameId)
        {
            return await _context.GameDeveloper.Where(x => x.GameId == gameId).Select(x => new Developer { Id = x.DeveloperId, Name = x.Developer.Name, CountryOrigin = x.Developer.CountryOrigin, WebsiteUrl = x.Developer.WebsiteUrl, Description = x.Developer.Description, ImageId = x.Developer.ImageId, DateFounded = x.Developer.DateFounded, }).ToListAsync();
        }
    }
}