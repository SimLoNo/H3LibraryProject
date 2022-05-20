using H3LibraryProject.Repositories.Database;
using H3LibraryProject.Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H3LibraryProject.Services.Services
{
    public interface ILoanerTypeService
    {
        Task<List<LoanerType>> GetAllLoanerTypes();
        Task<LoanerType> CreateLoanerType(LoanerType loanerType);
        Task<LoanerType> GetLoanerTypeById(int id);
        Task<LoanerType> UpdateLoanerType(int id, LoanerType loanerType);
        Task<LoanerType> DeleteLoanerType(LoanerType loanerType)
    }
    public class LoanerTypeService : ILoanerTypeService
    {
        private readonly ILoanerTypeRepository _repository;

        public LoanerTypeService(ILoanerTypeRepository repository)
        {
            _repository = repository;
        }
        public async Task<LoanerType> CreateLoanerType(LoanerType newLoanerType)
        {
            return await _repository.CreateLoanerType(newLoanerType);
        }

        public Task<LoanerType> DeleteLoanerType(LoanerType loanerType)
        {
            throw new NotImplementedException();
        }

        public async Task<List<LoanerType>> GetAllLoanerTypes()
        {
            return await _repository.GetAllLoanerTypes();
        }

        public Task<LoanerType> GetLoanerTypeById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<LoanerType> UpdateLoanerType(int id, LoanerType loanerType)
        {
            throw new NotImplementedException();
        }
    }
}
