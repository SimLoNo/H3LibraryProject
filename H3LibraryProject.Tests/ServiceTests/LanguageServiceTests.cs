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
    public class LanguageServiceTests
    {
            private readonly LanguageService _service;
            private readonly Mock<ILanguageRepository> _mockRepository = new();

            public LanguageServiceTests()
            {
                _service = new(_mockRepository.Object);
            }

            [Fact]
            public async void CreateLanguage_ShouldReturnLanguageResponse_whenLanguageIsCreated()
            {
                //Arrange
                int id = 1;
                Language language = new()
                {
                    LanguageId = id,
                    Name = "Test"
                };
                LanguageRequest request = new()
                {
                    Name = "Test",
                };

                _mockRepository
                    .Setup(x => x.InsertNewLanguage(It.IsAny<Language>()))
                    .ReturnsAsync(language);
                //Act
                var result = await _service.CreateLanguage(request);
                //Assert
                Assert.NotNull(result);
                Assert.IsType<LanguageResponse>(result);
            }


            [Fact]
            public async void CreateLanguage_ShouldReturnNull_WhenLanguageIsNotCreated()
            {
                //Arrange
                LanguageRequest request = new()
                {
                    Name = "Test",
                };

                _mockRepository
                    .Setup(x => x.InsertNewLanguage(It.IsAny<Language>()))
                    .ReturnsAsync(() => null);
                //Act
                var result = await _service.CreateLanguage(request);
                //Assert
                Assert.Null(result);
            }

            [Fact]
            public async void DeleteLanguage_ShouldReturnLanguageResponse_WhenLanguageIsDeleted()
            {
                //Arrange
                int id = 1;
                Language language = new()
                {
                    LanguageId = id,
                    Name = "Test"
                };

                _mockRepository
                    .Setup(x => x.DeleteLanguage(It.IsAny<int>()))
                    .ReturnsAsync(language);
                //Act
                var result = await _service.DeleteLanguage(id);
                //Assert
                Assert.NotNull(result);
                Assert.IsType<LanguageResponse>(result);
                Assert.Equal(id, result.LanguageId);
            }

            [Fact]
            public async void DeleteLanguage_ShouldReturnNull_WhenLanguageIsNotDeleted()
            {
                //Arrange
                int id = 1;

                _mockRepository
                    .Setup(x => x.DeleteLanguage(It.IsAny<int>()))
                    .ReturnsAsync(() => null);

                //Act
                var result = await _service.DeleteLanguage(id);
                //Assert
                Assert.Null(result);
            }

            [Fact]
            public async void GetAllLanguages_ShouldReturnListOfLanguageResponse_WhenLanguagesExist()
            {
            //Arrange
            int id = 1;
            List<Language> languages = new()
            {
                    new()
                    {
                        LanguageId = id,
                        Name = "Test"
                    },
                    new()
                    {
                        LanguageId = id+1,
                        Name = "Test"
                    }
                };

                _mockRepository
                    .Setup(l => l.SelectAllLanguages())
                    .ReturnsAsync(languages);
                //Act
                var result = await _service.GetAllLanguages();
                //Assert
                Assert.NotNull(result);
                Assert.IsType<List<LanguageResponse>>(result);
                Assert.Equal(languages.Count, result.Count);
            }

            [Fact]
            public async void GetAllLanguages_ShouldReturnEmptyListOfLanguageResponse_WhenNoLanguagesExist()
            {
                //Arrange
                List<Language> languages = new();
                _mockRepository
                    .Setup(l => l.SelectAllLanguages())
                    .ReturnsAsync(languages);
                //Act
                var result = await _service.GetAllLanguages();
                //Assert
                Assert.NotNull(result);
                Assert.IsType<List<LanguageResponse>>(result);
                Assert.Empty(result);
            }

            [Fact]
            public async void GetLanguagesById_ShouldReturnLanguageResponse_WhenTheLanguageExist()
            {
                //Arrange
                int id = 1;
                Language language = new()
                {
                    LanguageId = id,
                    Name = "Test"
                };

                _mockRepository
                    .Setup(x => x.SelectLanguageById(It.IsAny<int>()))
                    .ReturnsAsync(language);
                //Act
                var result = await _service.GetLanguageById(id);
                //Assert
                Assert.NotNull(result);
                Assert.IsType<LanguageResponse>(result);
                Assert.Equal(id, result.LanguageId);
            }

            [Fact]
            public async void GetLanguagesById_ShouldReturnNull_WhenTheLanguageDoesNotExist()
            {
                //Arrange
                int id = 1;
                _mockRepository
                    .Setup(x => x.SelectLanguageById(It.IsAny<int>()))
                    .ReturnsAsync(() => null);
                //Act
                var result = await _service.GetLanguageById(id);
                //Assert
                Assert.Null(result);
            }

            [Fact]
            public async void UpdateLanguage_ShouldReturnLanguageResponse_WhenTheLanguageIsUpdated()
            {
                //Arrange
                int id = 1;
                LanguageRequest request = new()
                {
                    Name = "Test",
                };
                Language language = new()
                {
                    LanguageId = id,
                    Name = "Test"
                };

                _mockRepository
                    .Setup(x => x.UpdateExistingLanguage(It.IsAny<int>(), It.IsAny<Language>()))
                    .ReturnsAsync(language);
                //Act
                var result = await _service.UpdateLanguage(id, request);
                //Assert
                Assert.NotNull(result);
                Assert.IsType<LanguageResponse>(result);
            }

            [Fact]
            public async void UpdateLanguage_ShouldReturnNull_WhenTheLanguageIsNotUpdated()
            {
                //Arrange
                int id = 1;
                LanguageRequest request = new()
                {
                    Name = "Test",
                };

                _mockRepository
                    .Setup(x => x.UpdateExistingLanguage(It.IsAny<int>(), It.IsAny<Language>()))
                    .ReturnsAsync(() => null);
                //Act
                var result = await _service.UpdateLanguage(id, request);
                //Assert
                Assert.Null(result);
            }
        }
}
