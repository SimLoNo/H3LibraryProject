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
    public interface ILanguageRepository
    {
        Task<Language> InsertNewLanguage(Language language);
        Task<List<Language>> SelectAllLanguages();    
        Task<Language> SelectLanguageById(int languageId);
        Task<Language> UpdateExistingLanguage(int languageId, Language language);
        Task<Language> DeleteLanguage(int languageId);
        Task<Language> CreateLanguage(Language newLanguage);
    }
    public class LanguageRepository
    {
        private readonly LibraryContext _context;

        public LanguageRepository(LibraryContext context)
        {
            _context = context;
        }

        //CREATE
        public async Task<Language> InsertNewLanguage(Language material)
        {
            _context.Language.Add(material);
            await _context.SaveChangesAsync();
            return material;
        }


        public async Task<List<Language>> SelectAllLanguages()
        {
            return await _context.Language
                .Include(b => b.Name)
                .ToListAsync();
        }

        public async Task<Language> SelectLanguageById(int languageId)
        {
            return await _context.Language
                .FirstOrDefaultAsync(language => language.LanguageId == languageId);
        }

        //public async Task<Language> ILanguageRepository.SelectLanguageByTitleId(int titleId) //Måske vil vi kunne finde det på noget andet... RS
        //{
        //    return await _context.Language
        //        .FirstOrDefaultAsync(material => material.TitleId == titleId);
        //}

        public async Task<Language> UpdateExistingLanguage(int languageId, Language language)
        {
            Language updatelanguage = await _context.Language
                .FirstOrDefaultAsync(language => language.LanguageId == languageId);
            if (updatelanguage != null)
            {
                updatelanguage.Name = language.Name;
                await _context.SaveChangesAsync();
            }
            return updatelanguage;
        }

        public async Task<Language> DeleteLanguage(int languageId)
        {
            Language deletelanguage = await _context.Language.FirstOrDefaultAsync(language => language.LanguageId == languageId);
            if (deletelanguage != null)
            {
                _context.Language.Remove(deletelanguage);
                await _context.SaveChangesAsync();
            }
            return deletelanguage;
        }
    }
}

