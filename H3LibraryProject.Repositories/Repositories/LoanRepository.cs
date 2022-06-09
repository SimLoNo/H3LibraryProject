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
    public interface ILoanRepository
    {
        Task<Loan> InsertNewLoan(Loan loan);
        Task<List<Loan>> SelectAllLoans(); //Vi kalder den "select" og ikke "get" da det er SQL-relateret
        Task<Loan> SelectLoanById(int loan);
        Task<List<Loan>> SelectAllLoansByLoanerId(int loanerId);
        Task<Loan> UpdateExistingLoan(int loanId, Loan loan);
        Task<Loan> ExtendLoan(int loanId);
        Task<Loan> CreateLoan(int materialId, int loanerId);
        Task<Loan> ReturnLoan(int loanId);
        Task<Loan> DeleteLoan(int loanId);
    }
    public class LoanRepository : ILoanRepository
    {
        private readonly LibraryContext _context;

        public LoanRepository(LibraryContext context)
        {
            _context = context;
        }

        

        public async Task<Loan> InsertNewLoan(Loan loan)
        {
            _context.Loan.Add(loan);
            await _context.SaveChangesAsync();
            return loan;
        }

        public async Task<List<Loan>> SelectAllLoans()
        {
            return await _context.Loan
                .Include(b => b.LoanerLoaning).ThenInclude(b => b.TypeOfLoaner)
                .Include(b => b.MaterialLoaned).ThenInclude(b => b.Title)
                .ToListAsync(); 
        }

        public async Task<Loan> SelectLoanById(int loanId)
        {
            return await _context.Loan
                .Include(b => b.LoanerLoaning).ThenInclude(b => b.TypeOfLoaner)
                .Include(b => b.MaterialLoaned).ThenInclude(b => b.Title)
                .FirstOrDefaultAsync(loan => loan.LoanId == loanId);
        }

        public async Task<List<Loan>> SelectAllLoansByLoanerId(int loanerId)
        {
            return await _context.Loan
                .Include(b => b.LoanerLoaning).ThenInclude(b => b.TypeOfLoaner)
                .Include(b => b.MaterialLoaned).ThenInclude(b => b.Title)
                .Where(l => l.LoanerId == loanerId)
                .ToListAsync();
        }

        public async Task<Loan> UpdateExistingLoan(int loanId, Loan loan)
        {
            Loan updateLoan = await _context.Loan
                    .FirstOrDefaultAsync(loan => loan.LoanId == loanId);
            if (updateLoan != null)
            {
                updateLoan.LoanerId = loan.LoanerId;
                updateLoan.MaterialId = loan.MaterialId;
                updateLoan.LoanDate = loan.LoanDate; //Det giver ikke mening at man kan ændre en udlånsdato - men nu har vi muligheden.
                updateLoan.ReturnDate = loan.ReturnDate;
                await _context.SaveChangesAsync();
            }
            return updateLoan;
        }
        public async Task<Loan> CreateLoan(int loanerId, int materialId)
        {
            Material loanMaterial = await _context.Material
                .Include(m => m.Title).ThenInclude(t => t.Genre)
                .FirstOrDefaultAsync(materialObj => materialObj.MaterialId == materialId);
            Loaner loanLoaner = await _context.Loaner
                .FirstOrDefaultAsync(loanerObj => loanerObj.LoanerId == loanerId);

            if (loanMaterial != null && loanLoaner != null && loanMaterial.Home == true)
            {
                Loan newLoan = new();
                newLoan.LoanerLoaning = loanLoaner;
                newLoan.MaterialLoaned = loanMaterial;
                newLoan.LoanDate = DateTime.Today;
                newLoan.ReturnDate = DateTime.Today.AddDays(loanMaterial.Title.Genre.LeasePeriod);
                newLoan.IsReturned = false;
                _context.Loan.Add(newLoan);
                loanMaterial.Home = false;
                await _context.SaveChangesAsync();
                return newLoan;
            }
            return null;
        }

        public async Task<Loan> ExtendLoan(int loanId)
        {

            Loan extendLoan = await _context.Loan
                .Include(l => l.MaterialLoaned).ThenInclude(m => m.Title).ThenInclude(t => t.Genre)
                .FirstOrDefaultAsync(l => l.LoanId == loanId);
            if (extendLoan != null && extendLoan.IsReturned == false)
            {
                if (extendLoan.ReturnDate < extendLoan.LoanDate.AddDays(extendLoan.MaterialLoaned.Title.Genre.LeasePeriod*2))
                {
                    extendLoan.ReturnDate = extendLoan.ReturnDate.AddDays(extendLoan.MaterialLoaned.Title.Genre.LeasePeriod);
                    await _context.SaveChangesAsync();
                }
            }
            return extendLoan;
        }
        public async Task<Loan> ReturnLoan(int loanId)
        {

            Loan returnLoan = await _context.Loan
                .Include(l => l.MaterialLoaned)
                .FirstOrDefaultAsync(l => l.LoanId == loanId);
            if (returnLoan != null && returnLoan.IsReturned == false)
            {
                returnLoan.IsReturned = true;
                returnLoan.MaterialLoaned.Home = true;
                await _context.SaveChangesAsync();
            }
            return returnLoan;
        }

        public async Task<Loan> DeleteLoan(int loanId)
        {
            Loan deleteLoan = await _context.Loan.FirstOrDefaultAsync(loan => loan.LoanId == loanId);
            if (deleteLoan != null)
            {
                _context.Loan.Remove(deleteLoan);
                await _context.SaveChangesAsync();
            }
            return deleteLoan;
        }
    }
}
