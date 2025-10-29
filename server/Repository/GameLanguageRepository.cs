using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using server.Data;
using server.Interfaces;
using server.Models;

namespace server.Repository
{
    public class GameLanguageRepository : IGameLanguageRepo
    {
        private readonly ApplicationDBContext _context;
        public GameLanguageRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<GameLanguage> CreateAsync(long gameId, long languageId)
        {
            var newGameLanguage = new GameLanguage { GameId = gameId, LanguageId = languageId };

            await _context.GameLanguage.AddAsync(newGameLanguage);
            await _context.SaveChangesAsync();

            return newGameLanguage;
        }

        public async Task<GameLanguage?> DeleteAsync(long gameId, long languageId)
        {
            var deletedGameLanguage = await _context.GameLanguage.FirstOrDefaultAsync(x => x.GameId == gameId && x.LanguageId == languageId);

            if (deletedGameLanguage == null)
            {
                return null;
            }

            _context.GameLanguage.Remove(deletedGameLanguage);
            await _context.SaveChangesAsync();
            return deletedGameLanguage;
        }

        public async Task<bool> GameLanguageExists(long gameId, long languageId)
        {
            return await _context.GameLanguage.AnyAsync(x => x.GameId == gameId && x.LanguageId == languageId);
        }

        public async Task<List<Language>> GetGameLanguages(long gameId)
        {
            return await _context.GameLanguage.Where(x => x.GameId == gameId).Select(x => new Language { Locale = x.Language.Locale, Name = x.Language.Name, NativeName = x.Language.NativeName }).ToListAsync();
        }
    }
}