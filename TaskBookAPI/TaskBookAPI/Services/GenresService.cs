using System.Collections.Generic;
using TaskBookAPI.Models.DB;
using TaskBookAPI.Models.ViewModels;
using TaskBookAPI.Repositories.Interfaces;
using TaskBookAPI.Services.Interfaces;

namespace TaskBookAPI.Services
{
    public class GenresService : IGenresService
    {
        private readonly IGenresRepository _genresRepository;

        public GenresService(IGenresRepository genresRepository)
        {
            _genresRepository = genresRepository;
        }
        public List<GenreViewModel> GetGenres()
        {
            List<Genre> genres = _genresRepository.GetGenres();
            return genres.ConvertAll(genreDB => new GenreViewModel(genreDB));
        }
    }
}