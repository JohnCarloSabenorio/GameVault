using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.DTOs.Tag;
using server.Models;

namespace server.Mappers
{
    public static class TagMapper
    {
        public static TagDTO ToTagDTO(this Tag tag)
        {
            return new TagDTO { Name = tag.Name };
        }

        public static Tag ToTagFromCreateDTO(this CreateTagDTO createTagDTO)
        {
            return new Tag { Name = createTagDTO.Name };
        }
    }
}