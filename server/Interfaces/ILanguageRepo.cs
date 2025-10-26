

using server.DTOs.Language;
using server.Helpers;
using server.Models;

public interface ILanguageRepo
{
    Task<List<Language>> GetAllAsync(LanguageQueryObject languageQueryObject);

    Task<Language?> GetByIdAsync(long id);

    // Create

    Task<Language> CreateAsync(CreateLanguageDTO createLanguageDTO);
    // Update
    Task<Language?> UpdateAsync(long id, UpdateLanguageDTO updateLanguageDTO);
    // Delete
    Task<Language?> DeleteAsync(long id);

}