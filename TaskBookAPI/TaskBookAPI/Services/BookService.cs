using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskBookAPI.Models.Blanks;
using TaskBookAPI.Models.DB;
using TaskBookAPI.Models.ViewModels;
using TaskBookAPI.Repositories.Interfaces;
using TaskBookAPI.Services.Interfaces;

namespace TaskBookAPI.Services
{
    public class BookService : IBooksService
    {
        private readonly IBooksRepository _bookRepository;

        public BookService(IBooksRepository booksRepository)
        {
            _bookRepository = booksRepository;
        }
        public List<BookViewModel> GetBooks()
        {
            List<Book> books =  _bookRepository.GetBooks();
            return books.ConvertAll(bookDB=> new BookViewModel(bookDB));
        }

        public async Task AddBook(BookBlank bookBlank)
        {
            Book book = new Book()
            {
                Id = bookBlank.Id,
                Authorid = bookBlank.AuthorId,
                Genreid = bookBlank.GenreId,
                Year = bookBlank.Year,
                Name = bookBlank.Name
            };
            await _bookRepository.AddBook(book);
        }

        public async Task EditBook(BookBlank bookBlank)
        {
            Book book = new Book()
            {
                Id = bookBlank.Id,
                Authorid = bookBlank.AuthorId,
                Genreid = bookBlank.GenreId,
                Year = bookBlank.Year,
                Name = bookBlank.Name
            };
            await _bookRepository.EditBook(book);
        }

        public async Task RemoveBooks(int[] ids)
        {
            await _bookRepository.RemoveBooks(ids);
        }
    }
}

