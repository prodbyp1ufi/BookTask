using System.Collections.Generic;
using TaskBookAPI.Models.ViewModels;

namespace TaskBookAPI.Services.Interfaces
{
    public interface IAuthorsService
    {
        public List<AuthorViewModel> GetAuthors();
    }
}