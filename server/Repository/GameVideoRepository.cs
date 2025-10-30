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
    public class GameVideoRepository : IGameVideoRepo
    {
        private readonly ApplicationDBContext _context;
        public GameVideoRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<GameVideo> CreateAsync(long gameId, long videoId)
        {
            var newGameVideo = new GameVideo { GameId = gameId, VideoId = videoId };

            await _context.GameVideo.AddAsync(newGameVideo);
            await _context.SaveChangesAsync();

            return newGameVideo;
        }

        public async Task<GameVideo?> DeleteAsync(long gameId, long videoId)
        {
            var deletedGameVideo = await _context.GameVideo.FirstOrDefaultAsync(x => x.GameId == gameId && x.VideoId == videoId);
            if (deletedGameVideo == null)
            {
                return null;
            }

            _context.GameVideo.Remove(deletedGameVideo);
            await _context.SaveChangesAsync();

            return deletedGameVideo;
        }

        public async Task<bool> GameVideoExists(long gameId, long videoId)
        {
            return await _context.GameVideo.AnyAsync(x => x.GameId == gameId && x.VideoId == videoId);
        }

        public async Task<List<Video>> GetGameVideos(long gameId)
        {
            return await _context.GameVideo.Where(x => x.GameId == gameId).Select(x => new Video { Name = x.Video.Name }).ToListAsync();
        }
    }
}