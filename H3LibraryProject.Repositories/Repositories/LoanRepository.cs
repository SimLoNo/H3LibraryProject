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
                    .FirstOrDefaultAsync(loan => loan.LoanId == loanId);
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
        public async Task<Loan> CreateLoan(int materialId, int loanerId)
        {
            Material loanMaterial = await _context.Material
                .Include(m => m.Title).ThenInclude(t => t.Genre)
                .FirstOrDefaultAsync(materialObj => materialObj.MaterialId == materialId);
            Loaner loanLoaner = await _context.Loaner
                .FirstOrDefaultAsync(loanerObj => loanerObj.LoanerId == loanerId);

            Loan newLoan = new();
            if (loanMaterial != null && loanLoaner != null)
            {
                newLoan.LoanerLoaning = loanLoaner;
                newLoan.MaterialLoaned = loanMaterial;
                newLoan.LoanDate = DateTime.Today;
                newLoan.ReturnDate = DateTime.Today.AddDays(loanMaterial.Title.Genre.LeasePeriod);
                newLoan.IsReturned = false;
                _context.Loan.Add(newLoan);
                loanMaterial.Home = false;
                await _context.SaveChangesAsync();
            }
            return newLoan;
        }

        public async Task<Loan> ExtendLoan(int loanId)
        {

            Loan extendLoan = await _context.Loan
                .Include(l => l.MaterialLoaned).ThenInclude(m => m.Title).ThenInclude(t => t.Genre)
                .FirstOrDefaultAsync(l => l.LoanId == loanId);
            if (extendLoan != null)
            {
                extendLoan.ReturnDate = extendLoan.ReturnDate.AddDays(extendLoan.MaterialLoaned.Title.Genre.LeasePeriod);
                await _context.SaveChangesAsync();
            }
            return extendLoan;
        }
        public async Task<Loan> ReturnLoan(int loanId)
        {

            Loan returnLoan = await _context.Loan
                .Include(l => l.MaterialLoaned)
                .FirstOrDefaultAsync(l => l.LoanId == loanId);
            if (returnLoan != null)
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
