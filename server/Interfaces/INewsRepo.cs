using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.DTOs.News;
using server.Helpers;
using server.Models;

namespace server.Interfaces
{
    public interface INewsRepo
    {
        Task<List<News>> GetAllAsync(NewsQueryObject newsQueryObject);
        Task<News?> GetByIdAsync(long id);
        Task<News> CreateAsync(CreateNewsDTO createNewsDTO);
        Task<News?> UpdateAsync(long id, UpdateNewsDTO updateNewsDTO);
        Task<News?> DeleteAsync(long id);
    }
}