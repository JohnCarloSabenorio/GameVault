using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.DTOs.Engine;
using server.Helpers;
using server.Models;

namespace server.Interfaces
{
    public interface IEngineRepo
    {
        Task<List<Engine>> GetAllAsync(EngineQueryObject engineQueryObject);
        Task<Engine?> GetByIdAsync(long id);
        Task<Engine> CreateAsync(CreateEngineDTO createEngineDTO);
        Task<Engine?> UpdateAsync(long id, UpdateEngineDTO updateEngineDTO);
        Task<Engine?> DeleteAsync(long id);
    }
}