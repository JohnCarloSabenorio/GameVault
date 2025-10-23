using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.DTOs.VideoGameCollection;
using server.Helpers;
using server.Models;

namespace server.Interfaces
{
    public interface IVideoGameCollectionRepo
    {
        Task<List<VideoGameCollection>> GetAllAsync(VideoGameCollectionQueryObject videoGameCollectionQueryObject);
        Task<VideoGameCollection?> GetByIdAsync(long id);
        Task<VideoGameCollection> CreateAsync(CreateVideoGameCollectionDTO createVideoGameCollectionDTO);
        Task<VideoGameCollection?> DeleteAsync(long id);
        Task<VideoGameCollection?> UpdateAsync(long id, UpdateVideoGameCollectionDTO updateVideoGameCollectionDTO);
    }
}