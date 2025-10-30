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
    public class GameTagRepository : IGameTagRepo
    {
        private readonly ApplicationDBContext _context;
        public GameTagRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<GameTag> CreateAsync(long gameId, long tagId)
        {
            var newGameTag = new GameTag { GameId = gameId, TagId = tagId };

            await _context.GameTag.AddAsync(newGameTag);
            await _context.SaveChangesAsync();

            return newGameTag;
        }

        public async Task<GameTag?> DeleteAsync(long gameId, long tagId)
        {
            var deletedGameTag = await _context.GameTag.FirstOrDefaultAsync(x => x.GameId == gameId && x.TagId == tagId);

            if (deletedGameTag == null)
            {
                return null;
            }

            return deletedGameTag;
        }

        public async Task<bool> GameTagExists(long gameId, long tagId)
        {
            return await _context.GameTag.AnyAsync(x => x.GameId == gameId && x.TagId == tagId);
        }

        public async Task<List<Tag>> GetGameTags(long gameId)
        {
            return await _context.GameTag.Where(x => x.GameId == gameId).Select(x => new Tag { Name = x.Tag.Name }).ToListAsync();
        }
    }
}