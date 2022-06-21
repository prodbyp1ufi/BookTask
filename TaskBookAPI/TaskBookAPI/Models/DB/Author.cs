using System.Collections.Generic;

namespace TaskBookAPI.Models.DB
{
    public partial class Author
    {
        public Author()
        {
            Books = new HashSet<Book>();
        }

        public int Id { get; set; }
        public string Firstname { get; set; } = null!;
        public string Lastname { get; set; } = null!;
        public string? Middlename { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
