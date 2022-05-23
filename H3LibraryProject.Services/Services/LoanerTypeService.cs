using H3LibraryProject.Repositories.Database;
using H3LibraryProject.Repositories.Repositories;
using H3LibraryProject.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H3LibraryProject.Services.Services
{
    public interface ILoanerTypeService
    {
        Task<List<LoanerTypeResponse>> GetAllLoanerTypes();
        Task<LoanerTypeResponse> CreateLoanerType(LoanerTypeRequest newLoanerTypeRequest);
        Task<LoanerTypeResponse> GetLoanerTypeById(int id);
        Task<LoanerTypeResponse> UpdateLoanerType(int id, LoanerTypeRequest loanerTypeRequest);
        Task<LoanerTypeResponse> DeleteLoanerType(int id);
    }
    public class LoanerTypeService : ILoanerTypeService
    {
        private readonly ILoanerTypeRepository _repository;

        public LoanerTypeService(ILoanerTypeRepository repository)
        {
            _repository = repository;
        }
        public async Task<LoanerTypeResponse> CreateLoanerType(LoanerTypeRequest newLoanerTypeRequest)
        {
            LoanerType loanerType = MapLoanerTypeRequestToLoanerType(newLoanerTypeRequest);
            loanerType = await _repository.CreateLoanerType(loanerType);
            return MapLoanerTypeToLoanerTypeResponse(loanerType);
        }

        public async Task<LoanerTypeResponse> DeleteLoanerType(int id)
        {
            LoanerType deletedLoanerType = await _repository.DeleteLoanerType(id);
            return MapLoanerTypeToLoanerTypeResponse(deletedLoanerType);
        }

        public async Task<List<LoanerTypeResponse>> GetAllLoanerTypes()
        {
            List<LoanerType> loanerTypeList = await _repository.GetAllLoanerTypes();
            return loanerTypeList.Select(loanerType => MapLoanerTypeToLoanerTypeResponse(loanerType)).ToList();
        }

        public async Task<LoanerTypeResponse> GetLoanerTypeById(int id)
        {
            LoanerType loanerType = await _repository.GetLoanerTypeById(id);
            return MapLoanerTypeToLoanerTypeResponse(loanerType);
        }

        public async Task<LoanerTypeResponse> UpdateLoanerType(int id, LoanerTypeRequest loanerTypeRequest)
        {
            LoanerType loanerType = MapLoanerTypeRequestToLoanerType(loanerTypeRequest);
            loanerType = await _repository.UpdateLoanerType(id, loanerType);
            return MapLoanerTypeToLoanerTypeResponse(loanerType);
        }

        private LoanerType MapLoanerTypeRequestToLoanerType(LoanerTypeRequest request)
        {
            return new LoanerType()
            {
                Name = request.Name
            };
        }

        private LoanerTypeResponse MapLoanerTypeToLoanerTypeResponse(LoanerType response)
        {
            return new LoanerTypeResponse()
            {
                LoanerTypeId = response.LoanerTypeId,
                Name = response.Name
            };
        }
    }
}
