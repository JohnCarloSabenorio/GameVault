using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.DTOs.Status;
using server.Helpers;
using server.Models;

namespace server.Interfaces
{
    public interface IStatusRepo
    {
        Task<List<Status>> GetAllAsync(StatusQueryObject statusQueryObject);
        Task<Status?> GetByIdAsync(long id);
        Task<Status?> CreateAsync(CreateStatusDTO createStatusDTO);
        Task<Status?> UpdateAsync(long id, UpdateStatusDTO updateStatusDTO);
        Task<Status?> DeleteAsync(long id);
    }
}