using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using server.Data;
using server.DTOs.Publisher;
using server.Helpers;
using server.Interfaces;
using server.Mappers;
using server.Models;

namespace server.Repository
{

    public class PublisherRepository : IPublisherRepo
    {
        private readonly ApplicationDBContext _context;

        public PublisherRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Publisher> CreateAsync(CreatePublisherDTO createPublisherDTO)
        {
            var newPublisherData = createPublisherDTO.ToPublisherFromCreateDTO();

            await _context.Publisher.AddAsync(newPublisherData);
            await _context.SaveChangesAsync();

            return newPublisherData;
        }

        public async Task<Publisher?> DeleteAsync(long id)
        {
            var deletedPublisher = await _context.Publisher.FindAsync(id);

            if (deletedPublisher == null)
            {
                return null;
            }

            _context.Publisher.Remove(deletedPublisher);
            await _context.SaveChangesAsync();

            return deletedPublisher;
        }

        public async Task<List<Publisher>> GetAllAsync(PublisherQueryObject publisherQueryObject)
        {
            var publishers = _context.Publisher.AsQueryable();
            if (!string.IsNullOrEmpty(publisherQueryObject.SortBy))
            {
                if (publisherQueryObject.SortBy.Equals("name", StringComparison.OrdinalIgnoreCase))
                {
                    publishers = publisherQueryObject.IsDescending ? publishers.OrderByDescending(p => p.Name) : publishers.OrderBy(p => p.Name);
                }
                if (publisherQueryObject.SortBy.Equals("yearfounded", StringComparison.OrdinalIgnoreCase))
                {
                    publishers = publisherQueryObject.IsDescending ? publishers.OrderByDescending(p => p.YearFounded) : publishers.OrderBy(p => p.YearFounded);
                }
                if (publisherQueryObject.SortBy.Equals("country", StringComparison.OrdinalIgnoreCase))
                {
                    publishers = publisherQueryObject.IsDescending ? publishers.OrderByDescending(p => p.Country) : publishers.OrderBy(p => p.Country);
                }
            }

            var skipNumber = (publisherQueryObject.PageNumber - 1) * publisherQueryObject.PageSize;

            return await publishers.Skip(skipNumber).Take(publisherQueryObject.PageSize).ToListAsync();
        }

        public async Task<Publisher?> GetByIdAsync(long id)
        {
            var publisher = await _context.Publisher.FindAsync(id);

            if (publisher == null)
            {
                return null;
            }

            return publisher;
        }

        public async Task<bool> PublisherExists(long id)
        {
            return await _context.Publisher.AnyAsync(p => p.Id == id);
        }

        public async Task<Publisher?> UpdateAsync(long id, UpdatePublisherDTO updatePublisherDTO)
        {
            var updatedPublisher = await _context.Publisher.FirstOrDefaultAsync(p => p.Id == id);

            if (updatedPublisher == null)
            {
                return null;
            }

            _context.Entry(updatedPublisher).CurrentValues.SetValues(updatePublisherDTO);
            await _context.SaveChangesAsync();

            return updatedPublisher;
        }
    }
}