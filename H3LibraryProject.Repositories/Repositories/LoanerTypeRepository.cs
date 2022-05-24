using H3LibraryProject.Repositories.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H3LibraryProject.Repositories.Repositories
{
    public interface ILoanerTypeRepository
    {
        Task<List<LoanerType>> GetAllLoanerTypes();
        Task<LoanerType> GetLoanerTypeById(int id);
        Task<LoanerType> CreateLoanerType(LoanerType newLoanerType);
        Task<LoanerType> UpdateLoanerType(int id,LoanerType newLoanerType);
        Task<LoanerType> DeleteLoanerType(int id);
    }
    public class LoanerTypeRepository : ILoanerTypeRepository
    {
        private readonly LibraryContext _context;

        public LoanerTypeRepository(LibraryContext context)
        {
            _context = context;
        }

        public async Task<List<LoanerType>> GetAllLoanerTypes()
        {
            return await _context.LoanerTypes.ToListAsync();
        }

        public async Task<LoanerType> GetLoanerTypeById(int id)
        {
            return await _context.LoanerTypes.FirstOrDefaultAsync(loanerType => loanerType.LoanerTypeId == id);
        }

        public async Task<LoanerType> CreateLoanerType(LoanerType newLoanerType)
        {
            _context.LoanerTypes.Add(newLoanerType);
            await _context.SaveChangesAsync();
            return newLoanerType;
        }

        public async Task<LoanerType> UpdateLoanerType(int id, LoanerType newLoanerType)
        {
            LoanerType updatedLoanerType = await _context.LoanerTypes.FirstOrDefaultAsync(loanerType => loanerType.LoanerTypeId == id);
            if (updatedLoanerType != null)
            {
                updatedLoanerType.Name = newLoanerType.Name;
                await _context.SaveChangesAsync();
            }
            return updatedLoanerType;
        }

        public async Task<LoanerType> DeleteLoanerType(int id)
        {
            LoanerType deletedLoanerType = await _context.LoanerTypes.FirstOrDefaultAsync(loanerTypeObj => loanerTypeObj.LoanerTypeId == id);
            if (deletedLoanerType != null)
            {
                _context.LoanerTypes.Remove(deletedLoanerType);
                await _context.SaveChangesAsync();
            }
            return deletedLoanerType;
        }
    }
}
