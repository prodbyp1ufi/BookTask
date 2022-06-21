using System.Collections.Generic;
using TaskBookAPI.Models.ViewModels;

namespace TaskBookAPI.Services.Interfaces
{
    public interface IGenresService
    {
        public List<GenreViewModel> GetGenres();
    }
}