//using H3LibraryProject.Repositories.Database;
//using H3LibraryProject.Repositories.Repositories;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Xunit;

//namespace H3LibraryProject.Tests.RepositoryTests
//{
//    public class LanguageRepositoryTests
//    {
//            private readonly DbContextOptions<LibraryContext> _options;
//            private readonly LibraryContext _context;
//            private readonly LanguageRepository _repository;

//            public LanguageRepositoryTests()
//            {
//                _options = new DbContextOptionsBuilder<LibraryContext>()
//                    .UseInMemoryDatabase(databaseName: "LibraryProjectLanguage")
//                    .Options;
//                _context = new(_options);

//                _repository = new(_context);
//            }

//            [Fact]
//            public async void GetAllLanguages_ShouldReturnListOfLanguages_WhenLanguagesExist()
//            {
//                //Arrange
//                int id = 1;
//                List<Language> languageList = new()
//                {
//                    new()
//                    {
//                        LanguageId = id,
//                        Name = "Test"
//                    },
//                    new()
//                    {
//                        LanguageId = id + 1,
//                        Name = "Test"
//                    }
//                };
//                Language languageType = new() { LanguageId = 1, Name = "Test" };
//                await _context.Database.EnsureDeletedAsync();
//                foreach (Language item in languageList)
//                {
//                    _context.Language.Add(item);
//                }
//                _context.Language.Add(languageType);
//                await _context.SaveChangesAsync();

//                //Act
//                var result = await _repository.SelectAllLanguages();
//                //assert
//                Assert.NotNull(result);
//                Assert.IsType<List<Language>>(result);
//                Assert.Equal(languageList.Count, result.Count);
//            }
//            [Fact]
//            public async void GetAllLanguages_ShouldReturnEmptyListOfLanguages_WhenNoLanguagesExist()
//            {
//                //Arrange
//                await _context.Database.EnsureDeletedAsync();
//                await _context.SaveChangesAsync();

//                //Act
//                var result = await _repository.SelectAllLanguages();
//                //assert
//                Assert.NotNull(result);
//                Assert.IsType<List<Language>>(result);
//                Assert.Empty(result);
//            }

//            [Fact]
//            public async void GetLanguageById_ShouldReturnLanguage_WhenTheLanguageExists()
//            {
//                //Arrange
//                int id = 1;
//                Language language = new()
//                {
//                    LanguageId = id,
//                    Name = "Test"
//                };
//                await _context.Database.EnsureDeletedAsync();
//                _context.Language.Add(language);
//                await _context.SaveChangesAsync();

//                //Act
//                var result = await _repository.SelectLanguageById(id);
//                //assert
//                Assert.NotNull(result);
//                Assert.IsType<Language>(result);
//                Assert.Equal(id, result.LanguageId);
//            }
//            [Fact]
//            public async void GetLanguageById_ShouldReturnNull_WhenTheLanguageDoesNotExist()
//            {
//                //Arrange
//                int id = 1;
//                await _context.Database.EnsureDeletedAsync();
//                await _context.SaveChangesAsync();

//                //Act
//                var result = await _repository.SelectLanguageById(id);
//                //assert
//                Assert.Null(result);
//            }

//            [Fact]
//            public async void CreateLanguage_ShouldReturnError_WhenLanguageAlreadyExist()
//            {
//                //Arrange
//                int id = 1;
//                Language language = new()
//                {
//                    LanguageId = id,
//                    Name = "Test"
//                };

//                await _context.Database.EnsureDeletedAsync();
//                _context.Language.Add(language);
//                await _context.SaveChangesAsync();

//                //Act
//                async Task action() => await _repository.InsertNewLanguage(language);
//                //Assert
//                var ex = await Assert.ThrowsAsync<ArgumentException>(action);
//                Assert.Contains("An item with the same key has already been added", ex.Message);
//            }

//            [Fact]
//            public async void CreateLanguageType_ShouldReturnLanguageType_WhenErrorIsNotFired()
//            {
//                //Arrange
//                Language language = new()
//                {
//                    LanguageId = 1,
//                    Name = "Test",
//                    Password = "Passw0rd"
//                };
//                await _context.Database.EnsureDeletedAsync();

//                //Act
//                var result = await _repository.CreateLanguage(language);
//                //Assert
//                Assert.NotNull(result);
//                Assert.IsType<Language>(result);
//            }

//            [Fact]
//            public async void UpdateLanguagee_ShouldReturnLanguage_WhenLanguageIsUpdated()
//            {
//                //Arrange
//                int id = 1;
//                string newName = "New name!";
//                Language language = new()
//                {
//                    LanguageTypeId = id,
//                    Name = "Test",
//                    Password = "Passw0rd"
//                };
//                LanguageType languageType = new()
//                {
//                    LanguageTypeId = id,
//                    Name = "Test",
//                };

//                await _context.Database.EnsureDeletedAsync();
//                _context.Language.Add(language);
//                _context.LanguageTypes.Add(languageType);
//                await _context.SaveChangesAsync();

//                language.Name = newName;
//                //Act
//                var result = await _repository.UpdateLanguage(id, language);
//                //Assert
//                Assert.NotNull(result);
//                Assert.IsType<Language>(result);
//                Assert.Equal(newName, result.Name);
//            }

//            [Fact]
//            public async void UpdateLanguage_ShouldReturnNull_WhenNoLanguageIsUpdated()
//            {
//                //Arrange
//                int id = 1;
//                Language language = new()
//                {
//                    LanguageId = id,
//                    LanguageTypeId = 1,
//                    Name = "Test",
//                    Password = "Passw0rd"
//                };

//                await _context.Database.EnsureDeletedAsync();
//                await _context.SaveChangesAsync();

//                //Act
//                var result = await _repository.UpdateLanguage(id, language);
//                //Assert
//                Assert.Null(result);
//            }

//            [Fact]
//            public async void DeleteLanguagee_ShouldReturnNull_WhenNoLanguageIsDeleted()
//            {
//                //Arrange
//                int id = 1;
//                await _context.Database.EnsureDeletedAsync();
//                await _context.SaveChangesAsync();
//                //Act
//                var result = await _repository.DeleteLanguage(id);
//                //Assert
//                Assert.Null(result);
//            }

//            [Fact]
//            public async void DeleteLanguage_ShouldReturnLanguage_WhenLanguageIsDeleted()
//            {
//                //Arrange
//                int id = 1;
//                Language language = new()
//                {
//                    LanguageId = id,
//                    LanguageTypeId = id,
//                    Name = "Test",
//                    Password = "Passw0rd"
//                };
//                LanguageType languageType = new()
//                {
//                    LanguageTypeId = id,
//                    Name = "Test"
//                };

//                await _context.Database.EnsureDeletedAsync();
//                _context.Language.Add(language);
//                _context.LanguageTypes.Add(languageType);
//                await _context.SaveChangesAsync();
//                //Act
//                var result = await _repository.DeleteLanguage(id);
//                //Assert
//                Assert.NotNull(result);
//                Assert.IsType<Language>(result);
//                Assert.Equal(id, result.LanguageTypeId);

//            }
//        }
//}
