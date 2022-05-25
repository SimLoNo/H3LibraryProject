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
                .Include(b => b.LoanerId)
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
