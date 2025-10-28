using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using server.Data;
using server.DTOs.Collection;
using server.Helpers;
using server.Interfaces;
using server.Mappers;
using server.Models;

namespace server.Repository
{
    public class CollectionRepository : ICollectionRepo
    {

        private readonly ApplicationDBContext _context;
        public CollectionRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<bool> CollectionExists(long collectionId)
        {
            return await _context.Collection.AnyAsync(c => c.Id == collectionId);
        }

        public async Task<Collection> CreateAsync(CreateCollectionDTO createCollectionDTO)
        {
            var collectionData = createCollectionDTO.ToCollectionFromCreateDTO();

            await _context.Collection.AddAsync(collectionData);
            await _context.SaveChangesAsync();

            return collectionData;
        }

        public async Task<Collection?> DeleteAsync(long id)
        {
            var collection = await _context.Collection.FindAsync(id);
            if (collection == null)
            {
                return null;
            }

            _context.Collection.Remove(collection);
            await _context.SaveChangesAsync();

            return collection;
        }

        public async Task<List<Collection>> GetAllAsync(CollectionQueryObject collectionQueryObject)
        {
            var collections = _context.Collection.AsQueryable();
            if (!string.IsNullOrEmpty(collectionQueryObject.SortBy))
            {
                if (collectionQueryObject.SortBy.Equals("name", StringComparison.OrdinalIgnoreCase))
                {
                    collections = collectionQueryObject.IsDescending ? collections.OrderByDescending(c => c.Name) : collections.OrderBy(c => c.Name);
                }
                if (collectionQueryObject.SortBy.Equals("createdat", StringComparison.OrdinalIgnoreCase))
                {
                    collections = collectionQueryObject.IsDescending ? collections.OrderByDescending(c => c.CreatedAt) : collections.OrderBy(c => c.CreatedAt);
                }
            }

            var skipNumber = (collectionQueryObject.PageNumber - 1) * collectionQueryObject.PageSize;

            return await collections.Skip(skipNumber).Take(collectionQueryObject.PageSize).ToListAsync();
        }

        public async Task<Collection?> GetByIdAsync(long id)
        {
            var collection = await _context.Collection.FindAsync(id);

            if (collection == null)
            {
                return null;
            }
            return collection;
        }

        public async Task<Collection?> UpdateAsync(long id, UpdateCollectionDTO updateCollectionDTO)
        {
            var collection = await _context.Collection.FindAsync(id);

            if (collection == null)
            {
                return null;
            }

            _context.Entry(collection).CurrentValues.SetValues(updateCollectionDTO);
            await _context.SaveChangesAsync();

            return collection;
        }


    }
}