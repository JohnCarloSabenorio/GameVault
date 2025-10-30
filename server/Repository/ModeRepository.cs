using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.Data;
using server.DTOs.Mode;
using server.Helpers;
using server.Interfaces;
using server.Models;
using server.Mappers;
using Microsoft.EntityFrameworkCore;

namespace server.Repository
{
    public class ModeRepository : IModeRepo
    {
        private readonly ApplicationDBContext _context;
        public ModeRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Mode> CreateAsync(CreateModeDTO createModeDTO)
        {
            var newMode = createModeDTO.ToModeFromCreateDTO();

            await _context.Mode.AddAsync(newMode);
            await _context.SaveChangesAsync();

            return newMode;
        }

        public async Task<Mode?> DeleteAsync(long id)
        {
            var deletedMode = await _context.Mode.FindAsync(id);

            if (deletedMode == null)
            {
                return null;
            }

            _context.Mode.Remove(deletedMode);
            await _context.SaveChangesAsync();

            return deletedMode;
        }

        public async Task<List<Mode>> GetAllAsync(ModeQueryObject modeQueryObject)
        {
            var modes = _context.Mode.AsQueryable();
            if (!string.IsNullOrEmpty(modeQueryObject.SortBy))
            {
                if (modeQueryObject.SortBy.Equals("name", StringComparison.OrdinalIgnoreCase))
                {
                    modes = modeQueryObject.IsDescending ? modes.OrderByDescending(m => m.Name) : modes.OrderBy(m => m.Name);
                }
            }

            var skipNumber = (modeQueryObject.PageNumber - 1) * modeQueryObject.PageSize;

            return await modes.Skip(skipNumber).Take(modeQueryObject.PageSize).ToListAsync();
        }

        public async Task<Mode?> GetByIdAsync(long id)
        {
            var mode = await _context.Mode.FirstOrDefaultAsync(m => m.Id == id);

            if (mode == null)
            {
                return null;
            }

            return mode;
        }

        public async Task<bool> ModeExists(long id)
        {
            return await _context.Mode.AnyAsync(m => m.Id == id);
        }

        public async Task<Mode?> UpdateAsync(long id, UpdateModeDTO updateModeDTO)
        {
            var updatedMode = await _context.Mode.FirstOrDefaultAsync(m => m.Id == id);

            if (updatedMode == null)
            {
                return null;
            }

            _context.Entry(updatedMode).CurrentValues.SetValues(updateModeDTO);
            await _context.SaveChangesAsync();

            return updatedMode;
        }
    }
}