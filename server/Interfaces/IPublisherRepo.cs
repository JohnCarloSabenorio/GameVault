using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.DTOs.Publisher;
using server.Helpers;
using server.Models;

namespace server.Interfaces
{
    public interface IPublisherRepo
    {
        Task<List<Publisher>> GetAllAsync(PublisherQueryObject publisherQueryObject);
        Task<Publisher?> GetByIdAsync(long id);
        Task<Publisher> CreateAsync(CreatePublisherDTO createPublisherDTO);
        Task<Publisher?> UpdateAsync(long id, UpdatePublisherDTO updatePublisherDTO);
        Task<Publisher?> DeleteAsync(long id);
    }
}