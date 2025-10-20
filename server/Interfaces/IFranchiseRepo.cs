using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.DTOs.Franchise;
using server.Helpers;
using server.Models;

namespace server.Interfaces
{
    public interface IFranchiseRepo
    {
        Task<List<Franchise>> GetAllAsync(FranchiseQueryObject franchiseQueryObject);
        Task<Franchise?> GetByIdAsync(long id);
        Task<Franchise> CreateAsync(CreateFranchiseDTO createFranchiseDTO);
        Task<Franchise?> UpdateAsync(long id, UpdateFranchiseDTO updateFranchiseDTO);
        Task<Franchise?> DeleteAsync(long id);
    }
}