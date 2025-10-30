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
    public class GameImageRepository : IGameImageRepo
    {
        private readonly ApplicationDBContext _context;
        public GameImageRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<GameImage> Create(long gameId, long imageId)
        {
            var newGameImage = new GameImage { GameId = gameId, ImageId = imageId };

            await _context.GameImage.AddAsync(newGameImage);
            await _context.SaveChangesAsync();

            return newGameImage;
        }

        public async Task<GameImage?> DeleteAsync(long gameId, long imageId)
        {
            var deletedGameImage = await _context.GameImage.FirstOrDefaultAsync(x => x.GameId == gameId && x.ImageId == imageId);

            if (deletedGameImage == null) { return null; }

            _context.GameImage.Remove(deletedGameImage);
            await _context.SaveChangesAsync();

            return deletedGameImage;
        }

        public async Task<bool> GameImageExists(long gameId, long imageId)
        {
            return await _context.GameImage.AnyAsync(x => x.GameId == gameId && x.ImageId == imageId);
        }

        public async Task<List<Image>> GetGameImages(long gameId)
        {
            return await _context.GameImage.Where(x => x.GameId == gameId).Select(x => new Image { Name = x.Image.Name }).ToListAsync();
        }
    }
}