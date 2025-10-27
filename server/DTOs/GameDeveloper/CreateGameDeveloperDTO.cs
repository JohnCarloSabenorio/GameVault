using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace server.DTOs.GameDeveloper
{
    public class CreateGameDeveloperDTO
    {
        [Required]
        public long DeveloperId { get; set; }
    }
}