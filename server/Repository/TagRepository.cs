using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using server.Data;
using server.DTOs.Tag;
using server.Helpers;
using server.Interfaces;
using server.Mappers;
using server.Models;

namespace server.Repository
{
    public class TagRepository : ITagRepo
    {

        private readonly ApplicationDBContext _context;
        public TagRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<Tag> CreateAysnc(CreateTagDTO createTagDTO)
        {
            var newTag = createTagDTO.ToTagFromCreateDTO();

            await _context.Tag.AddAsync(newTag);
            await _context.SaveChangesAsync();

            return newTag;
        }

        public async Task<Tag?> DeleteAsync(long id)
        {
            var deletedTag = await _context.Tag.FindAsync(id);

            if (deletedTag == null)
            {
                return null;
            }

            _context.Tag.Remove(deletedTag);
            await _context.SaveChangesAsync();

            return deletedTag;
        }

        public async Task<List<Tag>> GetAllAsync(TagQueryObject tagQueryObject)
        {
            var tags = _context.Tag.AsQueryable();
            if (!string.IsNullOrEmpty(tagQueryObject.SortBy))
            {
                if (tagQueryObject.SortBy.Equals("name", StringComparison.OrdinalIgnoreCase))
                {
                    tags = tagQueryObject.IsDescending ? tags.OrderByDescending(t => t.Name) : tags.OrderBy(t => t.Name);
                }
            }

            var skipNumber = (tagQueryObject.PageNumber - 1) * tagQueryObject.PageSize;

            return await tags.Skip(skipNumber).Take(tagQueryObject.PageSize).ToListAsync();
        }

        public async Task<Tag?> GetByIdAsync(long id)
        {
            var tag = await _context.Tag.FirstOrDefaultAsync(t => t.Id == id);

            if (tag == null)
            {
                return null;
            }

            return tag;
        }

        public async Task<bool> TagExists(long id)
        {
            return await _context.Tag.AnyAsync(t => t.Id == id);
        }

        public async Task<Tag?> UpdateAsync(long id, UpdateTagDTO updateTagDTO)
        {
            var updatedTag = await _context.Tag.FirstOrDefaultAsync(t => t.Id == id);

            if (updatedTag == null)
            {
                return null;
            }

            _context.Entry(updatedTag).CurrentValues.SetValues(updateTagDTO);
            await _context.SaveChangesAsync();

            return updatedTag;
        }
    }
}