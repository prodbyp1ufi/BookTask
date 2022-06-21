using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskBookAPI.Models.DB;
using TaskBookAPI.Repositories.Interfaces;

namespace TaskBookAPI.Repositories
{
    public class BookRepositroy : IBooksRepository
    {
        private readonly BooksDbContext _context;

        public BookRepositroy(BooksDbContext context)
        {
            _context = context;
        }
        public List<Book> GetBooks()
        {
            return  _context.Books.Include(book=> book.Author).Include(book=>book.Genre).OrderBy(book=>book.Id).AsNoTracking().ToList();
        }

        public async Task AddBook(Book bookDB)
        {
            await _context.Books.AddAsync(bookDB);
            await _context.SaveChangesAsync();
        }

        public async Task EditBook(Book bookDB)
        {
            Book currentBook = await _context.Books.FirstOrDefaultAsync(book => book.Id == bookDB.Id);
            currentBook.Authorid = bookDB.Authorid;
            currentBook.Genreid = bookDB.Genreid;
            currentBook.Year = bookDB.Year;
            currentBook.Name = bookDB.Name;
            await _context.SaveChangesAsync();
        }

        public async Task RemoveBooks(int[] ids)
        {
            List<Book> removedBooks = _context.Books.Where(book => ids.Contains(book.Id)).ToList();
            _context.Books.RemoveRange(removedBooks);
            await _context.SaveChangesAsync();
        }
    }
}

