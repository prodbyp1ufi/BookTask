using System.Collections.Generic;
using TaskBookAPI.Models.DB;

namespace TaskBookAPI.Repositories.Interfaces
{
    public interface IGenresRepository
    {
        public List<Genre> GetGenres();
    }
}