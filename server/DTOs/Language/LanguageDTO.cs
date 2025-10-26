using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.DTOs.Language
{
    public class LanguageDTO
    {
        public string? Locale { get; set; }
        public string? Name { get; set; }
        public string? NativeName { get; set; }
    }
}