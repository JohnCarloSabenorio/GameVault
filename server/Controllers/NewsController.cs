using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using server.DTOs.News;
using server.Helpers;
using server.Interfaces;
using server.Mappers;

namespace server.Controllers
{

    [Route("api/news")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly INewsRepo _newsRepo;
        public NewsController(INewsRepo newsRepo)
        {
            _newsRepo = newsRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<NewsDTO>>> GetAll([FromQuery] NewsQueryObject newsQueryObject)
        {
            var allNews = await _newsRepo.GetAllAsync(newsQueryObject);

            var allnewsDTO = allNews.Select(n => n.ToNewsDTO());

            return Ok(allnewsDTO);
        }

        [HttpGet("{id:long}")]
        public async Task<ActionResult<NewsDTO>> GetById([FromRoute] long id)
        {
            var news = await _newsRepo.GetByIdAsync(id);

            if (news == null)
            {
                return NotFound("News does not exist.");
            }

            return Ok(news.ToNewsDTO());
        }

        [HttpPost]
        public async Task<ActionResult<NewsDTO>> Create(CreateNewsDTO createNewsDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdNews = await _newsRepo.CreateAsync(createNewsDTO);

            return CreatedAtAction(nameof(GetById), new { id = createdNews.Id }, createdNews.ToNewsDTO());
        }

        [HttpPut("{id:long}")]
        public async Task<ActionResult<NewsDTO>> Update([FromRoute] long id, UpdateNewsDTO updateNewsDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var updatedNews = await _newsRepo.UpdateAsync(id, updateNewsDTO);
            if (updatedNews == null)
            {
                return NotFound("News does not exist.");
            }

            return Ok(updatedNews.ToNewsDTO());
        }

        [HttpDelete("{id:long}")]
        public async Task<IActionResult> Delete([FromRoute] long id)
        {
            var deletedNews = await _newsRepo.DeleteAsync(id);

            if (deletedNews == null)
            {
                return NotFound("News does not exist.");
            }

            return NoContent();
        }

    }
}