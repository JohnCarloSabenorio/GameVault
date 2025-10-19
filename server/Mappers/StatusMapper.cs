using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.DTOs.Status;
using server.Models;

namespace server.Mappers
{
    public static class StatusMapper
    {
        public static StatusDTO ToStatusDTO(this Status status)
        {
            return new StatusDTO { StatusName = status.StatusName };
        }

        public static Status ToStatusFromCreateDTO(this CreateStatusDTO createStatusDTO)
        {
            return new Status { StatusName = createStatusDTO.StatusName };
        }
    }
}