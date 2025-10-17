using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using server.Data;
using server.Services;

namespace server.Controllers
{

    [Route("service/igdb")]
    [ApiController]
    public class IGDBController : ControllerBase
    {
        private readonly IGDBService _igdbService;
        public IGDBController(IGDBService igdbService)
        {
            _igdbService = igdbService;
        }

        [HttpGet]
        public async Task<ActionResult<string?>> GetVideoGamesFromIGDB()
        {

            var content = await _igdbService.GetVideoGamesAsync();

            return Ok(content);
        }

    }
}