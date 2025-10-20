using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using server.DTOs.Image;
using server.DTOs.Status;
using server.Models;

namespace server.Mappers
{
    public static class ImageMapper
    {
        public static ImageDTO ToImageDTO(this Image image)
        {
            return new ImageDTO { Name = image.Name };
        }


        public static Image ToImageFromCreateDTO(this CreateImageDTO createImageDTO)
        {
            return new Image { Name = createImageDTO.Name };
        }
    }
}