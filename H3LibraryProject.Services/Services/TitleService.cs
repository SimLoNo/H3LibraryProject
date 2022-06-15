using H3LibraryProject.API.DTOs;
using H3LibraryProject.Repositories.Database;
using H3LibraryProject.Repositories.Database.Models;
using H3LibraryProject.Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H3LibraryProject.Services.Services
{
    public interface ITitleService
    {
        //Create
        Task<TitleResponse> CreateTitle(TitleRequest newTitle);

        //Read
        Task<List<TitleResponse>> GetAllTitles();
        Task<List<TitleResponse>> GetTitlesByAuthorId(int authorId);
        Task<List<TitleResponse>> GetTitlesByGenreId(int genreId);
        Task<TitleResponse> GetTitlesById(int titleId);

        //Update
        Task<TitleResponse> UpdateTitle(int titleId, TitleRequest updateTitle);

        //Delete
        Task<TitleResponse> DeleteTitle(int titleId);
    }

    public class TitleService : ITitleService
    {
        private readonly ITitleRepository _TitleRepository;

        public TitleService(ITitleRepository TitleRepository)
        {
            _TitleRepository = TitleRepository;
        }

        //Mappings

        private TitleResponse MapTitleToTitleResponse(Title title)
        { //Bruges til eksisterende titler
            return new TitleResponse
            {
                TitleId = title.TitleId,
                Name = title.Name,
                Pages = title.Pages,
                RYear = title.RYear,
                LanguageId = title.LanguageId,
                GenreId = title.GenreId,
                PublisherId = title.PublisherId,


                Author = title.Authors != null ? title.Authors.Select(AuthorObj => new TitleAuthorResponse //Modsat AuthorTitleResponse ikke liste
                {
                    AuthorId = AuthorObj.AuthorId,
                    LName = AuthorObj.LName,
                    FName = AuthorObj.FName,
                    MName = AuthorObj.MName,
                    BYear = AuthorObj.BYear,
                    DYear = AuthorObj.DYear
                }).ToList(): null
            
                
            };

        }
        private Title MapTitleRequestToTitle(TitleRequest titleRequest)
        { //Bruges til nye titler
            return new Title
            {
                Name = titleRequest.Name,
                Pages = titleRequest.Pages,
                RYear = titleRequest.RYear,
                LanguageId = titleRequest.LanguageId,
                GenreId = titleRequest.GenreId,
                //AuthorId = titleRequest.AuthorId,
                PublisherId = titleRequest.PublisherId,
                Authors = titleRequest.AuthorsList != null ? titleRequest.AuthorsList.Select(authorObj => new Author
                {
                    AuthorId = authorObj
                }).ToList() : new()
            };
        }


        //Create
        public async Task<TitleResponse> CreateTitle(TitleRequest newTitle)
        {
            Title Title = MapTitleRequestToTitle(newTitle);

            Title insertedTitle = await _TitleRepository.InsertNewTitle(Title);

            if (insertedTitle != null)
            {
                return MapTitleToTitleResponse(insertedTitle);
            }
            return null;
        }

        //Read
        public async Task<List<TitleResponse>> GetAllTitles()
        {
            List<Title> Titles = await _TitleRepository.SelectAllTitles();
            return Titles.Select(Title => MapTitleToTitleResponse(Title)).ToList();
        }

        public async Task<TitleResponse> GetTitlesById(int titleId)
        {
            Title Titles = await _TitleRepository.SelectTitleById(titleId);
            if (Titles != null)
            {
                return MapTitleToTitleResponse(Titles);
            }
            return null;
        }

        public async Task<List<TitleResponse>> GetTitlesByAuthorId(int authorId)
        {
            List<Title> Titles = await _TitleRepository.SelectTitlesByAuthorId(authorId);
            if (Titles != null)
            {
                return Titles.Select(Title => MapTitleToTitleResponse(Title)).ToList();
            }
            return null;
        }

        public async Task<List<TitleResponse>> GetTitlesByGenreId(int genreId)
        {
            List<Title> Titles = await _TitleRepository.SelectTitlesByGenreId(genreId);
            if (Titles != null)
            {
                return Titles.Select(Title => MapTitleToTitleResponse(Title)).ToList();
            }
            return null;
        }



        //Update
        public async Task<TitleResponse> UpdateTitle(int titleId, TitleRequest request)
        {
            Title title = MapTitleRequestToTitle(request);
            Title updatedTitle = await _TitleRepository.UpdateExistingTitle(titleId, title);
            if (updatedTitle != null)
            {
                return MapTitleToTitleResponse(updatedTitle);
            }
            return null;
        }

        //Delete
        public async Task<TitleResponse> DeleteTitle(int titleId)
        {
            Title deletedTitle = await _TitleRepository.DeleteTitle(titleId);
            if (deletedTitle != null)
            {
                return MapTitleToTitleResponse(deletedTitle);
            }
            return null;
        }
    }
}
