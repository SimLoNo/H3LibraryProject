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
    public interface IAuthorRepository
    {
        Task<Author> CreateAuthor(Author author);
        Task<List<Author>> GetAllAuthors(); //Vi kalder den "select" og ikke "get" da det er SQL-relateret
        Task<Author> GetAuthorById(int authorId);
        Task<List<Author>> GetAuthorsByNationality(int nationalityId);        
        Task<Author> UpdateExistingAuthor(int authorId, Author author);
        Task<Author> DeleteAuthor(int authorId); //jeg har på et tidspunkt kaldt den DeleteAuthorById: måske vigtigt
    }
    public class AuthorRepository : IAuthorRepository
    {
        private readonly LibraryContext _context;

        public AuthorRepository(LibraryContext context)
        {
            _context = context;
        }

        //CREATE
        public async Task<Author> CreateAuthor(Author author)
        {
            // fjerne de medsendte Titler som kun indeholder id, så der kan indsættet de rigtige Titler.
            foreach (Title title in author.Titles.ToList())
            {
                Title newTitle = _context.Title.First(t => t.TitleId == title.TitleId);
                if (newTitle != null)
                {
                    author.Titles.Remove(title);
                    author.Titles.Add(newTitle);
                }
            }
           
            
            _context.Author.Add(author); //Denne indeholder ikke en ID

            Console.WriteLine();

            await _context.SaveChangesAsync();
            return author; //Denne indeholder en ID
        }

        //READ
        public async Task<List<Author>> GetAllAuthors()
        {
            return await _context.Author
                .Include(a => a.Titles) //hahahah det virker slet ikke fml //19.05.22 - nu virker det.
                .ToListAsync();
        }

        public async Task<Author> GetAuthorById(int authorId)
        {
            return await _context.Author
                .Include(a => a.Titles)
                .FirstOrDefaultAsync(author => author.AuthorId == authorId);
        }

        public async Task<List<Author>> GetAuthorsByNationality(int nationalityId)
        {
            return await _context.Author
                .Include(a => a.Titles)
                .Where(author => author.NationalityId == nationalityId)
                .ToListAsync();
        }

        //UPDATE
        public async Task<Author> UpdateExistingAuthor(int authorId, Author author)
        {
            Author updateAuthor = await _context.Author
                .Include(t => t.Titles)
                .FirstOrDefaultAsync(author => author.AuthorId == authorId);
            if (updateAuthor != null)
            {
                updateAuthor.FName = author.FName;
                updateAuthor.MName = author.MName;
                updateAuthor.LName = author.LName;
                updateAuthor.BYear = author.BYear;
                updateAuthor.DYear = author.DYear;
                updateAuthor.NationalityId = author.NationalityId;

                // Køre igennem de titler der er sent med fra frontend, og kigger på om de hver især er tilføjet til forfatteren i databasen, og tilføjer dem hvis de ikke er
                foreach (Title sentTitle in author.Titles)
                {
                    if (updateAuthor.Titles.Exists(t => t.TitleId == sentTitle.TitleId) == false)
                    {
                        Title newTitle = _context.Title.First(t => t.TitleId == sentTitle.TitleId);
                        if (newTitle != null)
                        {
                            updateAuthor.Titles.Add(newTitle);
                        }
                    }
                }

                // Kigger alle de tilknyttede titler igennem der er i databasen, og hvis de ikke er i den tilsendte request, bliver forbindelsen fjernet i databasen.
                if (updateAuthor.Titles.Count > 0)
                {
                    foreach (Title existingTitle in updateAuthor.Titles.ToList())
                    {
                        if (author.Titles.Exists(t => t.TitleId == existingTitle.TitleId) == false)
                        {
                            updateAuthor.Titles.Remove(existingTitle);

                        }
                    }
                }
                await _context.SaveChangesAsync();
            }
            return updateAuthor;
        }

        //DELETE
        public async Task<Author> DeleteAuthor(int authorId)
        {
            Author deleteAuthor = await _context.Author
                .FirstOrDefaultAsync(author => author.AuthorId == authorId);
            if (deleteAuthor != null)
            {
                _context.Remove(deleteAuthor);
                await _context.SaveChangesAsync();
            }
            return deleteAuthor;
            //Virker ulogisk at man returnerer en author, man lige har slettet.
            //det gør vi dog heller ikke rigtig.
        }

        public async Task<Author> DeleteAuthorById(int authorId)
        {
            Author deleteAuthor = await _context.Author.FirstOrDefaultAsync(author => author.AuthorId == authorId);
            if (deleteAuthor != null)
            {
                _context.Author.Remove(deleteAuthor);
                await _context.SaveChangesAsync();
            }
            return deleteAuthor;
        }
    }
}