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
    public interface IGenreService
    {
        Task<List<GenreResponse>> GetAllGenres();
        Task<GenreResponse> GetGenreById(int id);
        Task<List<GenreResponse>> GetGenreByName(string name);
        Task<GenreResponse> CreateGenre(GenreRequest request);
        Task<GenreResponse> UpdateGenre(int id, GenreRequest request);
        Task<GenreResponse> DeleteGenre(int id);
    }
    public class GenreService
    {
        private readonly IGenreRepository _repository;

        public GenreService(IGenreRepository repository)
        {
            _repository = repository;
        }
        public async Task<GenreResponse> CreateGenre(GenreRequest request)
        {
            Genre newGenre = MapGenreRequestToGenre(request);
            newGenre = await _repository.InsertNewGenre(newGenre);

            if (newGenre != null)
            {
                return MapGenreToGenreResponse(newGenre);

            }
            return null;
        }

        public async Task<GenreResponse> DeleteGenre(int id)
        {
            Genre deletedGenre = await _repository.DeleteGenre(id);
            if (deletedGenre != null)
            {
                return MapGenreToGenreResponse(deletedGenre);
            }
            return null;
        }

        public async Task<List<GenreResponse>> GetAllGenres()
        {
            List<Genre> genres = await _repository.SelectAllGenres();
            return genres.Select(genre => MapGenreToGenreResponse(genre)).ToList();
        }

        public async Task<GenreResponse> GetGenreById(int id)
        {
            Genre genre = await _repository.SelectGenreById(id);
            if (genre != null)
            {
                return MapGenreToGenreResponse(genre);
            }
            return null;
        }

        public async Task<GenreResponse> UpdateGenre(int id, GenreRequest request)
        {
            Genre updateGenre = MapGenreRequestToGenre(request);
            updateGenre = await _repository.UpdateExistingGenre(id, updateGenre);

            if (updateGenre != null)
            {
                return MapGenreToGenreResponse(updateGenre);
            }
            return null;
        }

        private Genre MapGenreRequestToGenre(GenreRequest request)
        {
            return new()
            {
                Name = request.Name,
                LeasePeriod = request.LeasePeriod
            };
        }

        private GenreResponse MapGenreToGenreResponse(Genre genre)
        {
            return new()
            {
                GenreId = genre.GenreId,
                Name = genre.Name,
                LeasePeriod = genre.LeasePeriod,
                Titles = genre.Titles != null ? genre.Titles.Select(t => new GenreTitleResponse
                {
                    TitleId = t.TitleId,
                    Name = t.Name,
                    // Language needs a solution to be added.
                    RYear = t.RYear,
                    Pages = t.Pages,
                    PublisherId = t.PublisherId,
                    GenreId=t.GenreId
                }).ToList() : null
            };

        }
    }
}
