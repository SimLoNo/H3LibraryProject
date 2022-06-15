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
    public interface ILoanerRepository
    {
        Task<List<Loaner>> GetAllLoaners();
        Task<Loaner> GetLoanerById(int id);
        Task<List<Loaner>> GetLoanerByName(string loanerName);
        Task<Loaner> CreateLoaner(Loaner loaner);
        Task<Loaner> UpdateLoaner(int id, Loaner loaner);
        Task<Loaner> DeleteLoaner(int id);
        Task<Loaner> LoanerUserUpdate(Loaner updateLoaner, LoanerAuthenticator credentials);
    }
    public class LoanerRepository : ILoanerRepository
    {
        private readonly LibraryContext _context;

        public LoanerRepository(LibraryContext context)
        {
            _context = context;
        }
        public async Task<Loaner> CreateLoaner(Loaner loaner)
        {
            _context.Loaner.Add(loaner);
            await _context.SaveChangesAsync();
            return loaner;
        }

        public async Task<Loaner> DeleteLoaner(int id)
        {
            Loaner deletedLoaner = await _context.Loaner.Include(x => x.TypeOfLoaner).FirstOrDefaultAsync(loanerObj => loanerObj.LoanerId == id);
            if (deletedLoaner != null)
            {
                _context.Loaner.Remove(deletedLoaner);
                await _context.SaveChangesAsync();
            }
            return deletedLoaner;
        }

        public async Task<List<Loaner>> GetAllLoaners()
        {
            return await _context.Loaner.Include(loanerObj => loanerObj.TypeOfLoaner).ToListAsync();
        }

        public async Task<Loaner> GetLoanerById(int id)
        {
            return await _context.Loaner.Include(x => x.TypeOfLoaner).FirstOrDefaultAsync(loaner => loaner.LoanerId == id);

        }

        public async Task<List<Loaner>> GetLoanerByName(string loanerName)
        {
            return await _context.Loaner.Where(loanerObj => loanerObj.Name.Contains(loanerName)).ToListAsync();
        }

        public async Task<Loaner> UpdateLoaner(int id, Loaner loaner)
        {
            Loaner updatedLoaner = await _context.Loaner.Include(x => x.TypeOfLoaner).FirstOrDefaultAsync(loanerObj => loanerObj.LoanerId == id);
            if (updatedLoaner != null)
            {
                updatedLoaner.Name = loaner.Name;
                updatedLoaner.LoanerTypeId = loaner.LoanerTypeId;
                await _context.SaveChangesAsync();
            }
            return updatedLoaner;
        }

        public async Task<Loaner> LoanerUserUpdate(Loaner updateLoaner, LoanerAuthenticator credentials)
        {
            Loaner foundLoaner = await _context.Loaner.FirstOrDefaultAsync(l => l.Name == credentials.Name && l.Password == credentials.Password);
            if (foundLoaner != null)
            {
                if (updateLoaner.Name != "")
                {
                    foundLoaner.Name = updateLoaner.Name;
                }
                if (updateLoaner.LoanerTypeId != 0)
                {
                    foundLoaner.LoanerTypeId = updateLoaner.LoanerTypeId;
                }
                if (updateLoaner.Password != "")
                {
                    foundLoaner.Password = updateLoaner.Password;
                }
                await _context.SaveChangesAsync();
            }
            return foundLoaner;
        }


    }
}
