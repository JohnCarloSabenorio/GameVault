using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Models
{
    public class Language
    {
        public long Id { get; set; }
        public string? Locale { get; set; }
        public string? Name { get; set; }
        public string? NativeName { get; set; }
        public List<GameLanguage> GameLanguage { get; set; } = new List<GameLanguage>();

    }
}