using H3LibraryProject.API.DTOs;
using H3LibraryProject.Repositories.Database;
using H3LibraryProject.Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H3LibraryProject.Services.Services
{
    public interface ILoanService
    {
        Task<List<LoanResponse>> GetAllLoans();
        Task<LoanResponse> GetLoanById(int id);
        Task<LoanResponse> CreateLoan(LoanRequest request);
        Task<LoanResponse> UpdateLoan(int id, LoanRequest request);
        Task<LoanResponse> DeleteLoan(int id);
    }

        public class LoanService
    {
            private readonly ILoanRepository _repository;

            public LoanService(ILoanRepository repository)
            {
                _repository = repository;
            }
            public async Task<LoanResponse> CreateLoan(LoanRequest request)
            {
                Loan newLoan = MapLoanRequestToLoan(request);
                newLoan = await _repository.InsertNewLoan(newLoan);

                if (newLoan != null)
                {
                    return MapLoanToLoanResponse(newLoan);

                }
                return null;
            }

            public async Task<LoanResponse> DeleteLoan(int id)
            {
                Loan deletedLoan = await _repository.DeleteLoan(id);
                if (deletedLoan != null)
                {
                    return MapLoanToLoanResponse(deletedLoan);
                }
                return null;
            }

            public async Task<List<LoanResponse>> GetAllLoans()
            {
                List<Loan> loans = await _repository.SelectAllLoans();
                return loans.Select(loan => MapLoanToLoanResponse(loan)).ToList();
            }

            public async Task<LoanResponse> GetLoanById(int id)
            {
                Loan loan = await _repository.SelectLoanById(id);
                if (loan != null)
                {
                    return MapLoanToLoanResponse(loan);
                }
                return null;
            }

            public async Task<LoanResponse> UpdateLoan(int id, LoanRequest request)
            {
                Loan updateLoan = MapLoanRequestToLoan(request);
                updateLoan = await _repository.UpdateExistingLoan(id, updateLoan);

                if (updateLoan != null)
                {
                    return MapLoanToLoanResponse(updateLoan);
                }
                return null;
            }

            private Loan MapLoanRequestToLoan(LoanRequest request)
            {
                return new()
                {
                    LoanerId = request.LoanerId,
                    MaterialId = request.MaterialId,
                    LoanDate = request.LoanDate,
                    ReturnDate = request.ReturnDate
                };
            }

            private LoanResponse MapLoanToLoanResponse(Loan loan)
            {
            if (loan != null)
            {

                return new();
            }
            return null;
                //return new()
                //{
                //    LoanId = loan.LoanId,
                //    Name = loan.Name,
                //    LeasePeriod = loan.LeasePeriod,
                //    Titles = loan.Titles != null ? loan.Titles.Select(t => new LoanTitleResponse
                //    {
                //        TitleId = t.TitleId,
                //        Name = t.Name,
                //        // Language needs a solution to be added.
                //        RYear = t.RYear,
                //        Pages = t.Pages,
                //        PublisherId = t.PublisherId,
                //        LoanId = t.LoanId
                //    }).ToList() : null
                //};

            }
        }
}
