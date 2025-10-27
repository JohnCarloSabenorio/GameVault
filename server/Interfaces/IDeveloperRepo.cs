using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.DTOs.Developer;
using server.Helpers;
using server.Models;

namespace server.Interfaces
{
    public interface IDeveloperRepo
    {
        Task<List<Developer>> GetlAllAsync(DeveloperQueryObject developerQueryObject);
        Task<Developer?> GetByIdAsync(long id);
        Task<Developer> CreateAsync(CreateDeveloperDTO createDeveloperDTO);
        Task<Developer?> UpdateAsync(long id, UpdateDeveloperDTO updateDeveloperDTO);
        Task<Developer?> DeleteAsync(long id);

        Task<bool> DeveloperExists(long id);
    }
}