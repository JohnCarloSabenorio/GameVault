using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.DTOs.Image;
using server.Helpers;
using server.Models;

namespace server.Interfaces
{
    public interface IImageRepo
    {
        Task<List<Image>> GetAllAsync(ImageQueryObject imageQueryObject);
        Task<Image?> GetByIdAsync(long id);
        Task<Image?> CreateAsync(CreateImageDTO createImageDTO);
        Task<Image?> UpdateAsync(long id, UpdateImageDTO updateImageDTO);
        Task<Image?> DeleteAsync(long id);
    }
}