using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.DTOs.Language;
using server.Models;

namespace server.Mappers
{
    public static class LanguageMapper
    {
        public static LanguageDTO ToLanguageDTO(this Language language)
        {
            return new LanguageDTO { Locale = language.Locale, Name = language.Name, NativeName = language.NativeName };
        }

        public static Language ToLanguageFromCreateDTO(this CreateLanguageDTO createLanguageDTO)
        {
            return new Language { Locale = createLanguageDTO.Locale, Name = createLanguageDTO.Name, NativeName = createLanguageDTO.NativeName };
        }
    }
}