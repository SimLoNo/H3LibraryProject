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
    public interface IAuthorService
    {
        Task<AuthorResponse> InsertNewAuthor(AuthorRequest newAuthor);
        Task<List<AuthorResponse>> SelectAllAuthors(); 
        Task<AuthorResponse> SelectAuthorById(int authorId);
        Task<AuthorResponse> SelectAuthorsByNationality(int nationalityId);
        Task<AuthorResponse> UpdateExistingAuthor(int authorId, AuthorRequest request);
        Task<AuthorResponse> DeleteAuthor(int authorId); //jeg har på et tidspunkt kaldt den DeleteAuthorById: måske vigtigt
    }

    public class AuthorService : IAuthorService
    {
        private readonly IAuthorService _repository;

        public AuthorService(IAuthorService repository)
        {
            _repository = repository;
        }

        //Create
        public async Task<AuthorResponse> InsertNewAuthor(AuthorRequest newAuthor)
        {
            Author author = MapAuthorRequestToAuthor(newAuthor);
            Author insertedAuthor = await _repository.InsertNewAuthor(author);

            if (insertedAuthor != null)
            {
                return MapAuthorToAuthorResponse(insertedAuthor);

            }
            return null;
        }
        //Read
        public async Task<List<AuthorResponse>> SelectAllAuthors()
        {
            List<Author> author = await _repository.SelectAllAuthors();
            return author.Select(author => MapAuthorToAuthorResponse(author)).ToList();
        }

        public async Task<AuthorResponse> SelectAuthorById(int authorId)
        {
            Author author = await _repository.SelectAuthorById(authorId);
            if (author != null)
            {
                return MapAuthorToAuthorResponse(author);
            }
            return null;
        }

        public async Task<AuthorResponse> SelectAuthorsByNationality(int nationalityId)
        {
            List<Author> author = await _repository.SelectAuthorsByNationality(nationalityId);

            return author.Select(x => MapAuthorToAuthorResponse(x)).ToList();
        }
        //Update
        public async Task<AuthorResponse> UpdateExistingAuthor(int authorId, AuthorRequest request)
        {
            Author author = MapAuthorRequestToAuthor(request);

            Author updatedAuthor = await _repository.UpdateExistingAuthor(authorId, author);

            if (updatedAuthor != null)
            {
                return MapAuthorToAuthorResponse(updatedAuthor);
            }
            return null;
        }
        //Delete
        public async Task<AuthorResponse> DeleteAuthor(int authorId)
        {
            Author deletedAuthor = await _repository.DeleteAuthor(authorId);
            if (deletedAuthor != null)
            {
                return MapAuthorToAuthorResponse(deletedAuthor);
            }
            return null;
        }

        //Mappings
        private Author MapAuthorRequestToAuthor(AuthorRequest request) //Er der egentlig en speciel grund til, at disse skal være private?
        { //Bruges til nye authors
            return new Author
            {
                FName = request.FName,
                MName = request.MName,
                LName = request.LName,
                BYear = request.BYear,
                DYear = request.DYear,
                Nationality = request.NationalityId
            };
        }
        private AuthorResponse MapAuthorToAuthorResponse(Author author)
        {
            bool kaffe = true;

            bool isTrue = true;

            kaffe = isTrue == true ? true : false;
            return new()
            {
                AuthorId = author.AuthorId,
                FName = author.FName,
                LName= author.LName,
                MName= author.MName,
                BYear= author.BYear,
                DYear= author.DYear                                             

            };

        }
    }
}