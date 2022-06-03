using H3LibraryProject.API.DTOs;
using H3LibraryProject.Repositories.Database.Models;
using H3LibraryProject.Repositories.Repositories;
using H3LibraryProject.Services.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace H3LibraryProject.Tests.ServiceTests
{
    public class AuthorServiceTests
    {
        private readonly AuthorService _authorService;
        private readonly Mock<IAuthorRepository> _mockAuthorRepository = new();

        public AuthorServiceTests()
        {
            _authorService = new(_mockAuthorRepository.Object);
        }
        //Create
        [Fact]
        public async void CreateAuthor_ShouldReturnAuthorResponse_WhenCreateIsSuccess()
        {
            //Arrange
            AuthorRequest newAuthor = new()
            {
                FName = "Dan",
                LName = "Abnett",
                BYear = 1965
            };

            int authorId = 1;

            Author createdAuthor = new()
            {
                AuthorId = authorId,
                FName = "Dan",
                LName = "Abnett",
                BYear = 1965
            };

            _mockAuthorRepository
                .Setup(x => x.CreateAuthor(It.IsAny<Author>()))
                .ReturnsAsync(createdAuthor);

            //Act
            var result = await _authorService.CreateAuthor(newAuthor);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<AuthorResponse>(result);
            Assert.Equal(authorId, result.AuthorId);
            Assert.Equal(newAuthor.FName, result.FName);
            Assert.Equal(newAuthor.LName, result.LName);
            Assert.Equal(newAuthor.FName, result.FName);
        }
        [Fact]
        public async void CreateAuthor_ShouldReturnNull_WhenRepositoryReturnsNull()

        {
            //Arrange
            AuthorRequest newAuthor = new()
            {
                FName = "Dan",
                LName = "Abnett",
                BYear = 1965
            };

            _mockAuthorRepository
                .Setup(x => x.CreateAuthor(It.IsAny<Author>()))
                .ReturnsAsync(() => null);
            //Act
            var result = await _authorService.CreateAuthor(newAuthor);

            //Assert
            Assert.Null(result);
        }

        //Read
        [Fact]
        public async void GetAllAuthors_ShouldReturnListOfAuthorResponses_WhenAuthorsExists()
        {
            //Arrange
            List<Author> authors = new();

            authors.Add(new()
            {
                AuthorId = 1,
                FName = "Dan",
                LName = "Abnett",
                BYear = 1965
            });

            authors.Add(new()
            {
                AuthorId = 2,
                FName = "Bjarne",
                MName = "Bertram",
                LName = "Reuter",
                BYear = 1950
            });

            _mockAuthorRepository
                .Setup(x => x.GetAllAuthors())
                .ReturnsAsync(authors);

            //Act
            var result = await _authorService.GetAllAuthors();

            //Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            Assert.IsType<List<AuthorResponse>>(result);
        }
        [Fact]
        public async void GetAllAuthors_ShouldReturnEmptyListOfAuthorResponses_WhenNoAuthorsExists()
        {
            //Arrange
            List<Author> Authors = new();

            _mockAuthorRepository
                .Setup(x => x.GetAllAuthors())
                .ReturnsAsync(Authors);

            //Act
            var result = await _authorService.GetAllAuthors();

            //Assert
            Assert.NotNull(result);
            Assert.Empty(result);
            Assert.IsType<List<AuthorResponse>>(result);
        }
        [Fact]
        public async void GetAuthorById_ShouldReturnNull_WhenAuthorDoesNotExist()

        {
            //Arrange
            int authorId = 1;


            _mockAuthorRepository
                .Setup(x => x.GetAuthorById(It.IsAny<int>())) //pænt underlig at kigge på
                .ReturnsAsync(() => null);

            //Act
            var result = await _authorService.GetAuthorById(authorId);

            //Assert
            Assert.Null(result);
        }
        [Fact]
        public async void GetAuthorById_ShouldReturnAuthorResponse_WhenAuthorExists()
        {
            //Arrange
            int authorId = 1;

            Author author = new()
            {
                FName = "Dan",
                LName = "Abnett",
                BYear = 1965
            };

            _mockAuthorRepository
                .Setup(x => x.GetAuthorById(It.IsAny<int>()))
                .ReturnsAsync(author);

            //Act
            var result = await _authorService.GetAuthorById(authorId);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<AuthorResponse>(result);
            Assert.Equal(author.AuthorId, result.AuthorId);
            Assert.Equal(author.FName, result.FName);
            Assert.Equal(author.LName, result.LName);
            Assert.Equal(author.BYear, result.BYear);
        }

        //Update
        [Fact]
        public async void UpdateAuthor_ShouldReturnAuthorResponse_WhenUpdateIsSuccess()
        {
            //Arrange
            AuthorRequest authorRequest = new()
            {
                FName = "Dan",
                LName = "Abnett",
                BYear = 1965
            };

            int authorId = 1;

            Author author = new()
            {
                AuthorId = authorId,
                FName = "Dan",
                LName = "Abnett",
                BYear = 1965
            };

            _mockAuthorRepository
                .Setup(x => x.UpdateExistingAuthor(It.IsAny<int>(), It.IsAny<Author>()))
                .ReturnsAsync(author);

            //Act
            var result = await _authorService.UpdateExistingAuthor(authorId, authorRequest);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<AuthorResponse>(result);
            Assert.Equal(authorId, result.AuthorId);
            Assert.Equal(authorRequest.FName, result.FName);
            Assert.Equal(authorRequest.LName, result.LName);
            Assert.Equal(authorRequest.BYear, result.BYear);
        }
        [Fact]
        public async void UpdateAuthor_ShouldReturnNull_WhenAuthorDoesNotExist()
        {
            //Arrange
            AuthorRequest authorRequest = new()
            {
                FName = "Dan",
                LName = "Abnett",
                BYear = 1965
            };

            int authorId = 1;

            _mockAuthorRepository
                .Setup(x => x.UpdateExistingAuthor(It.IsAny<int>(), It.IsAny<Author>()))
                .ReturnsAsync(() => null);

            //Act
            var result = await _authorService.UpdateExistingAuthor(authorId, authorRequest);

            //Assert
            Assert.Null(result);
        }

        //Delete
        [Fact]
        public async void DeleteAuthor_ShouldReturnAuthorResponse_WhenDeleteIsSuccess()
        {
            //Arrange
            int authorId = 1;

            Author deletedAuthor = new()
            {
                AuthorId = 1,
                FName = "Dan",
                LName = "Abnett",
                BYear = 1965
            };

            _mockAuthorRepository
                .Setup(x => x.DeleteAuthor(It.IsAny<int>()))
                .ReturnsAsync(() => null);

            //Act
            var result = await _authorService.DeleteAuthor(authorId);

            //Assert
            Assert.Null(result);
        }
        [Fact]
        public async void DeleteAuthor_ShouldReturnNull_WhenAuthorDoesNotExist()
        {
            //Arrange
            int authorId = 1;

            _mockAuthorRepository
                .Setup(x => x.DeleteAuthor(It.IsAny<int>()))
                .ReturnsAsync(() => null);

            //Act
            var result = await _authorService.DeleteAuthor(authorId);

            //Assert
            Assert.Null(result);
        }
    }
}
