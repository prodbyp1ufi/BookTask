using System.Collections.Generic;
using TaskBookAPI.Models.DB;

namespace TaskBookAPI.Repositories.Interfaces
{
    public interface IAuthorsRepository
    {
        public List<Author> GetAuthors();
    }
}