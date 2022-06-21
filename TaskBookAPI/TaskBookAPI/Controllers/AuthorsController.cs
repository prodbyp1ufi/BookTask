using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskBookAPI.Services.Interfaces;

namespace TaskBookAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class AuthorsController: ControllerBase
    {
        private readonly IAuthorsService _authorsService;

        public AuthorsController(IAuthorsService authorsService)
        {
            _authorsService = authorsService;
        }

        [HttpGet]
        [Route("getauthors")]
        public IActionResult GetAuthors()
        {
            try
            {
                return new OkObjectResult(_authorsService.GetAuthors());
            }
            catch(Exception ex)
            {
                return new ConflictObjectResult(ex.Message);
            }
        }
    }
}