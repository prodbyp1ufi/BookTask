using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskBookAPI.Models.Blanks;
using TaskBookAPI.Models.DB;
using TaskBookAPI.Models.ViewModels;

namespace TaskBookAPI.Services.Interfaces
{
    public interface IBooksService
    {
        public List<BookViewModel> GetBooks();
        public Task AddBook(BookBlank bookBlank);
        public Task EditBook(BookBlank bookBlank);
        public Task RemoveBooks(Int32[] ids);
    }
}

