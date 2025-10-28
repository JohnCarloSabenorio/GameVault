using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.DTOs.Collection;
using server.Helpers;
using server.Models;

namespace server.Interfaces
{
    public interface ICollectionRepo
    {
        Task<List<Collection>> GetAllAsync(CollectionQueryObject collectionQueryObject);
        Task<Collection?> GetByIdAsync(long id);
        Task<Collection> CreateAsync(CreateCollectionDTO createCollectionDTO);
        Task<Collection?> DeleteAsync(long id);
        Task<Collection?> UpdateAsync(long id, UpdateCollectionDTO updateCollectionDTO);
    }
}