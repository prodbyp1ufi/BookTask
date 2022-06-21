using System;
using TaskBookAPI.Models.DB;

namespace TaskBookAPI.Models.ViewModels
{
    public class AuthorViewModel
    {
        public Int32 Id { get; set; }
        public string Name { get; set; }

        public AuthorViewModel(Author authorDB)
        {
            Id = authorDB.Id;
            Name = authorDB.Lastname + " " + authorDB.Firstname + " " + authorDB.Middlename;
        }
    }
}