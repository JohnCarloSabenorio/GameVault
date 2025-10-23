using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.DTOs.News;
using server.Models;

namespace server.Mappers
{
    public static class NewsMapper
    {
        public static NewsDTO ToNewsDTO(this News news)
        {
            return new NewsDTO { Header = news.Header, Content = news.Content, CreatedAt = news.CreatedAt, UpdatedAt = news.UpdatedAt };
        }

        public static News ToNewsFromCreateDTO(this CreateNewsDTO createNewsDTO)
        {
            return new News { Header = createNewsDTO.Header, Content = createNewsDTO.Content };
        }
    }
}