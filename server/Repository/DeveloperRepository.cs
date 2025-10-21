using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using server.Data;
using server.DTOs.Developer;
using server.Helpers;
using server.Interfaces;
using server.Mappers;
using server.Models;

namespace server.Repository
{
    public class DeveloperRepository : IDeveloperRepo
    {
        private readonly ApplicationDBContext _context;
        public DeveloperRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Developer> CreateAsync(CreateDeveloperDTO createDeveloperDTO)
        {
            var newDeveloper = createDeveloperDTO.ToDeveloperFromCreateDTO();

            await _context.Developer.AddAsync(newDeveloper);
            await _context.SaveChangesAsync();

            return newDeveloper;

        }

        public async Task<Developer?> DeleteAsync(long id)
        {
            var deletedDeveloper = await _context.Developer.FirstOrDefaultAsync(d => d.Id == id);
            if (deletedDeveloper == null)
            {
                return null;
            }

            _context.Developer.Remove(deletedDeveloper);
            await _context.SaveChangesAsync();

            return deletedDeveloper;
        }

        public async Task<Developer?> GetByIdAsync(long id)
        {
            var developer = await _context.Developer.FirstOrDefaultAsync(d => d.Id == id);

            if (developer == null)
            {
                return null;
            }

            return developer;
        }

        public async Task<List<Developer>> GetlAllAsync(DeveloperQueryObject developerQueryObject)
        {
            var developers = _context.Developer.AsQueryable();

            if (!string.IsNullOrEmpty(developerQueryObject.SortBy))
            {
                if (developerQueryObject.SortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    developers = developerQueryObject.IsDescending ? developers.OrderByDescending(d => d.Name) : developers.OrderBy(d => d.Name);
                }
                else if (developerQueryObject.SortBy.Equals("CountryOrigin", StringComparison.OrdinalIgnoreCase))
                {
                    developers = developerQueryObject.IsDescending ? developers.OrderByDescending(d => d.CountryOrigin) : developers.OrderBy(d => d.CountryOrigin);
                }
                else if (developerQueryObject.SortBy.Equals("DateFounded", StringComparison.OrdinalIgnoreCase))
                {
                    developers = developerQueryObject.IsDescending ? developers.OrderByDescending(d => d.DateFounded) : developers.OrderBy(d => d.DateFounded);
                }
            }

            var skipNumber = (developerQueryObject.PageNumber - 1) * developerQueryObject.PageSize;

            return await developers.Skip(skipNumber).Take(developerQueryObject.PageSize).ToListAsync();
        }

        public async Task<Developer?> UpdateAsync(long id, UpdateDeveloperDTO updateDeveloperDTO)
        {
            var developer = await _context.Developer.FirstOrDefaultAsync(d => d.Id == id);

            if (developer == null)
            {
                return null;
            }

            _context.Entry(developer).CurrentValues.SetValues(updateDeveloperDTO);
            await _context.SaveChangesAsync();

            return developer;
        }
    }
}