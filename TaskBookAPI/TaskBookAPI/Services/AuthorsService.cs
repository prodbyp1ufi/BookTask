using System.Collections.Generic;
using TaskBookAPI.Models.DB;
using TaskBookAPI.Models.ViewModels;
using TaskBookAPI.Repositories.Interfaces;
using TaskBookAPI.Services.Interfaces;

namespace TaskBookAPI.Services
{
    public class AuthorsService : IAuthorsService
    {
        private readonly IAuthorsRepository _authorsRepository;

        public AuthorsService(IAuthorsRepository authorsRepository)
        {
            _authorsRepository = authorsRepository;
        }
        public List<AuthorViewModel> GetAuthors()
        {
            List<Author> authors = _authorsRepository.GetAuthors();
            return authors.ConvertAll(authorDB => new AuthorViewModel(authorDB));
        }
    }
}