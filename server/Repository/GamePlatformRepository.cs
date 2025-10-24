using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using server.Data;
using server.DTOs.Platform;
using server.Helpers;
using server.Interfaces;
using server.Mappers;
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
        public async Task<GamePlatform> CreateAsync(CreateGamePlatformDTO createGamePlatformDTO)
        {
            var newGamePlatform = createGamePlatformDTO.ToGamePlatformFromCreateDTO();

            await _context.GamePlatform.AddAsync(newGamePlatform);
            await _context.SaveChangesAsync();
            return newGamePlatform;
        }

        public async Task<GamePlatform?> DeleteAsync(long id)
        {
            var deletedGamePlatform = await _context.GamePlatform.FindAsync(id);

            if (deletedGamePlatform == null)
            {
                return null;
            }
            _context.GamePlatform.Remove(deletedGamePlatform);
            await _context.SaveChangesAsync();

            return deletedGamePlatform;
        }

        public Task<List<GamePlatform>> GetAllAsync(GamePlatformQueryObject gamePlatformQueryObject)
        {
            var gamePlatforms = _context.GamePlatform.AsQueryable();
            if (!string.IsNullOrEmpty(gamePlatformQueryObject.SortBy))
            {
                if (gamePlatformQueryObject.SortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    gamePlatforms = gamePlatformQueryObject.IsDescending ? gamePlatforms.OrderByDescending(p => p.Name) : gamePlatforms.OrderBy(p => p.Name);
                }
                else if (gamePlatformQueryObject.SortBy.Equals("Generation", StringComparison.OrdinalIgnoreCase))
                {
                    gamePlatforms = gamePlatformQueryObject.IsDescending ? gamePlatforms.OrderByDescending(p => p.Generation) : gamePlatforms.OrderBy(p => p.Generation);
                }
            }

            var skipNumber = (gamePlatformQueryObject.PageNumber - 1) * gamePlatformQueryObject.PageSize;

            return gamePlatforms.Skip(skipNumber).Take(gamePlatformQueryObject.PageSize).ToListAsync();
        }

        public async Task<GamePlatform?> GetById(long id)
        {
            var gamePlatform = await _context.GamePlatform.FindAsync(id);

            if (gamePlatform == null) { return null; }

            return gamePlatform;
        }


        public async Task<GamePlatform?> UpdateAsync(long id, UpdateGamePlatformDTO updatePlatformDTO)
        {
            var updatedGamePlatform = await _context.GamePlatform.FindAsync(id);

            if (updatedGamePlatform == null) { return null; }

            _context.Entry(updatedGamePlatform).CurrentValues.SetValues(updatePlatformDTO);
            await _context.SaveChangesAsync();
            return updatedGamePlatform;
        }
    }
}