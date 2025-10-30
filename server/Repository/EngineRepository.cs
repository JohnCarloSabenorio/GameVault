using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using server.Data;
using server.DTOs.Engine;
using server.Helpers;
using server.Interfaces;
using server.Mappers;
using server.Models;

namespace server.Repository
{
    public class EngineRepository : IEngineRepo
    {
        private readonly ApplicationDBContext _context;
        public EngineRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Engine> CreateAsync(CreateEngineDTO createEngineDTO)
        {
            var newEngine = createEngineDTO.ToEngineFromCreateDTO();

            await _context.Engine.AddAsync(newEngine);
            await _context.SaveChangesAsync();

            await _context.Entry(newEngine).Reference(g => g.Logo).LoadAsync();
            return newEngine;
        }

        public async Task<Engine?> DeleteAsync(long id)
        {
            var engine = await _context.Engine.FindAsync(id);

            if (engine == null)
            {
                return null;
            }

            _context.Engine.Remove(engine);
            await _context.SaveChangesAsync();

            return engine;
        }

        public async Task<bool> EngineExists(long id)
        {
            return await _context.Engine.AnyAsync(e => e.Id == id);
        }

        public async Task<List<Engine>> GetAllAsync(EngineQueryObject engineQueryObject)
        {

            var engines = _context.Engine.AsQueryable();
            if (!string.IsNullOrEmpty(engineQueryObject.SortBy))
            {
                if (engineQueryObject.SortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    engines = engineQueryObject.IsDescending ? engines.OrderByDescending(g => g.Name) : engines.OrderBy(g => g.Name);
                }
            }

            var skipNumber = (engineQueryObject.PageNumber - 1) * engineQueryObject.PageSize;

            return await engines.Skip(skipNumber).Take(engineQueryObject.PageSize).Include(g => g.Logo).ToListAsync();
        }

        public async Task<Engine?> GetByIdAsync(long id)
        {
            var engine = await _context.Engine.Include(g => g.Logo).FirstOrDefaultAsync(g => g.Id == id);

            if (engine == null)
            {
                return null;
            }

            return engine;
        }

        public async Task<Engine?> UpdateAsync(long id, UpdateEngineDTO updateEngineDTO)
        {
            var engine = await _context.Engine.FirstOrDefaultAsync(g => g.Id == id);

            if (engine == null)
            {
                return null;
            }

            _context.Entry(engine).CurrentValues.SetValues(updateEngineDTO);
            await _context.SaveChangesAsync();

            var updatedEngine = await _context.Engine.Include(g => g.Logo).FirstOrDefaultAsync(g => g.Id == id);

            return updatedEngine;
        }
    }
}