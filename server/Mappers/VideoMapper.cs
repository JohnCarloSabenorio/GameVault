using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.DTOs.VIdeo;
using server.Models;

namespace server.Mappers
{
    public static class VideoMapper
    {
        public static VideoDTO ToVideoDTO(this Video video)
        {
            return new VideoDTO { Name = video.Name };
        }
        public static Video ToVideoFromCreateDTO(this CreateVideoDTO createVideoDTO)
        {
            return new Video { Name = createVideoDTO.Name };
        }
    }
}