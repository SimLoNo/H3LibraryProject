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
    public class GenreServiceTests
    {
        private readonly GenreService _service;
        private readonly Mock<IGenreRepository> _mockRepository = new();


        public GenreServiceTests()
        {
            _service = new(_mockRepository.Object);
        }

        [Fact]
        public async void CreateGenre_ShouldReturnGenreResponse_whenGenreIsCreated()
        {
            //Arrange
            int id = 1;
            Genre genre = new()
            {
                GenreId = id,
                Name = "Test",
                LeasePeriod = 14
            };
            GenreRequest request = new()
            {
                Name = "Test",
                LeasePeriod = 14
            };

            _mockRepository
                .Setup(x => x.InsertNewGenre(It.IsAny<Genre>()))
                .ReturnsAsync(genre);
            //Act
            var result = await _service.CreateGenre(request);
            //Assert
            Assert.NotNull(result);
            Assert.IsType<GenreResponse>(result);
        }


        [Fact]
        public async void CreateGenre_ShouldReturnNull_WhenGenreIsNotCreated()
        {
            //Arrange
            GenreRequest request = new()
            {
                Name = "Test",
                LeasePeriod = 14
            };

            _mockRepository
                .Setup(x => x.InsertNewGenre(It.IsAny<Genre>()))
                .ReturnsAsync(() => null);
            //Act
            var result = await _service.CreateGenre(request);
            //Assert
            Assert.Null(result);
        }

        [Fact]
        public async void DeleteGenre_ShouldReturnGenreResponse_WhenGenreIsDeleted()
        {
            //Arrange
            int id = 1;
            Genre genre = new()
            {
                GenreId = id,
                Name = "Test",
                LeasePeriod = 14
            };

            _mockRepository
                .Setup(x => x.DeleteGenre(It.IsAny<int>()))
                .ReturnsAsync(genre);
            //Act
            var result = await _service.DeleteGenre(id);
            //Assert
            Assert.NotNull(result);
            Assert.IsType<GenreResponse>(result);
            Assert.Equal(id, result.GenreId);
        }

        [Fact]
        public async void DeleteGenre_ShouldReturnNull_WhenGenreIsNotDeleted()
        {
            //Arrange
            int id = 1;

            _mockRepository
                .Setup(x => x.DeleteGenre(It.IsAny<int>()))
                .ReturnsAsync(() => null);

            //Act
            var result = await _service.DeleteGenre(id);
            //Assert
            Assert.Null(result);
        }

        [Fact]
        public async void GetAllGenres_ShouldReturnListOfGenreResponse_WhenGenresExist()
        {
            //Arrange
            int id = 1;
            List<Genre> genres = new()
            {
                new()
                {
                    GenreId = id,
                    Name = "Test",
                    LeasePeriod = 14
                },
                new()
                {
                    GenreId = id+1,
                    Name = "Test",
                    LeasePeriod = 14
                }
            };

            _mockRepository
                .Setup(l => l.SelectAllGenres())
                .ReturnsAsync(genres);
            //Act
            var result = await _service.GetAllGenres();
            //Assert
            Assert.NotNull(result);
            Assert.IsType<List<GenreResponse>>(result);
            Assert.Equal(genres.Count, result.Count);
        }

        [Fact]
        public async void GetAllGenres_ShouldReturnEmptyListOfGenreResponse_WhenNoGenresExist()
        {
            //Arrange
            List<Genre> genres = new();
            _mockRepository
                .Setup(l => l.SelectAllGenres())
                .ReturnsAsync(genres);
            //Act
            var result = await _service.GetAllGenres();
            //Assert
            Assert.NotNull(result);
            Assert.IsType<List<GenreResponse>>(result);
            Assert.Empty(result);
        }

        [Fact]
        public async void GetGenresById_ShouldReturnGenreResponse_WhenTheGenreExist()
        {
            //Arrange
            int id = 1;
            Genre genre = new()
            {
                GenreId = id,
                Name = "Test",
                LeasePeriod = 14
            };

            _mockRepository
                .Setup(x => x.SelectGenreById(It.IsAny<int>()))
                .ReturnsAsync(genre);
            //Act
            var result = await _service.GetGenreById(id);
            //Assert
            Assert.NotNull(result);
            Assert.IsType<GenreResponse>(result);
            Assert.Equal(id, result.GenreId);
        }

        [Fact]
        public async void GetGenresById_ShouldReturnNull_WhenTheGenreDoesNotExist()
        {
            //Arrange
            int id = 1;
            _mockRepository
                .Setup(x => x.SelectGenreById(It.IsAny<int>()))
                .ReturnsAsync(() => null);
            //Act
            var result = await _service.GetGenreById(id);
            //Assert
            Assert.Null(result);
        }

        [Fact]
        public async void UpdateGenre_ShouldReturnGenreResponse_WhenTheGenreIsUpdated()
        {
            //Arrange
            int id = 1;
            GenreRequest request = new()
            {
                Name = "Test",
                LeasePeriod = 14
            };
            Genre genre = new()
            {
                GenreId = id,
                Name = "Test",
                LeasePeriod = 14
            };

            _mockRepository
                .Setup(x => x.UpdateExistingGenre(It.IsAny<int>(), It.IsAny<Genre>()))
                .ReturnsAsync(genre);
            //Act
            var result = await _service.UpdateGenre(id, request);
            //Assert
            Assert.NotNull(result);
            Assert.IsType<GenreResponse>(result);
        }

        [Fact]
        public async void UpdateGenre_ShouldReturnNull_WhenTheGenreIsNotUpdated()
        {
            //Arrange
            int id = 1;
            GenreRequest request = new()
            {
                Name = "Test",
                LeasePeriod = 14
            };

            _mockRepository
                .Setup(x => x.UpdateExistingGenre(It.IsAny<int>(), It.IsAny<Genre>()))
                .ReturnsAsync(() => null);
            //Act
            var result = await _service.UpdateGenre(id, request);
            //Assert
            Assert.Null(result);
        }
    }

}
