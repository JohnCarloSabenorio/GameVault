using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.DTOs.Mode;
using server.Helpers;
using server.Models;

namespace server.Interfaces
{
    public interface IModeRepo
    {
        Task<List<Mode>> GetAllAsync(ModeQueryObject modeQueryObject);
        Task<Mode?> GetByIdAsync(long id);
        Task<Mode> CreateAsync(CreateModeDTO createModeDTO);
        Task<Mode?> UpdateAsync(long id, UpdateModeDTO updateModeDTO);
        Task<Mode?> DeleteAsync(long id);
    }
}