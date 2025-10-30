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
    public class PlatformRepository : IPlatformRepo
    {

        private readonly ApplicationDBContext _context;
        public PlatformRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<Platform> CreateAsync(CreatePlatformDTO createPlatformDTO)
        {
            var newPlatform = createPlatformDTO.ToPlatformFromCreateDTO();

            await _context.Platform.AddAsync(newPlatform);
            await _context.SaveChangesAsync();

            await _context.Entry(newPlatform).Reference(p => p.Logo).LoadAsync();
            return newPlatform;
        }

        public async Task<Platform?> DeleteAsync(long id)
        {
            var deletedPlatform = await _context.Platform.FindAsync(id);

            if (deletedPlatform == null)
            {
                return null;
            }
            _context.Platform.Remove(deletedPlatform);
            await _context.SaveChangesAsync();

            return deletedPlatform;
        }

        public Task<List<Platform>> GetAllAsync(PlatformQueryObject platformQueryObject)
        {
            var platforms = _context.Platform.AsQueryable();
            if (!string.IsNullOrEmpty(platformQueryObject.SortBy))
            {
                if (platformQueryObject.SortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    platforms = platformQueryObject.IsDescending ? platforms.OrderByDescending(p => p.Name) : platforms.OrderBy(p => p.Name);
                }
                else if (platformQueryObject.SortBy.Equals("Generation", StringComparison.OrdinalIgnoreCase))
                {
                    platforms = platformQueryObject.IsDescending ? platforms.OrderByDescending(p => p.Generation) : platforms.OrderBy(p => p.Generation);
                }
            }

            var skipNumber = (platformQueryObject.PageNumber - 1) * platformQueryObject.PageSize;

            return platforms.Skip(skipNumber).Take(platformQueryObject.PageSize).Include(p => p.Logo).ToListAsync();
        }

        public async Task<Platform?> GetByIdAsync(long id)
        {
            var platform = await _context.Platform.Include(p => p.Logo).FirstOrDefaultAsync(p => p.Id == id);

            if (platform == null) { return null; }

            return platform;
        }


        public async Task<Platform?> UpdateAsync(long id, UpdatePlatformDTO updatePlatformDTO)
        {
            var updatedPlatform = await _context.Platform.Include(p => p.Logo).FirstOrDefaultAsync(p => p.Id == id);

            if (updatedPlatform == null) { return null; }

            _context.Entry(updatedPlatform).CurrentValues.SetValues(updatePlatformDTO);
            await _context.SaveChangesAsync();
            return updatedPlatform;
        }
    }
}