
using Microsoft.CodeAnalysis.Elfie.Serialization;
using Microsoft.EntityFrameworkCore;
using server.Data;
using server.DTOs.Genre;
using server.Helpers;
using server.Interfaces;
using server.Mappers;
using server.Models;

namespace server.Repository;


public class GenreRepository : IGenreRepo
{

    private readonly ApplicationDBContext _context;
    public GenreRepository(ApplicationDBContext context)
    {
        _context = context;
    }
    public async Task<Genre?> CreateAsync(CreateGenreDTO createGenreDTO)
    {
        // Convert create genre DTO to genre model
        var genreData = createGenreDTO.ToGenreFromCreateGenreDTO();
        // Add new genre model 
        await _context.Genre.AddAsync(genreData);
        // Save context changes
        await _context.SaveChangesAsync();

        // return new genre
        return genreData;

    }

    public async Task<Genre?> GetByIdAsync(long id)
    {
        return await _context.Genre.FirstOrDefaultAsync(g => g.Id == id);
    }

    public async Task<List<Genre>> GetAllAsync(GenreQueryObject queryObject)
    {
        // Create a query statement
        var genres = _context.Genre.AsQueryable();

        // Check the query objects
        if (!string.IsNullOrEmpty(queryObject.SortBy))
        {
            if (queryObject.SortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
            {
                genres = queryObject.IsDescending ? _context.Genre.OrderByDescending(g => g.Name) : _context.Genre.OrderBy(g => g.Name);
            }
        }

        // Determine number of elements to be skipped
        var skipNumber = (queryObject.PageNumber - 1) * queryObject.PageSize;

        // Return all data
        return await genres.Skip(skipNumber).Take(queryObject.PageSize).ToListAsync();
    }

    public async Task<Genre?> UpdateAsync(long id, UpdateGenreDTO updateGenreDTO)
    {
        var genre = await _context.Genre.FindAsync(id);

        if (genre == null)
        {
            return null;
        }

        _context.Entry(genre).CurrentValues.SetValues(updateGenreDTO);
        await _context.SaveChangesAsync();

        return genre;
    }

    public async Task<Genre?> DeleteAsync(long id)
    {
        var genre = await _context.Genre.FindAsync(id);

        if (genre == null)
        {
            return null;
        }

        _context.Genre.Remove(genre);
        await _context.SaveChangesAsync();

        return genre;
    }

    public async Task<bool> GenreExists(long id)
    {
        return await _context.Genre.AnyAsync(g => g.Id == id);
    }
}