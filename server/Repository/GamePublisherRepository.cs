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
    public class GamePublisherRepository : IGamePublisherRepo
    {

        private readonly ApplicationDBContext _context;
        public GamePublisherRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<GamePublisher> CreateAsync(long gameId, long publisherId)
        {
            var newGamePublisher = new GamePublisher { GameId = gameId, PublisherId = publisherId };

            await _context.GamePublisher.AddAsync(newGamePublisher);
            await _context.SaveChangesAsync();

            return newGamePublisher;
        }

        public async Task<GamePublisher?> DeleteAsync(long gameId, long publisherId)
        {
            var deletedGamePublisher = await _context.GamePublisher.FirstOrDefaultAsync(x => x.GameId == gameId && x.PublisherId == publisherId);

            if (deletedGamePublisher == null)
            {
                return null;
            }

            _context.GamePublisher.Remove(deletedGamePublisher);
            await _context.SaveChangesAsync();

            return deletedGamePublisher;
        }

        public async Task<bool> GamePublisherExists(long gameId, long publisherId)
        {
            return await _context.GamePublisher.AnyAsync(x => x.GameId == gameId && x.PublisherId == publisherId);
        }

        public async Task<List<Publisher>> GetGamePublishers(long gameId)
        {
            return await _context.GamePublisher.Where(x => x.GameId == gameId).Select(x => new Publisher
            {
                Name = x.Publisher.Name,
                YearFounded = x.Publisher.YearFounded,
                Country = x.Publisher.Country,
                Website = x.Publisher.Website,
                Description = x.Publisher.Description,
                ImageId = x.Publisher.ImageId
            }).ToListAsync();
        }
    }
}