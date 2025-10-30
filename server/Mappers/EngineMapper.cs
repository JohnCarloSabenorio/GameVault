using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using server.DTOs.Engine;
using server.Models;

namespace server.Mappers
{
    public static class EngineMapper
    {
        public static EngineDTO ToEngineDTO(this Engine engine)
        {
            return new EngineDTO { Name = engine.Name, Description = engine.Description, LogoName = engine.Logo?.Name };
        }

        public static Engine ToEngineFromCreateDTO(this CreateEngineDTO createEngineDTO)
        {
            return new Engine { Name = createEngineDTO.Name, Description = createEngineDTO.Description, LogoId = createEngineDTO.LogoId };
        }
    }
}