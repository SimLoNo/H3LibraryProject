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
        Task<List<Title>> SelectAllTitles(); //Vi kalder den "select" og ikke "get" da det er SQL-relateret
        Task<List<Title>> SelectTitlesByAuthorId(int authorId);
        Task<List<Title>> SelectTitlesByLanguageId(int LanguageId);
        Task<Title> SelectTitleById(int titleId);
        Task<Title> InsertNewTitle(Title title);
        Task<Title> DeleteTitle(int titleId); //jeg har på et tidspunkt kaldt den DeleteTitleById: måske vigtigt
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
            _context.Title.Add(title); //Denne indeholder ikke en ID
            await _context.SaveChangesAsync();
            return title; 
        }

        //READ
        public async Task<List<Title>> SelectAllTitles()
        {
            return await _context.Title
                .Include(b => b.Name) //bruger Linq
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

        //UPDATE
        public async Task<Title> UpdateExistingTitle(int titleId, Title title)
        {
            Title updatetitle = await _context.Title
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

        public async Task<Title> DeletetitleById(int titleId)
        {
            Title deletetitle = await _context.Title.FirstOrDefaultAsync(title => title.TitleId == titleId);
            if (deletetitle != null)
            {
                _context.Title.Remove(deletetitle);
                await _context.SaveChangesAsync();
            }
            return deletetitle;
        }
    }
}
