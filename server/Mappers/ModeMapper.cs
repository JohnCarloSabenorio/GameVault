using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using server.DTOs.Mode;
using server.Models;

namespace server.Mappers
{
    public static class ModeMapper
    {
        public static ModeDTO ToModeDTO(this Mode mode)
        {
            return new ModeDTO { Name = mode.Name };
        }

        public static Mode ToModeFromCreateDTO(this CreateModeDTO createModeDTO)
        {
            return new Mode { Name = createModeDTO.Name };
        }
    }
}