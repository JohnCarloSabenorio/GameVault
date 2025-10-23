using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.DTOs.VideoGameCollection;
using server.Models;

namespace server.Mappers
{
    public static class VideoGameCollectionMapper
    {
        public static VideoGameCollectionDTO ToVideoGameCollectionDTO(this VideoGameCollection videoGameCollection)
        {
            return new VideoGameCollectionDTO
            {
                Name = videoGameCollection.Name,
                Description = videoGameCollection.Description,
                CreatedAt = videoGameCollection.CreatedAt
            };
        }

        public static VideoGameCollection ToVideoGameCollectionFromCreateDTO(this CreateVideoGameCollectionDTO createVideoGameCollectionDTO)
        {
            return new VideoGameCollection { UserId = createVideoGameCollectionDTO.UserId, Name = createVideoGameCollectionDTO.Name, Description = createVideoGameCollectionDTO.Description };
        }
    }
}