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
    public interface ITitleRepository
    {
        Task<List<Title>> SelectAllTitles(); 
        Task<List<Title>> SelectTitlesByAuthorId(int authorId);
        Task<List<Title>> SelectTitlesByLanguageId(int LanguageId);
        Task<List<Title>> SelectTitlesByGenreId(int LanguageId);
        Task<Title> SelectTitleById(int titleId);
        Task<Title> InsertNewTitle(Title title);
        Task<Title> DeleteTitle(int titleId);
        Task<Title> UpdateExistingTitle(int titleId, Title title);

    }

    public class TitleRepository : ITitleRepository
    {
        private readonly LibraryContext _context;

        public TitleRepository(LibraryContext context)
        {
            _context = context;
        }

        //CREATE
        public async Task<Title> InsertNewTitle(Title title)
        {
            Author author = _context.Author.Single(a => a.AuthorId == title.AuthorId);
            title.Authors.Add(author);
            _context.Title.Add(title); //Denne indeholder ikke en ID
            //title.Authors.Add(author);
            await _context.SaveChangesAsync();
            return title; 
        }

        //READ
        public async Task<List<Title>> SelectAllTitles()
        {
            return await _context.Title
                .Include(b => b.Authors) //bruger Linq. Name er ikke en FK.
                .OrderBy(b => b.LanguageId)
                .ThenBy(b => b.AuthorId)
                .ThenBy(b => b.RYear)
                .ToListAsync();

        }
        public async Task<Title> SelectTitleById(int titleId)
        {
            return await _context.Title
                .FirstOrDefaultAsync(title => title.TitleId == titleId);
        }

        public async Task<List<Title>> SelectTitlesByAuthorId(int authorId)
        {
            return await _context.Title
                .Include(b => b.AuthorId == authorId) //Måske virker det her?
                .OrderBy(b => b.RYear)
                .ThenBy(b => b.Name)                
                .ToListAsync();
        }
        public async Task<List<Title>> SelectTitlesByLanguageId(int languageId)
        {
            return await _context.Title
                .Include(b => b.LanguageId == languageId) //Måske virker det her?
                .OrderBy(b => b.RYear)
                .ThenBy(b => b.Name)
                //.FirstOrDefaultAsync(title => title.AuthorId == authorId) // virker ikke. Hvad tænkte jeg egentlig på?
                .ToListAsync();
        }
        public async Task<List<Title>> SelectTitlesByGenreId(int genreId)
        {
            return await _context.Title
                .Include(b => b.GenreId == genreId) //Eksperimentel
                .OrderBy(b => b.RYear)
                .ThenBy(b => b.Name)
                .ToListAsync();
        }

        //UPDATE
        public async Task<Title> UpdateExistingTitle(int titleId, Title title)
        {
            Title updatetitle = await _context.Title
                .Include(a => a.Authors)
                .FirstOrDefaultAsync(title => title.TitleId == titleId);
            if (updatetitle != null)
            {
                updatetitle.AuthorId = title.AuthorId;
                updatetitle.LanguageId = title.LanguageId;
                updatetitle.PublisherId = title.PublisherId;
                updatetitle.Name = title.Name;
                updatetitle.Pages = title.Pages;
                updatetitle.RYear = title.RYear;
                updatetitle.GenreId = title.GenreId;

                // Køre igennem de forfater der er sent med fra frontend, og kigger på om de hver især er tilføjet til titlen i databasen, og tilføjer dem hvis de ikke er
                foreach (Author sentAuthor in title.Authors)
                {
                    if (updatetitle.Authors.Exists(a => a.AuthorId == sentAuthor.AuthorId) == false)
                    {
                        Author newAuthor = _context.Author.First(a => a.AuthorId == sentAuthor.AuthorId);
                        if (newAuthor != null)
                        {
                            updatetitle.Authors.Add(newAuthor);
                        }
                    }
                }

                // Kigger alle de tilknyttede forfattere igennem der er i databasen, og hvis de ikke er i den tilsendte request, bliver forbindelsen fjernet i databasen.
                if (updatetitle.Authors.Count > 0)
                {
                    foreach (Author existingAuthor in updatetitle.Authors.ToList())
                    {
                        if (title.Authors.Exists(a => a.AuthorId == existingAuthor.AuthorId) == false)
                        {
                            updatetitle.Authors.Remove(existingAuthor);
                            
                        }
                    }
                }

                await _context.SaveChangesAsync();
            }
            return updatetitle;
        }

        //DELETE
        public async Task<Title> DeleteTitle(int titleId)
        {
            Title deletetitle = await _context.Title
                .FirstOrDefaultAsync(title => title.TitleId == titleId);
            if (deletetitle != null)
            {
                _context.Remove(deletetitle);
                await _context.SaveChangesAsync();
            }
            return deletetitle;
            //Virker ulogisk at man returnerer en title, man lige har slettet.
            //det gør vi dog heller ikke rigtig.
        }

        
    }
}
