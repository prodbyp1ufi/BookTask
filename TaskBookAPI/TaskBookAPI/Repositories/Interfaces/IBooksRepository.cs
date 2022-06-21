using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskBookAPI.Models.DB;

namespace TaskBookAPI.Repositories.Interfaces
{
    public interface IBooksRepository
    {
        public List<Book> GetBooks();
        public Task AddBook(Book bookDB);
        public Task EditBook(Book bookDB);
        public Task RemoveBooks(Int32[] ids);
    }
}

