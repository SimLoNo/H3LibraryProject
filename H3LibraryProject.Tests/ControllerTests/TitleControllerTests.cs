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
    public class TitleControllerTests
    {
        private readonly TitleController _controller;
        private readonly Mock<ITitleService> _titleServiceMock = new();

        public TitleControllerTests()
        {
            _controller = new(_titleServiceMock.Object);
        }

        //Create
        [Fact]
        public async void Create_ShouldReturnStatusCode200_WhenTitleIsSuccessfullyCreated()
        {
            //Arrange
            TitleRequest newTitle = new()
            {
                Name = "Test-titel",
                Pages = 300,
                RYear = 2000
            };
            int TitleId = 1;

            TitleResponse TitleResponse = new()
            {
                TitleId = TitleId,
                Name = "Test-titel",
                Pages = 3000,
                RYear = 2000
            };

            _titleServiceMock
                .Setup(x => x.CreateTitle(It.IsAny<TitleRequest>()))
                .ReturnsAsync(TitleResponse);

            //Act
            var result = await _controller.CreateTitle(newTitle);

            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(200, statusCodeResult.StatusCode);
        }

        [Fact]
        public async void Create_ShouldReturnStatusCode500_WhenExceptionIsRaised()
        {
            //Arrange
            TitleRequest newTitle = new()
            {
                Name = "Test-titel",
                Pages = 300,
                RYear = 2000
            };

            _titleServiceMock
                .Setup(x => x.CreateTitle(It.IsAny<TitleRequest>()))
                .ReturnsAsync(() => throw new System.Exception("Dette er en undtagelse, compadré!"));

            //Act
            var result = await _controller.CreateTitle(newTitle);

            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(500, statusCodeResult.StatusCode);
        }
        //Burde man have en test for, om der er en author, når man creater?

        //Read

        //- ById
        [Fact]
        public async void GetById_ShouldReturnStatusCode200_WhenDataExists()
        {
            //Arrange
            int TitleId = 1;

            TitleResponse Title = new()
            {
                TitleId = TitleId,
                Name = "Test-titel",
                Pages = 300,
                RYear = 2000,
                // Burde have Author, men hvordan i alverden virker det? Det bliver kompliceret.

            };

            _titleServiceMock
                .Setup(x => x.GetTitlesById(It.IsAny<int>()))
                .ReturnsAsync(Title);

            //Act
            var result = await _controller.GetTitleById(TitleId);

            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(200, statusCodeResult.StatusCode);
        }

        [Fact]
        public async void GetById_ShouldReturnStatusCode404_WhenAuthorDoesNotExist()
        {
            //Arrange 
            int TitleId = 1;

            _titleServiceMock.
               Setup(x => x.GetTitlesById(It.IsAny<int>())).
               ReturnsAsync(() => null);

            //Act
            var result = await _controller.GetTitleById(TitleId);

            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(404, statusCodeResult.StatusCode);
        }

        [Fact]
        public async void GetById_ShouldReturnStatusCode500_WhenExceptionIsRaised()
        {
            //Arrange 
            _titleServiceMock.
               Setup(x => x.GetTitlesById(It.IsAny<int>())).
               ReturnsAsync(() => throw new System.Exception("Dette er en undtagelse."));

            //Act
            var result = await _controller.GetTitleById(1);

            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(500, statusCodeResult.StatusCode);
        }

        //- ByAuthorId - MANGLER!

        //- All
        [Fact]
        public async void GetAll_ShouldReturnStatusCode200_WhenAuthorsExists()
        {
            //Arrange
            List<TitleResponse> Titles = new();

            Titles.Add(new()
            {
                TitleId = 1,
                Name = "Test-titel",
                Pages = 300,
                RYear = 2000
            });

            Titles.Add(new()
            {
                TitleId = 2,
                Name = "Test-titel2",
                Pages = 300,
                RYear = 2000
            });

            _titleServiceMock
                .Setup(x => x.GetAllTitles())
                .ReturnsAsync(Titles); //Manglede Async LOL

            //Act
            var result = await _controller.GetAllTitles();

            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(200, statusCodeResult.StatusCode);
        }
        [Fact]
        public async void GetAll_ShouldReturnStatusCode204_WhenNoAuthorsExists()
        {
            //Arrange
            List<TitleResponse> Titles = new();


            _titleServiceMock
                .Setup(x => x.GetAllTitles())
                .ReturnsAsync(Titles);

            //Act
            var result = await _controller.GetAllTitles();

            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(204, statusCodeResult.StatusCode);
        }
        [Fact]
        public async void GetAll_ShouldReturnStatusCode500_WhenNullIsReturnedFromService()
        {
            //Arrange

            _titleServiceMock
                .Setup(x => x.GetAllTitles())
                .ReturnsAsync(() => null); //man kan ikke bare lave en .Returns(null); - man skal give den en metode, der returnerer null.

            //Act
            var result = await _controller.GetAllTitles();

            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(500, statusCodeResult.StatusCode);
        }
        [Fact]
        public async void GetAll_ShouldReturnStatusCode500_WhenExceptionIsRaised()
        {
            //Arrange

            _titleServiceMock
                .Setup(x => x.GetAllTitles())
                .ReturnsAsync(() => throw new Exception("This is an exception"));
            //man kan ikke bare lave en .Returns(null); - man skal give den en metode, der returnerer null.

            //Act
            var result = await _controller.GetAllTitles();

            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(500, statusCodeResult.StatusCode);
        }

        //Update
        [Fact]
        public async void Update_ShouldReturnStatusCode200_WhenAuthorIsSuccessfullyUpdated()
        {
            //Arrange
            TitleRequest updateTitle = new()
            {
                Name = "Test-titel",
                Pages = 300,
                RYear = 2000
            }; ;

            int TitleId = 1;

            TitleResponse authorResponse = new()
            {
                TitleId = TitleId,
                Name = "Test-titel",
                Pages = 300,
                RYear = 2000
            };

            _titleServiceMock
                .Setup(x => x.UpdateTitle(It.IsAny<int>(), It.IsAny<TitleRequest>()))
                .ReturnsAsync(authorResponse);

            //Act
            var result = await _controller.UpdateTitle(TitleId, updateTitle);

            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(200, statusCodeResult.StatusCode);
        }
        [Fact]
        public async void Update_ShouldReturnStatusCode404_WhenTryingToUpdateAuthorWhichDoesNotExist()

        {
            //Arrange
            TitleRequest updateTitle = new()
            {
                Name = "Test-titel",
                Pages = 300,
                RYear = 2000
            }; ;

            int TitleId = 1;


            _titleServiceMock
                .Setup(x => x.UpdateTitle(It.IsAny<int>(), It.IsAny<TitleRequest>()))
                .ReturnsAsync(() => null);

            //Act
            var result = await _controller.UpdateTitle(TitleId, updateTitle);

            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(404, statusCodeResult.StatusCode);
        }
        [Fact]
        public async void Update_ShouldReturnStatusCode500_WhenExceptionIsRaised()

        {
            //Arrange
            TitleRequest updateTitle = new()
            {
                Name = "Test-titel",
                Pages = 300,
                RYear = 2000
            }; ;

            int TitleId = 1;


            _titleServiceMock
                .Setup(x => x.UpdateTitle(It.IsAny<int>(), It.IsAny<TitleRequest>()))
                .ReturnsAsync(() => throw new System.Exception("Dette er en undtagelse, Tovarisch"));

            //Act
            var result = await _controller.UpdateTitle(TitleId, updateTitle);

            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(500, statusCodeResult.StatusCode);
        }

        //Delete
        [Fact]
        public async void Delete_ShouldReturnStatusCode200_WhenAookIsDeleted()
        {
            //Arrange
            int TitleId = 1;

            TitleResponse TitleResponse = new()
            {
                TitleId = TitleId,
                Name = "Test-titel",
                Pages = 300,
                RYear = 2000
            };

            _titleServiceMock
                .Setup(x => x.DeleteTitle(It.IsAny<int>()))
                .ReturnsAsync(TitleResponse);

            //Act
            var result = await _controller.DeleteTitle(TitleId);

            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(200, statusCodeResult.StatusCode);
        }
        [Fact]
        public async void Delete_ShouldReturnStatusCode404_WhenTryingToDeleteAookWhichDoesNotExist()
        {
            //Arrange
            int aookId = 1;


            _titleServiceMock
                .Setup(x => x.DeleteTitle(It.IsAny<int>()))
                .ReturnsAsync(() => null);

            //Act
            var result = await _controller.DeleteTitle(aookId);

            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(404, statusCodeResult.StatusCode);
        }
        [Fact]
        public async void Delete_ShouldReturnStatusCode500_WhenExceptionIsRaised()
        {
            //Arrange
            int aookId = 1;


            _titleServiceMock
                .Setup(x => x.DeleteTitle(It.IsAny<int>()))
                .ReturnsAsync(() => throw new System.Exception("Undtagelsestilstand, beltalowda!"));

            //Act
            var result = await _controller.DeleteTitle(aookId);

            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(500, statusCodeResult.StatusCode);
        }
    }
}
