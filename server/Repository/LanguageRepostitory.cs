using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NuGet.LibraryModel;
using server.Data;
using server.DTOs.Language;
using server.Helpers;
using server.Mappers;
using server.Models;

namespace server.Repository
{
    public class LanguageRepostitory : ILanguageRepo
    {
        private readonly ApplicationDBContext _context;

        public LanguageRepostitory(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Language> CreateAsync(CreateLanguageDTO createLanguageDTO)
        {
            var newLanguage = createLanguageDTO.ToLanguageFromCreateDTO();

            await _context.Language.AddAsync(newLanguage);
            await _context.SaveChangesAsync();

            return newLanguage;
        }

        public async Task<Language?> DeleteAsync(long id)
        {
            var deletedLanguage = await _context.Language.FindAsync(id);

            if (deletedLanguage == null)
            {
                return null;
            }

            _context.Language.Remove(deletedLanguage);
            await _context.SaveChangesAsync();

            return deletedLanguage;
        }

        public async Task<List<Language>> GetAllAsync(LanguageQueryObject languageQueryObject)
        {
            var languages = _context.Language.AsQueryable();
            if (!string.IsNullOrEmpty(languageQueryObject.SortBy))
            {
                if (languageQueryObject.SortBy.Equals("locale", StringComparison.OrdinalIgnoreCase))
                {
                    languages = languageQueryObject.IsDescending ? languages.OrderByDescending(l => l.Locale) : languages.OrderBy(l => l.Locale);
                }
                if (languageQueryObject.SortBy.Equals("name", StringComparison.OrdinalIgnoreCase))
                {
                    languages = languageQueryObject.IsDescending ? languages.OrderByDescending(l => l.Name) : languages.OrderBy(l => l.Name);
                }
                if (languageQueryObject.SortBy.Equals("nativename", StringComparison.OrdinalIgnoreCase))
                {
                    languages = languageQueryObject.IsDescending ? languages.OrderByDescending(l => l.NativeName) : languages.OrderBy(l => l.NativeName);
                }
            }

            var skipNumber = (languageQueryObject.PageNumber - 1) * languageQueryObject.PageSize;

            return await languages.Skip(skipNumber).Take(languageQueryObject.PageSize).ToListAsync();
        }

        public async Task<Language?> GetByIdAsync(long id)
        {
            var language = await _context.Language.FirstOrDefaultAsync(l => l.Id == id);

            if (language == null)
            {
                return null;
            }

            return language;
        }

        public async Task<bool> LanguageExists(long id)
        {
            return await _context.Language.AnyAsync(l => l.Id == id);
        }

        public async Task<Language?> UpdateAsync(long id, UpdateLanguageDTO updateLanguageDTO)
        {
            var updatedLanguage = await _context.Language.FirstOrDefaultAsync(l => l.Id == id);

            if (updatedLanguage == null)
            {
                return null;
            }

            _context.Entry(updatedLanguage).CurrentValues.SetValues(updateLanguageDTO);
            await _context.SaveChangesAsync();

            return updatedLanguage;
        }
    }
}