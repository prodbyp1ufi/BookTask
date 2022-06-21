using System;
using TaskBookAPI.Models.DB;

namespace TaskBookAPI.Models.ViewModels
{
    public class GenreViewModel
    {
        public Int32 Id { get; set; }
        public string Name { get; set; }

        public GenreViewModel(Genre genreDB)
        {
            Id = genreDB.Id;
            Name = genreDB.Name;
        }
    }
}