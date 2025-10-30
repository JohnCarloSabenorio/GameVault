using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.DTOs.Tag;
using server.Helpers;
using server.Models;

namespace server.Interfaces
{
    public interface ITagRepo
    {
        Task<List<Tag>> GetAllAsync(TagQueryObject tagQueryObject);
        Task<Tag?> GetByIdAsync(long id);
        Task<Tag> CreateAysnc(CreateTagDTO createTagDTO);
        Task<Tag?> UpdateAsync(long id, UpdateTagDTO updateTagDTO);
        Task<Tag?> DeleteAsync(long id);

        Task<bool> TagExists(long id);
    }
}