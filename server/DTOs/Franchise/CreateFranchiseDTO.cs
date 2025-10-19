using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace server.DTOs.Franchise
{
    public class CreateFranchiseDTO
    {
        [MinLength(1, ErrorMessage = "Franchise name must be atleast 1 character long.")]
        [MaxLength(350, ErrorMessage = "Franchise name cannot exceed 350 characters.")]
        public string Name { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
    }
}