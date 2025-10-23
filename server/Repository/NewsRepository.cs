using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using server.Data;
using server.DTOs.News;
using server.Helpers;
using server.Interfaces;
using server.Mappers;
using server.Models;

namespace server.Repository
{
    public class NewsRepository : INewsRepo
    {
        private readonly ApplicationDBContext _context;
        public NewsRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<News> CreateAsync(CreateNewsDTO createNewsDTO)
        {
            var news = createNewsDTO.ToNewsFromCreateDTO();

            await _context.News.AddAsync(news);
            await _context.SaveChangesAsync();

            return news;
        }

        public async Task<News?> DeleteAsync(long id)
        {
            var deletedNews = await _context.News.FindAsync(id);
            if (deletedNews == null)
            {
                return null;
            }

            _context.News.Remove(deletedNews);
            await _context.SaveChangesAsync();

            return deletedNews;
        }

        public async Task<List<News>> GetAllAsync(NewsQueryObject newsQueryObject)
        {
            var allNews = _context.News.AsQueryable();

            if (!string.IsNullOrEmpty(newsQueryObject.SortBy))
            {
                if (newsQueryObject.SortBy.Equals("header", StringComparison.OrdinalIgnoreCase))
                {
                    allNews = newsQueryObject.IsDescending ? allNews.OrderByDescending(n => n.Header) : allNews.OrderBy(n => n.Header);
                }
                if (newsQueryObject.SortBy.Equals("createdat", StringComparison.OrdinalIgnoreCase))
                {
                    allNews = newsQueryObject.IsDescending ? allNews.OrderByDescending(n => n.CreatedAt) : allNews.OrderBy(n => n.CreatedAt);
                }
                if (newsQueryObject.SortBy.Equals("updatedat", StringComparison.OrdinalIgnoreCase))
                {
                    allNews = newsQueryObject.IsDescending ? allNews.OrderByDescending(n => n.UpdatedAt) : allNews.OrderBy(n => n.UpdatedAt);
                }
            }

            var skipNumber = (newsQueryObject.PageNumber - 1) * newsQueryObject.PageSize;

            return await allNews.Skip(skipNumber).Take(newsQueryObject.PageSize).ToListAsync();
        }

        public async Task<News?> GetByIdAsync(long id)
        {
            var news = await _context.News.FindAsync(id);

            if (news == null)
            {
                return null;
            }

            return news;
        }

        public async Task<News?> UpdateAsync(long id, UpdateNewsDTO updateNewsDTO)
        {
            var news = await _context.News.FindAsync(id);

            if (news == null)
            {
                return null;
            }
            _context.Entry(news).CurrentValues.SetValues(updateNewsDTO);
            await _context.SaveChangesAsync();

            return news;
        }
    }
}