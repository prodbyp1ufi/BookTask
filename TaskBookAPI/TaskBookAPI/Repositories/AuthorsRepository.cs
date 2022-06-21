using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TaskBookAPI.Models.DB;
using TaskBookAPI.Repositories.Interfaces;

namespace TaskBookAPI.Repositories
{
    public class AuthorsRepository : IAuthorsRepository
    {
        private readonly BooksDbContext _context;

        public AuthorsRepository(BooksDbContext context)
        {
            _context = context;
        }

        public List<Author> GetAuthors()
        {
            return _context.Authors.AsNoTracking().ToList();
        }
    }
}