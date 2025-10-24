using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Humanizer;
using server.DTOs.Platform;
using server.Models;

namespace server.Mappers
{
    public static class PlatformMapper
    {
        public static PlatformDTO ToPlatformDTO(this Platform platform)
        {
            return new PlatformDTO { Name = platform.Name, Generation = platform.Generation, Summary = platform.Summary, Url = platform.Url, Logo = platform.Logo?.ToImageDTO() };
        }

        public static Platform ToPlatformFromCreateDTO(CreatePlatformDTO createPlatformDTO)
        {
            return new Platform { Name = createPlatformDTO.Name, Generation = createPlatformDTO.Generation, Summary = createPlatformDTO.Summary, Url = createPlatformDTO.Url, LogoId = createPlatformDTO.LogoId };
        }
    }
}