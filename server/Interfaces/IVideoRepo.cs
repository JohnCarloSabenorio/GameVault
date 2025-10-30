using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.DTOs.VIdeo;
using server.Helpers;
using server.Models;

namespace server.Interfaces
{
    public interface IVideoRepo
    {
        Task<List<Video>> GetAllAsync(VideoQueryObject videoQueryObject);
        Task<Video?> GetByIdAsync(long id);
        Task<Video> CreateAsync(CreateVideoDTO createVideoDTO);
        Task<Video?> UpdateAsync(long id, UpdateVIdeoDTO updateVIdeoDTO);
        Task<Video?> DeleteAsync(long id);
        Task<bool> VideoExists(long id);
    }
}