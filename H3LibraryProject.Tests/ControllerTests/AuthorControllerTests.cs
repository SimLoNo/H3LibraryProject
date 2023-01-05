using H3LibraryProject.API.Controllers;
using H3LibraryProject.API.DTOs;
using H3LibraryProject.Services.Services;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Moq;//Gætværk
using System;
using System.Collections.Generic;
using Xunit;

namespace H3LibraryProject.Tests.ControllerTests
{
    public class AuthorControllerTests
    {
        private readonly AuthorController _controller;
        private readonly Mock<IAuthorService> _authorServiceMock = new();

        public AuthorControllerTests()
        {
            _controller = new(_authorServiceMock.Object);
        }

        //Create
        [Fact]
        public async void Create_ShouldReturnStatusCode200_WhenAuthorIsSuccessfullyCreated()
        {
            //Arrange
            AuthorRequest newAuthor = new()
            {
                FName = "Dan",
                LName = "Abnett",
                BYear = 1965,
                NationalityId = 3
            }; ;

            int authorId = 1;

            AuthorResponse authorResponse = new()
            {
                AuthorId = authorId,
                FName = "Dan",
                LName = "Abnett",
                BYear = 1965,
                NationalityId = 3
            };

            _authorServiceMock
                .Setup(x => x.CreateAuthor(It.IsAny<AuthorRequest>()))
                .ReturnsAsync(authorResponse);

            //Act
            var result = await _controller.CreateAuthor(newAuthor);

            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(200, statusCodeResult.StatusCode);
        }
            [Fact]
            public async void Create_ShouldReturnStatusCode500_WhenExceptionIsRaised()
            {
                //Arrange
                AuthorRequest newAuthor = new()
                {
                    FName = "Dan",
                    LName = "Abnett",
                    BYear = 1965,
                    NationalityId = 3
                }; ;


                _authorServiceMock
                    .Setup(x => x.CreateAuthor(It.IsAny<AuthorRequest>()))
                    .ReturnsAsync(() => throw new System.Exception("Dette er en undtagelse, compadré!"));

                //Act
                var result = await _controller.CreateAuthor(newAuthor);

                //Assert
                var statusCodeResult = (IStatusCodeActionResult)result;
                Assert.Equal(500, statusCodeResult.StatusCode);
            }
        //Read
        //ById
        [Fact]
        public async void GetById_ShouldReturnStatusCode200_WhenDataExists()
        {
            //Arrange
            int authorId = 1;

            AuthorResponse author = new()
            {
                AuthorId = authorId,
                FName = "Dan",
                LName = "Abnett",
                BYear = 1965,
                NationalityId = 3
            };

            _authorServiceMock.
                Setup(x => x.GetAuthorById(It.IsAny<int>())).
                ReturnsAsync(author);

            //Act
            var result = await _controller.GetAuthorById(authorId);

            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(200, statusCodeResult.StatusCode);
        }
        [Fact]
        public async void GetById_ShouldReturnStatusCode404_WhenAuthorDoesNotExist()
        {
            //Arrange 
            int authorId = 1;

            _authorServiceMock.
               Setup(x => x.GetAuthorById(It.IsAny<int>())).
               ReturnsAsync(() => null);

            //Act
            var result = await _controller.GetAuthorById(authorId);

            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(404, statusCodeResult.StatusCode);
        }
        [Fact]
        public async void GetById_ShouldReturnStatusCode500_WhenExceptionIsRaised()
        {
            //Arrange 
            _authorServiceMock.
               Setup(x => x.GetAuthorById(It.IsAny<int>())).
               ReturnsAsync(() => throw new System.Exception("Dette er en undtagelse."));

            //Act
            var result = await _controller.GetAuthorById(1);

            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(500, statusCodeResult.StatusCode);
        }

        //All
        [Fact]
        public async void GetAll_ShouldReturnStatusCode200_WhenAuthorsExists()
        {
            //Arrange
            List<AuthorResponse> authors = new(); //Laver en liste, som vi har befolket manuelt

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
                FName = "Hans",
                MName = "Christian",
                LName = "Andersen",
                BYear = 1805,
                DYear = 1875
            });

            _authorServiceMock
                .Setup(x => x.GetAllAuthors())
                .ReturnsAsync(authors); //Manglede Async LOL

            //Act
            var result = await _controller.GetAllAuthors();

            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(200, statusCodeResult.StatusCode);
        }
        [Fact]
        public async void GetAll_ShouldReturnStatusCode204_WhenNoAuthorsExists()
        {
            //Arrange
            List<AuthorResponse> authors = new(); //Laver en liste, men den er tom


            _authorServiceMock
                .Setup(x => x.GetAllAuthors())
                .ReturnsAsync(authors);

            //Act
            var result = await _controller.GetAllAuthors();

            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(204, statusCodeResult.StatusCode);
        }
        [Fact]
        public async void GetAll_ShouldReturnStatusCode500_WhenNullIsReturnedFromService()
        {
            //Arrange

            _authorServiceMock
                .Setup(x => x.GetAllAuthors())
                .ReturnsAsync(() => null); //man kan ikke bare lave en .Returns(null); - man skal give den en metode, der returnerer null.

            //Act
            var result = await _controller.GetAllAuthors();

            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(500, statusCodeResult.StatusCode);
        }
        [Fact]
        public async void GetAll_ShouldReturnStatusCode500_WhenExceptionIsRaised()
        {
            //Arrange

            _authorServiceMock
                .Setup(x => x.GetAllAuthors())
                .ReturnsAsync(() => throw new Exception("This is an exception"));
            //man kan ikke bare lave en .Returns(null); - man skal give den en metode, der returnerer null.

            //Act
            var result = await _controller.GetAllAuthors();

            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(500, statusCodeResult.StatusCode);
        }

        //Update
        [Fact]
        public async void Update_ShouldReturnStatusCode200_WhenAuthorIsSuccessfullyUpdated()
        {
            //Arrange
            AuthorRequest updateAuthor = new()
            {
                FName = "Dan",
                LName = "Abnett",
                BYear = 1965
            }; ;

            int authorId = 1;

            AuthorResponse authorResponse = new()
            {
                AuthorId = authorId,
                FName = "Dan",
                LName = "Abnett",
                BYear = 1965
            };

            _authorServiceMock
                .Setup(x => x.UpdateExistingAuthor(It.IsAny<int>(), It.IsAny<AuthorRequest>()))
                .ReturnsAsync(authorResponse);

            //Act
            var result = await _controller.UpdateAuthor(authorId, updateAuthor);

            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(200, statusCodeResult.StatusCode);
        }
        [Fact]
        public async void Update_ShouldReturnStatusCode404_WhenTryingToUpdateAuthorWhichDoesNotExist()

        {
            //Arrange
            AuthorRequest updateAuthor = new()
            {
                FName = "Dan",
                LName = "Abnett",
                BYear = 1965
            }; ;

            int authorId = 1;


            _authorServiceMock
                .Setup(x => x.UpdateExistingAuthor(It.IsAny<int>(), It.IsAny<AuthorRequest>()))
                .ReturnsAsync(() => null);

            //Act
            var result = await _controller.UpdateAuthor(authorId, updateAuthor);

            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(404, statusCodeResult.StatusCode);
        }
        [Fact]
        public async void Update_ShouldReturnStatusCode500_WhenExceptionIsRaised()

        {
            //Arrange
            AuthorRequest updateAuthor = new()
            {
                FName = "Dan",
                LName = "Abnett",
                BYear = 1965
            }; ;

            int authorId = 1;


            _authorServiceMock
                .Setup(x => x.UpdateExistingAuthor(It.IsAny<int>(), It.IsAny<AuthorRequest>()))
                .ReturnsAsync(() => throw new System.Exception("Dette er en undtagelse, Tovarisch"));

            //Act
            var result = await _controller.UpdateAuthor(authorId, updateAuthor);

            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(500, statusCodeResult.StatusCode);
        }

        //Delete
        [Fact]
        public async void Delete_ShouldReturnStatusCode200_WhenAuthorIsDeleted()
        {
            //Arrange
            int authorId = 1;

            AuthorResponse authorResponse = new()
            {
                AuthorId = authorId,
                FName = "Dan",
                LName = "Abnett",
                BYear = 1965

            };

            _authorServiceMock
                .Setup(x => x.DeleteAuthor(It.IsAny<int>()))
                .ReturnsAsync(authorResponse);

            //Act
            var result = await _controller.DeleteAuthor(authorId);

            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(200, statusCodeResult.StatusCode);
        }
        [Fact]
        public async void Delete_ShouldReturnStatusCode404_WhenTryingToDeleteAuthorWhichDoesNotExist()
        {
            //Arrange
            int authorId = 1;


            _authorServiceMock
                .Setup(x => x.DeleteAuthor(It.IsAny<int>()))
                .ReturnsAsync(() => null);

            //Act
            var result = await _controller.DeleteAuthor(authorId);

            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(404, statusCodeResult.StatusCode);
        }
        [Fact]
        public async void Delete_ShouldReturnStatusCode500_WhenExceptionIsRaised()
        {
            //Arrange
            int authorId = 1;


            _authorServiceMock
                .Setup(x => x.DeleteAuthor(It.IsAny<int>()))
                .ReturnsAsync(() => throw new System.Exception("Undtagelsestilstand, beltalowda!"));

            //Act
            var result = await _controller.DeleteAuthor(authorId);

            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(500, statusCodeResult.StatusCode);
        }

    }
}