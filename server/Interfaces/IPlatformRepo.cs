using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.DTOs.Platform;
using server.Helpers;
using server.Models;
namespace server.Interfaces
{
    public interface IPlatformRepo
    {
        Task<List<Platform>> GetAllAsync(PlatformQueryObject platformQueryObject);
        Task<Platform> GetById(long id);
        Task<Platform> CreateAsync(CreatePlatformDTO createPlatformDTO);
        Task<Platform> UpdateAsync(long id, UpdatePlatformDTO updatePlatformDTO);
        Task<Platform> DeleteAsync(long id);
    }
}