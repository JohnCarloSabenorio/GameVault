using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.DTOs.Developer;
using server.Models;

namespace server.Mappers
{
    public static class DeveloperMapper
    {
        public static DeveloperDTO ToDeveloperDTO(this Developer developer)
        {
            return new DeveloperDTO { Name = developer.Name, CountryOrigin = developer.CountryOrigin, WebsiteUrl = developer.WebsiteUrl, Description = developer.Description, ImageId = developer.ImageId, DateFounded = developer.DateFounded };
        }

        public static Developer ToDeveloperFromCreateDTO(this CreateDeveloperDTO createDeveloperDTO)
        {
            return new Developer { Name = createDeveloperDTO.Name, CountryOrigin = createDeveloperDTO.CountryOrigin, WebsiteUrl = createDeveloperDTO.WebsiteUrl, Description = createDeveloperDTO.Description, ImageId = createDeveloperDTO.ImageId, DateFounded = createDeveloperDTO.DateFounded };
        }
    }
}