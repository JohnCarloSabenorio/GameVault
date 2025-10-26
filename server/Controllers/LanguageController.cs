using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using server.DTOs.Language;
using server.Helpers;
using server.Mappers;
using server.Models;

namespace server.Controllers
{
    [Route("api/language")]
    [ApiController]
    public class LanguageController : ControllerBase
    {
        private readonly ILanguageRepo _languageRepo;
        public LanguageController(ILanguageRepo languageRepo)
        {
            _languageRepo = languageRepo;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<LanguageDTO>>> GetAll([FromQuery] LanguageQueryObject languageQueryObject)
        {
            var languages = await _languageRepo.GetAllAsync(languageQueryObject);

            var languageDtos = languages.Select(l => l.ToLanguageDTO());

            return Ok(languageDtos);
        }

        [HttpGet("{id:long}")]
        public async Task<ActionResult<LanguageDTO>> GetById([FromRoute] long id)
        {
            var language = await _languageRepo.GetByIdAsync(id);

            if (language == null)
            {
                return NotFound("Language does not exist.");
            }

            return Ok(language.ToLanguageDTO());
        }

        [HttpPost]
        public async Task<ActionResult<LanguageDTO>> Create(CreateLanguageDTO createLanguageDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newLanguage = await _languageRepo.CreateAsync(createLanguageDTO);

            return CreatedAtAction(nameof(GetById), new { id = newLanguage.Id }, newLanguage.ToLanguageDTO());
        }

        [HttpPut("{id:long}")]
        public async Task<ActionResult<LanguageDTO>> Update([FromRoute] long id, UpdateLanguageDTO updateLanguageDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatedLanguage = await _languageRepo.UpdateAsync(id, updateLanguageDTO);
            if (updatedLanguage == null)
            {
                return NotFound("Language does not exist.");
            }

            return Ok(updatedLanguage.ToLanguageDTO());
        }

        [HttpDelete("{id:long}")]
        public async Task<IActionResult> Delete([FromRoute] long id)
        {
            var deletedLanguage = await _languageRepo.DeleteAsync(id);

            if (deletedLanguage == null)
            {
                return NotFound("Language does not exist.");
            }

            return NoContent();
        }
    }
}