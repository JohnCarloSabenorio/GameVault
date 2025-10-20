

using System.Collections.Immutable;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using server.Data;
using server.DTOs.Franchise;
using server.Helpers;
using server.Interfaces;
using server.Mappers;
using server.Models;

namespace server.Repository;


public class FranchiseRepository : IFranchiseRepo
{

    private readonly ApplicationDBContext _context;

    public FranchiseRepository(ApplicationDBContext context)
    {
        _context = context;
    }

    public async Task<Franchise> CreateAsync(CreateFranchiseDTO createFranchiseDTO)
    {
        // Convert
        var franchiseData = createFranchiseDTO.ToFranchiseFromCreateDTO();
        // Add to repo
        await _context.Franchise.AddAsync(franchiseData);

        // Save changes to db
        await _context.SaveChangesAsync();

        // Return data
        return franchiseData;
    }

    public async Task<Franchise?> DeleteAsync(long id)
    {
        var franchise = await _context.Franchise.FirstOrDefaultAsync(f => f.Id == id);

        if (franchise == null)
        {
            return null;
        }

        _context.Franchise.Remove(franchise);
        await _context.SaveChangesAsync();

        return franchise;
    }

    public async Task<List<Franchise>> GetAllAsync(FranchiseQueryObject franchiseQueryObject)
    {
        var franchises = _context.Franchise.AsQueryable();

        if (!string.IsNullOrEmpty(franchiseQueryObject.SortBy))
        {
            if (franchiseQueryObject.SortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
                franchises = franchiseQueryObject.IsDescending ? franchises.OrderByDescending(f => f.Name) : franchises.OrderBy(f => f.Name);
        }

        var skipNumber = (franchiseQueryObject.PageNumber - 1) * franchiseQueryObject.PageSize;

        return await franchises.Skip(skipNumber).Take(franchiseQueryObject.PageSize).ToListAsync();
    }

    public async Task<Franchise?> GetByIdAsync(long id)
    {
        return await _context.Franchise.FirstOrDefaultAsync(f => f.Id == id);
    }

    public async Task<Franchise?> UpdateAsync(long id, UpdateFranchiseDTO updateFranchiseDTO)
    {
        var franchise = await _context.Franchise.FirstOrDefaultAsync(f => f.Id == id);
        if (franchise == null)
        {
            return null;
        }
        _context.Entry(franchise).CurrentValues.SetValues(updateFranchiseDTO);
        await _context.SaveChangesAsync();
        return franchise;
    }
}