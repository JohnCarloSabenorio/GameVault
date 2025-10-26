using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using server.Data;
using server.DTOs.VIdeo;
using server.Helpers;
using server.Interfaces;
using server.Mappers;
using server.Models;

namespace server.Repository
{
    public class VideoRepository : IVideoRepo
    {

        private readonly ApplicationDBContext _context;
        public VideoRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<Video> CreateAsync(CreateVideoDTO createVideoDTO)
        {
            var newVideo = createVideoDTO.ToVideoFromCreateDTO();

            await _context.Video.AddAsync(newVideo);
            await _context.SaveChangesAsync();

            return newVideo;
        }

        public async Task<Video?> DeleteAsync(long id)
        {
            var deletedVideo = await _context.Video.FindAsync(id);

            if (deletedVideo == null)
            {
                return null;
            }

            return deletedVideo;
        }

        public async Task<List<Video>> GetAllAsync(VideoQueryObject videoQueryObject)
        {
            var videos = _context.Video.AsQueryable();
            if (!string.IsNullOrEmpty(videoQueryObject.SortBy))
            {
                if (videoQueryObject.SortBy.Equals("name", StringComparison.OrdinalIgnoreCase))
                {
                    videos = videoQueryObject.IsDescending ? videos.OrderByDescending(v => v.Name) : videos.OrderBy(v => v.Name);
                }
            }

            var skipNumber = (videoQueryObject.PageNumber - 1) * videoQueryObject.PageSize;

            return await videos.Skip(skipNumber).Take(videoQueryObject.PageSize).ToListAsync();
        }

        public async Task<Video?> GetByIdAsync(long id)
        {
            var video = await _context.Video.FirstOrDefaultAsync(v => v.Id == id);

            if (video == null)
            {
                return null;
            }

            return video;
        }

        public async Task<Video?> UpdateAsync(long id, UpdateVIdeoDTO updateVIdeoDTO)
        {
            var updatedVideo = await _context.Video.FirstOrDefaultAsync(v => v.Id == id);

            if (updatedVideo == null)
            {
                return null;
            }

            _context.Entry(updatedVideo).CurrentValues.SetValues(updateVIdeoDTO);
            await _context.SaveChangesAsync();

            return updatedVideo;
        }
    }
}