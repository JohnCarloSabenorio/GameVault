using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.Models;

namespace server.Interfaces
{
    public interface IGameLanguageRepo
    {
        // Getting game languages
        Task<List<GameLanguage>> GetGameLanguages(long gameId);
        // Creating game language
        Task<GameLanguage> CreateAsync(long gameId, long languageId);
        // Deleting game language
        Task<GameLanguage?> DeleteAsync(long gameId, long languageId);
        // Checking if game language exists
        Task<bool> GameLanguageExists(long gameId, long languageId);

    }
}