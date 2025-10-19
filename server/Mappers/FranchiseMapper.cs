using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.StaticAssets;
using server.DTOs.Franchise;
using server.Models;

namespace server.Mappers
{
    public static class FranchiseMapper
    {

        public static FranchiseDTO ToFranchiseDTO(this Franchise franchise)
        {
            return new FranchiseDTO { Id = franchise.Id, Name = franchise.Name, Url = franchise.Url };
        }

        public static Franchise ToFranchiseFromCreateDTO(this CreateFranchiseDTO createFranchiseDTO)
        {
            return new Franchise { Name = createFranchiseDTO.Name, Url = createFranchiseDTO.Url };
        }
    }
}