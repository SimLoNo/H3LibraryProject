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
    public interface ILanguageService
    {
        Task<List<LanguageResponse>> GetAllLanguages();
        Task<LanguageResponse> GetLanguageById(int id);
        Task<LanguageResponse> CreateLanguage(LanguageRequest request);
        Task<LanguageResponse> UpdateLanguage(int id, LanguageRequest request);
        Task<LanguageResponse> DeleteLanguage(int id);
    }
    public class LanguageService : ILanguageService
    {

        private readonly ILanguageRepository _repository;

        public LanguageService(ILanguageRepository repository)
        {
            _repository = repository;
        }
        public async Task<LanguageResponse> CreateLanguage(LanguageRequest request)
        {
            Language newLanguage = MapLanguageRequestToLanguage(request);
            newLanguage = await _repository.InsertNewLanguage(newLanguage);

            if (newLanguage != null)
            {
                return MapLanguageToLanguageResponse(newLanguage);

            }
            return null;
        }

        public async Task<LanguageResponse> DeleteLanguage(int id)
        {
            Language deletedLanguage = await _repository.DeleteLanguage(id);
            if (deletedLanguage != null)
            {
                return MapLanguageToLanguageResponse(deletedLanguage);
            }
            return null;
        }

        public async Task<List<LanguageResponse>> GetAllLanguages()
        {
            List<Language> languages = await _repository.SelectAllLanguages();
            return languages.Select(languageA => MapLanguageToLanguageResponse(languageA)).ToList();
        }

        public async Task<LanguageResponse> GetLanguageById(int id)
        {
            Language language = await _repository.SelectLanguageById(id);
            if (language != null)
            {
                return MapLanguageToLanguageResponse(language);
            }
            return null;
        }

        public async Task<LanguageResponse> UpdateLanguage(int id, LanguageRequest request)
        {
            Language updateLanguage = MapLanguageRequestToLanguage(request);
            updateLanguage = await _repository.UpdateExistingLanguage(id, updateLanguage);

            if (updateLanguage != null)
            {
                return MapLanguageToLanguageResponse(updateLanguage);
            }
            return null;
        }

        private Language MapLanguageRequestToLanguage(LanguageRequest request)
        {
            return new()
            {
                Name = request.Name
            };
        }

        private LanguageResponse MapLanguageToLanguageResponse(Language languageA)
        {
            return new()
            {
                LanguageId = languageA.LanguageId,
                Name = languageA.Name,
                //Titles = languageA.Titles != null ? languageA.Titles.Select(title => new LanguageTitleResponse
                //{
                //    TitleId = title.TitleId,
                //    Name = title.Name,
                //    Language = languageA.Name,
                //    RYear = title.RYear,
                //    Pages = title.Pages,
                //    PublisherId = title.PublisherId,
                //    GenreId = title.GenreId
                //}).ToList() : null
            };

        }
    }
}
