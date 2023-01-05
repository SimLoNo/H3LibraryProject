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
    public interface ILoanerService
    {
        Task<List<LoanerResponse>> GetAllLoaners();
        Task<LoanerResponse> GetLoanerById(int id);
        Task<List<LoanerResponse>> GetLoanerByName(string name);
        Task<LoanerResponse> CreateLoaner(LoanerRequest request);
        Task<LoanerResponse> UpdateLoaner(int id, LoanerRequest request);
        Task<LoanerResponse> DeleteLoaner(int id);
    }
    public class LoanerService : ILoanerService
    {
        private readonly ILoanerRepository _repository;

        public LoanerService(ILoanerRepository repository)
        {
            _repository = repository;
        }
        public async Task<LoanerResponse> CreateLoaner(LoanerRequest request)
        {
            Loaner newLoaner = MapLoanerRequestToLoaner(request);
            newLoaner = await _repository.CreateLoaner(newLoaner);

            if (newLoaner != null)
            {
                return MapLoanerToLoanerResponse(newLoaner);

            }
            return null;
        }

        public async Task<LoanerResponse> DeleteLoaner(int id)
        {
            Loaner deletedLoaner = await _repository.DeleteLoaner(id);
            if (deletedLoaner != null)
            {
                return MapLoanerToLoanerResponse(deletedLoaner);
            }
            return null;
        }

        public async Task<List<LoanerResponse>> GetAllLoaners()
        {
            List<Loaner> loaners = await _repository.GetAllLoaners();
            return loaners.Select(loaner => MapLoanerToLoanerResponse(loaner)).ToList();
        }

        public async Task<LoanerResponse> GetLoanerById(int id)
        {
            Loaner loaner = await _repository.GetLoanerById(id);
            if (loaner != null)
            {
                return MapLoanerToLoanerResponse(loaner);
            }
            return null;
        }

        public async Task<List<LoanerResponse>> GetLoanerByName(string name)
        {
            List<Loaner> loaners = await _repository.GetLoanerByName(name);

            return loaners.Select(x => MapLoanerToLoanerResponse(x)).ToList();
        }

        public async Task<LoanerResponse> UpdateLoaner(int id, LoanerRequest request)
        {
            Loaner updateLoaner = MapLoanerRequestToLoaner(request);
            updateLoaner = await _repository.UpdateLoaner(id, updateLoaner);

            if (updateLoaner != null)
            {
                return MapLoanerToLoanerResponse(updateLoaner);
            }
            return null;
        }

        private Loaner MapLoanerRequestToLoaner(LoanerRequest request)
        {
            return new()
            {
                Name = request.Name,
                LoanerTypeId = request.LoanerTypeId,
                Password = request.Password
            };
        }

        private LoanerResponse MapLoanerToLoanerResponse(Loaner loaner)
        {
            bool kaffe = true;

            bool isTrue = true;

            kaffe = isTrue == true ? true: false;
            return new()
            {
                LoanerId = loaner.LoanerId,
                LoanerName = loaner.Name,
                Password = loaner.Password,

                Loans = loaner.Loans != null ? loaner.Loans.Select(loan => new LoanerLoanResponse
                {
                    LoanerId = loan.LoanId,
                    MaterialId = loan.MaterialId,
                    LoanDate = loan.LoanDate,
                    ReturnDate = loan.ReturnDate
                }).ToList() : new(),

                TypeOfLoaner = loaner.TypeOfLoaner != null ? new LoanerLoanerTypeResponse
                {
                    LoanerTypeId = loaner.TypeOfLoaner.LoanerTypeId,
                    Name = loaner.TypeOfLoaner.Name
                } : null

            };

        }
    }
}
