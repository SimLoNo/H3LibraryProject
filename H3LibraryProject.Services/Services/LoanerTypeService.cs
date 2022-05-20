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
        Task<LoanerType> DeleteLoanerType(int id);
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

        public async Task<LoanerType> DeleteLoanerType(int id)
        {
            return await _repository.DeleteLoanerType(id);
        }

        public async Task<List<LoanerType>> GetAllLoanerTypes()
        {
            return await _repository.GetAllLoanerTypes();
        }

        public async Task<LoanerType> GetLoanerTypeById(int id)
        {
            return await _repository.GetLoanerTypeById(id);
        }

        public async Task<LoanerType> UpdateLoanerType(int id, LoanerType loanerType)
        {
            return await _repository.UpdateLoanerType(id, loanerType);
        }

        
    }
}
