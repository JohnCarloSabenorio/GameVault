using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.DTOs.Collection;
using server.Models;

namespace server.Mappers
{
    public static class CollectionMapper
    {
        public static CollectionDTO ToCollectionDTO(this Collection collection)
        {
            return new CollectionDTO
            {
                Name = collection.Name,
                Description = collection.Description,
                CreatedAt = collection.CreatedAt
            };
        }

        public static Collection ToCollectionFromCreateDTO(this CreateCollectionDTO createCollectionDTO)
        {
            return new Collection { UserId = createCollectionDTO.UserId, Name = createCollectionDTO.Name, Description = createCollectionDTO.Description };
        }
    }
}