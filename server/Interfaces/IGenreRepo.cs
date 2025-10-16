using server.DTOs.Genre;
using server.Helpers;
using server.Models;

namespace server.Interfaces;


public interface IGenreRepo
{

    Task<List<Genre>> GetAllAsync(GenreQueryObject queryObject);

    Task<Genre?> GetByIdAsync(long id);

    // Create

    Task<Genre?> CreateAsync(CreateGenreDTO createGenreDTO);
    // Update
    Task<Genre?> UpdateAsync(long id, UpdateGenreDTO updateGenreDTO);
    // Delete
    Task<Genre?> DeleteAsync(long id);

}