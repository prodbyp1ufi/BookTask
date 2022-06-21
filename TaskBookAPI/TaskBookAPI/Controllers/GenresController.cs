using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskBookAPI.Services.Interfaces;

namespace TaskBookAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class GenresController : ControllerBase
    {
        private readonly IGenresService _genresService;

        public GenresController(IGenresService genresService)
        {
            _genresService = genresService;
        }

        [HttpGet]
        [Route("getgenres")]
        public IActionResult GetGenres()
        {
            try
            {
                return new OkObjectResult(_genresService.GetGenres());
            }
            catch(Exception ex)
            {
                return new ConflictObjectResult(ex.Message);
            }
        }
    }
}