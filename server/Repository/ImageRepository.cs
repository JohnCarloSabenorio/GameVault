using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using server.Data;
using server.DTOs.Image;
using server.Helpers;
using server.Interfaces;
using server.Mappers;
using server.Models;

namespace server.Repository
{
    public class ImageRepository : IImageRepo
    {

        private readonly ApplicationDBContext _context;
        public ImageRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Image> CreateAsync(CreateImageDTO createImageDTO)
        {
            var imageData = createImageDTO.ToImageFromCreateDTO();

            await _context.Image.AddAsync(imageData);
            await _context.SaveChangesAsync();

            return imageData;
        }

        public async Task<Image?> DeleteAsync(long id)
        {
            var deletedImage = await _context.Image.FirstOrDefaultAsync(i => i.Id == id);

            if (deletedImage == null)
            {
                return null;
            }

            _context.Image.Remove(deletedImage);
            await _context.SaveChangesAsync();

            return deletedImage;
        }

        public async Task<List<Image>> GetAllAsync(ImageQueryObject imageQueryObject)
        {
            var images = _context.Image.AsQueryable();

            if (!string.IsNullOrEmpty(imageQueryObject.SortBy))
            {
                if (imageQueryObject.SortBy.Equals("name", StringComparison.OrdinalIgnoreCase))
                {
                    images = imageQueryObject.IsDescending ? images.OrderByDescending(i => i.Name) : images.OrderBy(i => i.Name);
                }
            }

            var skipNumber = (imageQueryObject.PageNumber - 1) * imageQueryObject.PageSize;

            return await images.Skip(skipNumber).Take(imageQueryObject.PageSize).ToListAsync();
        }

        public async Task<Image?> GetByIdAsync(long id)
        {
            var image = await _context.Image.FirstOrDefaultAsync(i => i.Id == id);

            if (image == null)
            {
                return null;
            }

            return image;
        }

        public async Task<Image?> UpdateAsync(long id, UpdateImageDTO updateImageDTO)
        {
            var image = await _context.Image.FirstOrDefaultAsync(i => i.Id == id);

            if (image == null)
            {
                return null;
            }

            _context.Entry(image).CurrentValues.SetValues(updateImageDTO);
            await _context.SaveChangesAsync();

            return image;
        }
    }
}