using H3LibraryProject.Repositories.Database;
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
            _context.Loaners.Add(loaner);
            await _context.SaveChangesAsync();
            return loaner;
        }

        public async Task<Loaner> DeleteLoaner(int id)
        {
            Loaner deletedLoaner = await _context.Loaners.FirstOrDefaultAsync(loanerObj => loanerObj.LoanerId == id);
            if (deletedLoaner != null)
            {
                _context.Loaners.Remove(deletedLoaner);
                await _context.SaveChangesAsync();
            }
            return deletedLoaner;
        }

        public async Task<List<Loaner>> GetAllLoaners()
        {
            return await _context.Loaners.ToListAsync();
        }

        public async Task<Loaner> GetLoanerById(int id)
        {
            return await _context.Loaners.FirstOrDefaultAsync(loaner => loaner.LoanerId == id);

        }

        public async Task<List<Loaner>> GetLoanerByName(string loanerName)
        {
            return await _context.Loaners.Where(loanerObj => loanerObj.Name.Contains(loanerName)).ToListAsync();
        }

        public async Task<Loaner> UpdateLoaner(int id, Loaner loaner)
        {
            Loaner updatedLoaner = await _context.Loaners.FirstOrDefaultAsync(loaner => loaner.LoanerId== id);
            if (updatedLoaner != null)
            {
                updatedLoaner.Name = loaner.Name;
                updatedLoaner.LoanerTypeId = loaner.LoanerTypeId;
                await _context.SaveChangesAsync();
            }
            return updatedLoaner;
        }

        
    }
}
