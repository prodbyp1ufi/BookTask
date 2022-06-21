namespace TaskBookAPI.Models.DB
{
    public partial class Book
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Year { get; set; }
        public int Authorid { get; set; }
        public int Genreid { get; set; }

        public virtual Author Author { get; set; } = null!;
        public virtual Genre Genre { get; set; } = null!;
    }
}
