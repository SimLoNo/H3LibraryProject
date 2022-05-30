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
        Task<Author> InsertNewAuthor(Author author);
        Task<List<Author>> SelectAllAuthors(); //Vi kalder den "select" og ikke "get" da det er SQL-relateret
        Task<Author> SelectAuthorById(int authorId);
        Task<Author> SelectAuthorsByNationality(int nationalityId);        
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
        public async Task<Author> InsertNewAuthor(Author author)
        {
            _context.Author.Add(author); //Denne indeholder ikke en ID
            await _context.SaveChangesAsync();
            return author; //Denne indeholder en ID
        }

        //READ
        public async Task<List<Author>> SelectAllAuthors()
        {
            return await _context.Author
                .Include(a => a.Titles) //hahahah det virker slet ikke fml //19.05.22 - nu virker det.
                .ToListAsync();
        }

        public async Task<Author> SelectAuthorById(int authorId)
        {
            return await _context.Author
                .Include(a => a.Titles)
                .FirstOrDefaultAsync(author => author.AuthorId == authorId);
        }

        public async Task<Author> SelectAuthorsByNationality(int nationalityId)
        {
            return await _context.Author
                .Include(a => a.Titles)
                .FirstOrDefaultAsync(author => author.AuthorId == nationalityId);
        }

        //UPDATE
        public async Task<Author> UpdateExistingAuthor(int authorId, Author author)
        {
            Author updateAuthor = await _context.Author
                .FirstOrDefaultAsync(author => author.AuthorId == authorId);
            if (updateAuthor != null)
            {
                updateAuthor.FName = author.FName;
                updateAuthor.MName = author.MName;
                updateAuthor.LName = author.LName;
                updateAuthor.BYear = author.BYear;
                updateAuthor.DYear = author.DYear;
                updateAuthor.NationalityId = author.NationalityId;
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