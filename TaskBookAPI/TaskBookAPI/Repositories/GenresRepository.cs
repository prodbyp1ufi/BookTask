using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TaskBookAPI.Models.DB;
using TaskBookAPI.Repositories.Interfaces;

namespace TaskBookAPI.Repositories
{
    public class GenresRepository : IGenresRepository
    {
        private readonly BooksDbContext _context;

        public GenresRepository(BooksDbContext context)
        {
            _context = context;
        }
        
        public List<Genre> GetGenres()
        {
            return _context.Genres.AsNoTracking().ToList();
        }
    }
}