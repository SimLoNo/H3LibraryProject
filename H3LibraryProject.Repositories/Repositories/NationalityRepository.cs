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
    public interface INationalityRepository
    {
        Task<Nationality> InsertNewNationality(Nationality nationality);
        Task<List<Nationality>> SelectAllNationalities(); //Vi kalder den "select" og ikke "get" da det er SQL-relateret
        Task<Nationality> SelectNationalityById(int nationality);
        Task<Nationality> UpdateExistingNationality(int nationalityId, Nationality nationality);
        Task<Nationality> DeleteNationality(int nationalityId);
    }
    public class NationalityRepository : INationalityRepository
    {
        private readonly LibraryContext _context;

        public NationalityRepository(LibraryContext context)
        {
            _context = context;
        }

        
            //CREATE
            public async Task<Nationality> InsertNewNationality(Nationality nationality)
            {
                _context.Nationality.Add(nationality);
                await _context.SaveChangesAsync();
                return nationality;
            }


            public async Task<List<Nationality>> SelectAllNationalities()
            {
                return await _context.Nationality
                    .Include(b => b.Name)
                    .OrderBy(b => b.Name)
                    .ToListAsync();
            }

            public async Task<Nationality> SelectNationalityById(int nationalityId)
            {
                return await _context.Nationality
                    .FirstOrDefaultAsync(nationality => nationality.NationalityId == nationalityId);
            }

            public async Task<Nationality> UpdateExistingNationality(int nationalityId, Nationality nationality)
            {
            Nationality updateNationality = await _context.Nationality
                    .FirstOrDefaultAsync(nationality => nationality.NationalityId == nationalityId);
                if (updateNationality != null)
                {
                    updateNationality.Name = nationality.Name;
                    await _context.SaveChangesAsync();
                }
                return updateNationality;
            }

            public async Task<Nationality> DeleteNationality(int nationalityId)
            {
                Nationality deleteNationality = await _context.Nationality.FirstOrDefaultAsync(genre => genre.NationalityId == nationalityId);
                if (deleteNationality != null)
                {
                    _context.Nationality.Remove(deleteNationality);
                    await _context.SaveChangesAsync();
                }
                return deleteNationality;
            }
        
    }
}
