using H3LibraryProject.API.DTOs;
using H3LibraryProject.Repositories.Database;
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
        public Task<LoanerResponse> CreateLoaner(LoanerRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<LoanerResponse> DeleteLoaner(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<LoanerResponse>> GetAllLoaners()
        {
            throw new NotImplementedException();
        }

        public Task<LoanerResponse> GetLoanerById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<LoanerResponse>> GetLoanerByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<LoanerResponse> UpdateLoaner(int id, LoanerRequest request)
        {
            throw new NotImplementedException();
        }

        private Loaner MapLoanerRequestToLoaner(LoanerRequest request)
        {
            return new()
            {
                LoanerTypeId = request.LoanerTypeId,
                Name = request.Name,
            };
        }

        //private LoanerResponse MapLoanerToLoanerResponse(Loaner loaner)
        //{
        //    return new()
        //    {

        //    }

        //}
    }
}
