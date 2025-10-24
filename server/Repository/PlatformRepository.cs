using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using server.Data;
using server.DTOs.Platform;
using server.Helpers;
using server.Interfaces;
using server.Mappers;

namespace server.Repository
{
    public class PlatformRepository : IPlatformRepo
    {
        private readonly ApplicationDBContext _context;
        public PlatformRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public Task<Models.Platform> CreateAsync(CreatePlatformDTO createPlatformDTO)
        {
            throw new NotImplementedException();
        }

        public Task<Models.Platform> DeleteAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Models.Platform>> GetAllAsync(PlatformQueryObject platformQueryObject)
        {
            throw new NotImplementedException();
        }

        public Task<Models.Platform> GetById(long id)
        {
            throw new NotImplementedException();
        }

        public Task<Models.Platform> UpdateAsync(long id, UpdatePlatformDTO updatePlatformDTO)
        {
            throw new NotImplementedException();
        }
    }
}