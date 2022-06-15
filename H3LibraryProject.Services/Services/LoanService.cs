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
        Task<List<LoanResponse>> GetAllLoans(int loanerId);
        Task<LoanResponse> GetLoanById(int id);
        Task<LoanResponse> CreateLoan(LoanRequest request);
        Task<LoanResponse> UpdateLoan(int id, LoanRequest request);
        Task<LoanResponse> DeleteLoan(int id);
        Task<LoanResponse> UserLoanChange(int loanerId, int materialId, int loanChange);
    }

        public class LoanService : ILoanService
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

            public async Task<List<LoanResponse>> GetAllLoans(int loanerId)
            {
                List<Loan> loans = new();
                if (loanerId > 0)
                {
                    loans = await _repository.SelectAllLoansByLoanerId(loanerId);
                }
                else
                {

                    loans = await _repository.SelectAllLoans();
                }
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

        public async Task<LoanResponse> UserLoanChange(int loanerId, int materialId, int loanChange)
        {
            Loan loanObject = new();
            if (loanChange == 1)
            {
                loanObject = await _repository.CreateLoan(loanerId,materialId);
            }
            else if (loanChange == 2)
            {
                loanObject = await _repository.ExtendLoan(loanerId);
            }
            else if (loanChange == 3)
            {
                
                loanObject = await _repository.ReturnLoan(loanerId);
            }
            if (loanObject != null)
            {
                return MapLoanToLoanResponse(loanObject);
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

            return new()
            {
                LoanId = loan.LoanId,
                LoanerId = loan.LoanerId,
                MaterialId=loan.MaterialId,
                LoanDate=loan.LoanDate,
                ReturnDate=loan.ReturnDate,
                IsReturned = loan.IsReturned,
                Loaner = loan.LoanerLoaning != null ? new LoanLoanerResponse{
                    LoanerId=loan.LoanerLoaning.LoanerId,
                    LoanerTypeId=loan.LoanerLoaning.LoanerTypeId,
                    Name=loan.LoanerLoaning.Name,
                    LoanerTypeName = loan.LoanerLoaning.TypeOfLoaner != null ? loan.LoanerLoaning.TypeOfLoaner.Name : null,
                } : null,
                Material = loan.MaterialLoaned != null ? new LoanMaterialResponse
                {
                    MaterialId=loan.MaterialLoaned.MaterialId,
                    TitleId=loan.MaterialLoaned.TitleId,
                    LocationId =loan.MaterialLoaned.LocationId,
                    TitleName = loan.MaterialLoaned.Title != null ? loan.MaterialLoaned.Title.Name : null
                } : null
            };

        }
        }
}
