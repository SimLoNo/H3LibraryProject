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
    public interface INationalityService
    {
        Task<List<NationalityResponse>> GetAllNationalitys();
        Task<NationalityResponse> GetNationalityById(int id);
        Task<NationalityResponse> CreateNationality(NationalityRequest request);
        Task<NationalityResponse> UpdateNationality(int id, NationalityRequest request);
        Task<NationalityResponse> DeleteNationality(int id);
    }
    public class NationalityService
    {
        private readonly INationalityRepository _repository;

        public NationalityService(INationalityRepository repository)
        {
            _repository = repository;
        }
        public async Task<NationalityResponse> CreateNationality(NationalityRequest request)
        {
            Nationality newNationality = MapNationalityRequestToNationality(request);
            newNationality = await _repository.InsertNewNationality(newNationality);

            if (newNationality != null)
            {
                return MapNationalityToNationalityResponse(newNationality);

            }
            return null;
        }

        public async Task<NationalityResponse> DeleteNationality(int id)
        {
            Nationality deletedNationality = await _repository.DeleteNationality(id);
            if (deletedNationality != null)
            {
                return MapNationalityToNationalityResponse(deletedNationality);
            }
            return null;
        }

        public async Task<List<NationalityResponse>> GetAllNationalitys()
        {
            List<Nationality> nationalitys = await _repository.SelectAllNationalities();
            return nationalitys.Select(nationality => MapNationalityToNationalityResponse(nationality)).ToList();
        }

        public async Task<NationalityResponse> GetNationalityById(int id)
        {
            Nationality nationality = await _repository.SelectNationalityById(id);
            if (nationality != null)
            {
                return MapNationalityToNationalityResponse(nationality);
            }
            return null;
        }

        public async Task<NationalityResponse> UpdateNationality(int id, NationalityRequest request)
        {
            Nationality updateNationality = MapNationalityRequestToNationality(request);
            updateNationality = await _repository.UpdateExistingNationality(id, updateNationality);

            if (updateNationality != null)
            {
                return MapNationalityToNationalityResponse(updateNationality);
            }
            return null;
        }

        private Nationality MapNationalityRequestToNationality(NationalityRequest request)
        {
            return new()
            {
            };
        }

        private NationalityResponse MapNationalityToNationalityResponse(Nationality nationality)
        {
            if (nationality != null)
            {

                return new();
            }
            return null;
            //return new()
            //{
            //    NationalityId = nationality.NationalityId,
            //    Name = nationality.Name,
            //    LeasePeriod = nationality.LeasePeriod,
            //    Titles = nationality.Titles != null ? nationality.Titles.Select(t => new NationalityTitleResponse
            //    {
            //        TitleId = t.TitleId,
            //        Name = t.Name,
            //        // Language needs a solution to be added.
            //        RYear = t.RYear,
            //        Pages = t.Pages,
            //        PublisherId = t.PublisherId,
            //        NationalityId = t.NationalityId
            //    }).ToList() : null
            //};

        }
    }
}
