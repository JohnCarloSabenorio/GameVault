using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using server.Data;
using server.DTOs.Status;
using server.Helpers;
using server.Interfaces;
using server.Mappers;
using server.Models;

namespace server.Repository
{

    public class StatusRepository : IStatusRepo
    {
        private readonly ApplicationDBContext _context;
        public StatusRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<Status?> CreateAsync(CreateStatusDTO createStatusDTO)
        {
            // Convert create dto to status model data
            var status = createStatusDTO.ToStatusFromCreateDTO();

            await _context.Status.AddAsync(status);

            await _context.SaveChangesAsync();

            return status;

        }

        public async Task<Status?> DeleteAsync(long id)
        {
            var deletedStatus = _context.Status.FirstOrDefault(s => s.Id == id);

            if (deletedStatus == null)
            {
                return null;
            }

            _context.Status.Remove(deletedStatus);
            await _context.SaveChangesAsync();

            return deletedStatus;
        }

        public async Task<List<Status>> GetAllAsync(StatusQueryObject statusQueryObject)
        {
            var statuses = _context.Status.AsQueryable();

            // Check queries

            if (!string.IsNullOrEmpty(statusQueryObject.SortBy))
            {
                if (statusQueryObject.SortBy.Equals("statusname", StringComparison.OrdinalIgnoreCase))
                {
                    statuses = statusQueryObject.IsDescending ? statuses.OrderByDescending(s => s.StatusName) : statuses.OrderBy(s => s.StatusName);
                }
            }

            var skipNumber = (statusQueryObject.PageNumber - 1) * statusQueryObject.PageSize;

            return await statuses.Skip(skipNumber).Take(statusQueryObject.PageSize).ToListAsync();
        }

        public async Task<Status?> GetByIdAsync(long id)
        {
            var status = await _context.Status.FindAsync(id);

            if (status == null)
            {
                return null;
            }

            return status;
        }

        public async Task<Status?> UpdateAsync(long id, UpdateStatusDTO updateStatusDTO)
        {
            var updatedStatus = await _context.Status.FindAsync(id);

            if (updatedStatus == null)
            {
                return null;
            }

            _context.Entry(updatedStatus).CurrentValues.SetValues(updateStatusDTO);
            await _context.SaveChangesAsync();

            return updatedStatus;
        }
    }
}