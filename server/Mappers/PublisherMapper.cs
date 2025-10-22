using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using server.DTOs.Publisher;
using server.Models;

namespace server.Mappers
{
    public static class PublisherMapper
    {
        public static PublisherDTO ToPublisherDTO(Publisher publisher)
        {
            return new PublisherDTO { Name = publisher.Name, YearFounded = publisher.YearFounded, Country = publisher.Country, Website = publisher.Website, Description = publisher.Description, ImageId = publisher.ImageId };
        }
        public static Publisher ToPublisherFromCreateDTO(long id, CreatePublisherDTO createPublisherDTO)
        {
            return new Publisher
            {
                Name = createPublisherDTO.Name,
                YearFounded = createPublisherDTO.YearFounded,
                Country = createPublisherDTO.Country,
                Website = createPublisherDTO.Website,
                Description = createPublisherDTO.Description,
                ImageId = createPublisherDTO.ImageId
            };
        }
    }
}