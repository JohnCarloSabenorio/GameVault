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
    public class GameCollectionRepository : IGameCollectionRepo
    {
        private readonly ApplicationDBContext _context;
        public GameCollectionRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<GameCollection> CreateAsync(long collectionId, long gameId)
        {
            var newGameCollection = new GameCollection { CollectionId = collectionId, GameId = gameId };

            await _context.GameCollection.AddAsync(newGameCollection);
            await _context.SaveChangesAsync();

            return newGameCollection;
        }

        public async Task<GameCollection?> DeleteAsync(long collectionId, long gameId)
        {
            var deletedGameCollection = await _context.GameCollection.FirstOrDefaultAsync(x => x.CollectionId == collectionId && x.GameId == gameId);

            if (deletedGameCollection == null)
            {
                return null;
            }

            _context.GameCollection.Remove(deletedGameCollection);
            await _context.SaveChangesAsync();

            return deletedGameCollection;
        }

        public async Task<bool> GameCollectionExists(long collectionId, long gameId)
        {
            return await _context.GameCollection.AnyAsync(x => x.CollectionId == collectionId && x.GameId == gameId);
        }

        public async Task<List<Game>> GetCollectionGames(long collectionId)
        {
            return await _context.GameCollection.Where(x => x.CollectionId == collectionId).Select(x => new Game
            {
                Name = x.Game.Name,
                Storyline = x.Game.Storyline,
                Summary = x.Game.Summary,
                Rating = x.Game.Rating,
                RatingCount = x.Game.RatingCount,
                TotalFavorited = x.Game.TotalFavorited,
                TotalPlayers = x.Game.TotalPlayers,
                TotalUnitSold = x.Game.TotalUnitSold,
                Price = x.Game.Price,
                FranchiseId = x.Game.FranchiseId,
                StatusId = x.Game.StatusId,
                ImageId = x.Game.ImageId,
                ReleaseDate = x.Game.ReleaseDate,
            }).ToListAsync();
        }
    }
}