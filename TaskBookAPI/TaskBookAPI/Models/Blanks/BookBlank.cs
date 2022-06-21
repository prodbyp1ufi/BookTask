using System;

namespace TaskBookAPI.Models.Blanks
{
    public class BookBlank
    {
        public Int32 Id { get; set; }
        public string Name { get; set; }
        public Int32 AuthorId { get; set; }
        public Int32 GenreId { get; set; }
        public Int32 Year { get; set; }
    }
}

