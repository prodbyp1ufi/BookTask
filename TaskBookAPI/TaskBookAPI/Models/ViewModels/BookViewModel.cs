using System;
using TaskBookAPI.Models.DB;

namespace TaskBookAPI.Models.ViewModels
{
    public class BookViewModel
    {
        public Int32 Id { get; set; }
        public String Name { get; set; }
        public String Author { get; set; }
        public Int32 Year { get; set; }
        public String Genre { get; set; }
        public Int32 AuthorId { get; set; }
        public Int32 GenreId { get; set; }

        public BookViewModel(Book bookDB)
        {
            Id = bookDB.Id;
            Name = bookDB.Name;
            Author = bookDB.Author.Lastname + " " + bookDB.Author.Firstname + " " + bookDB.Author.Middlename;
            Year = bookDB.Year;
            Genre = bookDB.Genre.Name;
            AuthorId = bookDB.Author.Id;
            GenreId = bookDB.Genre.Id;
        }
    }
}

