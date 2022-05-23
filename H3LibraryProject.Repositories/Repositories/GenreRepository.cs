using H3LibraryProject.Repositories.Database;
using H3LibraryProject.Repositories.Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H3LibraryProject.Repositories.Repositories
{
    public interface IGenreRepository
    {
        Task<Genre> InsertNewAuthor(Genre genre);
        Task<List<Genre>> SelectAllGenres(); //Vi kalder den "select" og ikke "get" da det er SQL-relateret
        Task<Genre> SelectGenreById(int authorId);
        Task<Genre> UpdateExistingGenre(int authorId, Genre author);
        Task<Genre> DeleteGenre(int authorId);
    }
    public class GenreRepository
    {
        private readonly LibraryContext _context;

        public GenreRepository(LibraryContext context)
        {
            _context = context;
        }

        public class genreRepository : IGenreRepository
        {
            private readonly LibraryContext _context;

            public genreRepository(LibraryContext context)
            {
                _context = context;
            }



            //CREATE
            public async Task<Genre> InsertNewGenre(Genre genre)
            {
                _context.Genre.Add(genre);
                await _context.SaveChangesAsync();
                return genre;
            }


            public async Task<List<Genre>> IGenreRepository.SelectAllGenres()
            {
                return await _context.Genre
                    .Include(b => b.Name)
                    .OrderBy(b => b.Name)
                    .ToListAsync();
            }

            public async Task<Genre> IGenreRepository.SelectGenreById(int genreId)
            {
                return await _context.Genre
                    .FirstOrDefaultAsync(genre => genre.GenreId == genreId);
            }            

            public async Task<Genre> IGenreRepository.UpdateExistingGenre(int genreId, Genre genre)
            {
                Genre updategenre = await _context.Genre
                    .FirstOrDefaultAsync(genre => genre.GenreId == genreId);
                if (updategenre != null)
                {
                    updategenre.GenreId = genre.GenreId;
                    updategenre.Name = genre.Name;
                    updategenre.LeasePeriod = genre.LeasePeriod;
                    await _context.SaveChangesAsync();
                }
                return updategenre;
            }

            public async Task<Genre> IGenreRepository.DeleteGenre(int genreId)
            {
                Genre deletegenre = await _context.Genre.FirstOrDefaultAsync(genre => genre.GenreId == genreId);
                if (deletegenre != null)
                {
                    _context.Genre.Remove(deletegenre);
                    await _context.SaveChangesAsync();
                }
                return deletegenre;
            }
        }
    }
}
