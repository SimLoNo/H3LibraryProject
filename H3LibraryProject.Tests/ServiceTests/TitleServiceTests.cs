using H3LibraryProject.API.DTOs;
using H3LibraryProject.Repositories.Database;
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
    public class TitleServiceTests
    {
        private readonly TitleService _service;
        private readonly Mock<ITitleRepository> _mockRepository = new();

        public TitleServiceTests()
        {
            _service = new(_mockRepository.Object);
        }
        [Fact]
        public async void CreateTitle_ShouldReturnNTitleResponse_whenTitleIsCreated()
        {
            //Arrange
            int id = 1;
            Title title = new()
            {
                TitleId = id,
                Name = "elmer",
                LanguageId = 1,
                RYear = 1990,
                Pages = 300,
                PublisherId = 1,
                AuthorId = 1,
                GenreId = 1,
            };
            TitleRequest request = new()
            {
                Name = "elmer",
                LanguageId = 1,
                RYear = 1990,
                Pages = 300,
                PublisherId = 1,
                GenreId = 1,
            };

            _mockRepository
                .Setup(x => x.InsertNewTitle(It.IsAny<Title>()))
                .ReturnsAsync(title);
            //Act
            var result = await _service.CreateTitle(request);
            //Assert
            Assert.NotNull(result);
            Assert.IsType<TitleResponse>(result);
        }


        [Fact]
        public async void CreateTitle_ShouldReturnNull_WhenTitleIsNotCreated()
        {
            //Arrange
            TitleRequest request = new()
            {
                Name = "elmer",
                LanguageId = 1,
                RYear = 1990,
                Pages = 300,
                PublisherId = 1,
                GenreId = 1,
            };

            _mockRepository
                .Setup(x => x.InsertNewTitle(It.IsAny<Title>()))
                .ReturnsAsync(() => null);
            //Act
            var result = await _service.CreateTitle(request);
            //Assert
            Assert.Null(result);
        }

        [Fact]
        public async void DeleteTitle_ShouldReturnTitleResponse_WhenTitleIsDeleted()
        {
            //Arrange
            int id = 1;
            Title title = new()
            {
                TitleId = id,
                Name = "elmer",
                LanguageId = 1,
                RYear = 1990,
                Pages = 300,
                PublisherId = 1,
                AuthorId = 1,
                GenreId = 1,
            };

            _mockRepository
                .Setup(x => x.DeleteTitle(It.IsAny<int>()))
                .ReturnsAsync(title);
            //Act
            var result = await _service.DeleteTitle(id);
            //Assert
            Assert.NotNull(result);
            Assert.IsType<TitleResponse>(result);
            Assert.Equal(id, result.TitleId);
        }

        [Fact]
        public async void DeleteTitle_ShouldReturnNull_WhenTitleIsNotDeleted()
        {
            //Arrange
            int id = 1;

            _mockRepository
                .Setup(x => x.DeleteTitle(It.IsAny<int>()))
                .ReturnsAsync(() => null);

            //Act
            var result = await _service.DeleteTitle(id);
            //Assert
            Assert.Null(result);
        }

        [Fact]
        public async void GetAllTitles_ShouldReturnListOfTitleResponse_WhenTitlesExist()
        {
            //Arrange
            int id = 1;
            List<Title> titles = new()
            {
                new()
                {
                    TitleId = id,
                    Name = "elmer",
                    LanguageId = 1,
                    RYear = 1990,
                    Pages = 300,
                    PublisherId = 1,
                    AuthorId = 1,
                    GenreId = 1,
                },
                new()
                {
                    TitleId = id,
                    Name = "elmer",
                    LanguageId = 1,
                    RYear = 1990,
                    Pages = 300,
                    PublisherId = 1,
                    AuthorId = 1,
                    GenreId = 1,
                }
            };

            _mockRepository
                .Setup(l => l.SelectAllTitles())
                .ReturnsAsync(titles);
            //Act
            var result = await _service.GetAllTitles();
            //Assert
            Assert.NotNull(result);
            Assert.IsType<List<TitleResponse>>(result);
            Assert.Equal(titles.Count, result.Count);
        }

        [Fact]
        public async void GetAllTitles_ShouldReturnEmptyListOfTitleyResponse_WhenNoTitlesExist()
        {
            //Arrange
            List<Title> titles = new();
            _mockRepository
                .Setup(l => l.SelectAllTitles())
                .ReturnsAsync(titles);
            //Act
            var result = await _service.GetAllTitles();
            //Assert
            Assert.NotNull(result);
            Assert.IsType<List<TitleResponse>>(result);
            Assert.Empty(result);
        }

        [Fact]
        public async void GetTitleById_ShouldReturnTitleResponse_WhenTheTitleyExist()
        {
            //Arrange
            int id = 1;
            Title title = new()
            {
                TitleId = id,
                Name = "elmer",
                LanguageId = 1,
                RYear = 1990,
                Pages = 300,
                PublisherId = 1,
                AuthorId = 1,
                GenreId = 1,
            };

            _mockRepository
                .Setup(x => x.SelectTitleById(It.IsAny<int>()))
                .ReturnsAsync(title);
            //Act
            var result = await _service.GetTitlesById(id);
            //Assert
            Assert.NotNull(result);
            Assert.IsType<TitleResponse>(result);
            Assert.Equal(id, result.TitleId);
        }

        [Fact]
        public async void GetTitleById_ShouldReturnNull_WhenTheTitleDoesNotExist()
        {
            //Arrange
            int id = 1;
            _mockRepository
                .Setup(x => x.SelectTitleById(It.IsAny<int>()))
                .ReturnsAsync(() => null);
            //Act
            var result = await _service.GetTitlesById(id);
            //Assert
            Assert.Null(result);
        }

        [Fact]
        public async void UpdateExistingTitle_ShouldReturnTitleResponse_WhenTheTitleIsUpdated()
        {
            //Arrange
            int id = 1;
            TitleRequest request = new()
            {                
                Name = "elmer",
                LanguageId = 1,
                RYear = 1990,
                Pages = 300,
                PublisherId = 1,
                GenreId = 1,
            };
            Title title = new()
            {
                TitleId = id,
                Name = "elmer",
                LanguageId = 1,
                RYear = 1990,
                Pages = 300,
                PublisherId = 1,
                AuthorId = 1,
                GenreId = 1,
            };

            _mockRepository
                .Setup(x => x.UpdateExistingTitle(It.IsAny<int>(), It.IsAny<Title>()))
                .ReturnsAsync(title);
            //Act
            var result = await _service.UpdateTitle(id, request);
            //Assert
            Assert.NotNull(result);
            Assert.IsType<TitleResponse>(result);
        }

        [Fact]
        public async void UpdateExistingTitle_ShouldReturnNull_WhenTheTitleIsNotUpdated()
        {
            //Arrange
            int id = 1;
            TitleRequest request = new()
            {
                Name = "elmer",
                LanguageId = 1,
                RYear = 1990,
                Pages = 300,
                PublisherId = 1,
                GenreId = 1,
            };

            _mockRepository
                .Setup(x => x.UpdateExistingTitle(It.IsAny<int>(), It.IsAny<Title>()))
                .ReturnsAsync(() => null);
            //Act
            var result = await _service.UpdateTitle(id, request);
            //Assert
            Assert.Null(result);
        }
    }
}
