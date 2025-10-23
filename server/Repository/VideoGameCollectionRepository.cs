using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using server.Data;
using server.DTOs.VideoGameCollection;
using server.Helpers;
using server.Interfaces;
using server.Mappers;
using server.Models;

namespace server.Repository
{
    public class VideoGameCollectionRepository : IVideoGameCollectionRepo
    {

        private readonly ApplicationDBContext _context;
        public VideoGameCollectionRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<VideoGameCollection> CreateAsync(CreateVideoGameCollectionDTO createVideoGameCollectionDTO)
        {
            var videoGameCollectionData = createVideoGameCollectionDTO.ToVideoGameCollectionFromCreateDTO();

            await _context.VideoGameCollection.AddAsync(videoGameCollectionData);
            await _context.SaveChangesAsync();

            return videoGameCollectionData;
        }

        public async Task<VideoGameCollection?> DeleteAsync(long id)
        {
            var videoGameCollection = await _context.VideoGameCollection.FindAsync(id);
            if (videoGameCollection == null)
            {
                return null;
            }

            _context.VideoGameCollection.Remove(videoGameCollection);
            await _context.SaveChangesAsync();

            return videoGameCollection;
        }

        public async Task<List<VideoGameCollection>> GetAllAsync(VideoGameCollectionQueryObject videoGameCollectionQueryObject)
        {
            var videoGameCollections = _context.VideoGameCollection.AsQueryable();
            if (!string.IsNullOrEmpty(videoGameCollectionQueryObject.SortBy))
            {
                if (videoGameCollectionQueryObject.SortBy.Equals("name", StringComparison.OrdinalIgnoreCase))
                {
                    videoGameCollections = videoGameCollectionQueryObject.IsDescending ? videoGameCollections.OrderByDescending(c => c.Name) : videoGameCollections.OrderBy(c => c.Name);
                }
                if (videoGameCollectionQueryObject.SortBy.Equals("createdat", StringComparison.OrdinalIgnoreCase))
                {
                    videoGameCollections = videoGameCollectionQueryObject.IsDescending ? videoGameCollections.OrderByDescending(c => c.CreatedAt) : videoGameCollections.OrderBy(c => c.CreatedAt);
                }
            }

            var skipNumber = (videoGameCollectionQueryObject.PageNumber - 1) * videoGameCollectionQueryObject.PageSize;

            return await videoGameCollections.Skip(skipNumber).Take(videoGameCollectionQueryObject.PageSize).ToListAsync();
        }

        public async Task<VideoGameCollection?> GetByIdAsync(long id)
        {
            var videoGameCollection = await _context.VideoGameCollection.FindAsync(id);

            if (videoGameCollection == null)
            {
                return null;
            }
            return videoGameCollection;
        }

        public async Task<VideoGameCollection?> UpdateAsync(long id, UpdateVideoGameCollectionDTO updateVideoGameCollectionDTO)
        {
            var videoGameCollection = await _context.VideoGameCollection.FindAsync(id);

            if (videoGameCollection == null)
            {
                return null;
            }

            _context.Entry(videoGameCollection).CurrentValues.SetValues(updateVideoGameCollectionDTO);
            await _context.SaveChangesAsync();

            return videoGameCollection;
        }
    }
}