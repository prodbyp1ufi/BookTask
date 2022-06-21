using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskBookAPI.Models.Blanks;
using TaskBookAPI.Services.Interfaces;

namespace TaskBookAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBooksService _bookService;

        public BooksController(IBooksService booksService)
        {
            _bookService = booksService;
        }

        [HttpGet]
        [Route("getbooks")]
        public IActionResult GetBooks()
        {
            try
            {
                return new OkObjectResult(_bookService.GetBooks());
            }
            catch(Exception ex)
            {
                return new ConflictObjectResult(ex.Message);
            }
        }

        [HttpPost]
        [Route("addbook")]
        public async Task<IActionResult> AddBook([FromBody] BookBlank bookBlank)
        {
            try
            {
                await _bookService.AddBook(bookBlank);
                return new OkResult();
            }
            catch(Exception ex)
            {
                return new ConflictObjectResult(ex.Message);
            }
        }

        [HttpPost]
        [Route("editbook")]
        public async Task<IActionResult> EditBook([FromBody] BookBlank bookBlank)
        {
            try
            {
                await _bookService.EditBook(bookBlank);
                return new OkResult();
            }
            catch(Exception ex)
            {
                return new ConflictObjectResult(ex.Message);
            }
        }
        
        [HttpPost]
        [Route("removebooks")]
        public async Task<IActionResult> AddBook([FromBody] Int32[] ids)
        {
            try
            {
                await _bookService.RemoveBooks(ids);
                return new OkResult();
            }
            catch(Exception ex)
            {
                return new ConflictObjectResult(ex.Message);
            }
        }
    }
}

