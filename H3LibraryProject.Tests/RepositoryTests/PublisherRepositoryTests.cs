using H3LibraryProject.Repositories.Database;
using H3LibraryProject.Repositories.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace H3LibraryProject.Tests.RepositoryTests
{
    public class PublisherRepositoryTests
    {
        private readonly DbContextOptions<LibraryContext> _options;
        private readonly LibraryContext _context;
        private readonly PublisherRepository _repository;

        public PublisherRepositoryTests()
        {
            _options = new DbContextOptionsBuilder<LibraryContext>()
                .UseInMemoryDatabase(databaseName: "LibraryProjectPublisher")
                .Options;
            _context = new(_options);

            _repository = new(_context);
        }

        [Fact]
        public async void GetAllPublishers_ShouldReturnListOfPublishers_WhenPublishersExist()
        {
            //Arrange
            int id = 1;
            List<Publisher> publisherList = new()
            {
                new()
                {
                    PublisherId = id,
                    Name = "Test"
                },
                new()
                {
                    PublisherId = id + 1,
                    Name = "Test"
                }
            };
            await _context.Database.EnsureDeletedAsync();
            foreach (Publisher item in publisherList)
            {
                _context.Publisher.Add(item);
            }
            await _context.SaveChangesAsync();

            //Act
            var result = await _repository.SelectAllPublishers();
            //assert
            Assert.NotNull(result);
            Assert.IsType<List<Publisher>>(result);
            Assert.Equal(publisherList.Count, result.Count);
        }
        [Fact]
        public async void GetAllPublishers_ShouldReturnEmptyListOfPublishers_WhenNoPublishersExist()
        {
            //Arrange
            await _context.Database.EnsureDeletedAsync();
            await _context.SaveChangesAsync();

            //Act
            var result = await _repository.SelectAllPublishers();
            //assert
            Assert.NotNull(result);
            Assert.IsType<List<Publisher>>(result);
            Assert.Empty(result);
        }

        [Fact]
        public async void GetPublisherById_ShouldReturnPublisher_WhenThePublisherExists()
        {
            //Arrange
            int id = 1;
            Publisher publisher = new()
            {
                PublisherId = id,
                Name = "Test"
            };
            await _context.Database.EnsureDeletedAsync();
            _context.Publisher.Add(publisher);
            await _context.SaveChangesAsync();

            //Act
            var result = await _repository.SelectPublisherById(id);
            //assert
            Assert.NotNull(result);
            Assert.IsType<Publisher>(result);
            Assert.Equal(id, result.PublisherId);
        }
        [Fact]
        public async void GetPublisherById_ShouldReturnNull_WhenThePublisherDoesNotExist()
        {
            //Arrange
            int id = 1;
            await _context.Database.EnsureDeletedAsync();
            await _context.SaveChangesAsync();

            //Act
            var result = await _repository.SelectPublisherById(id);
            //assert
            Assert.Null(result);
        }

        [Fact]
        public async void CreatePublisher_ShouldReturnError_WhenPublisherAlreadyExist()
        {
            //Arrange
            int id = 1;
            Publisher publisher = new()
            {
                PublisherId = id,
                Name = "Test"
            };

            await _context.Database.EnsureDeletedAsync();
            _context.Publisher.Add(publisher);
            await _context.SaveChangesAsync();

            //Act
            async Task action() => await _repository.InsertNewPublisher(publisher);
            //Assert
            var ex = await Assert.ThrowsAsync<ArgumentException>(action);
            Assert.Contains("An item with the same key has already been added", ex.Message);
        }

        [Fact]
        public async void CreatePublisherType_ShouldReturnPublisherType_WhenErrorIsNotFired()
        {
            //Arrange
            Publisher publisher = new()
            {
                PublisherId = 1,
                Name = "Test"
            };
            await _context.Database.EnsureDeletedAsync();

            //Act
            var result = await _repository.InsertNewPublisher(publisher);
            //Assert
            Assert.NotNull(result);
            Assert.IsType<Publisher>(result);
        }

        [Fact]
        public async void UpdatePublishere_ShouldReturnPublisher_WhenPublisherIsUpdated()
        {
            //Arrange
            int id = 1;
            Publisher publisher = new()
            {
                PublisherId = id,
                Name = "Test"
            };

            await _context.Database.EnsureDeletedAsync();
            _context.Publisher.Add(publisher);
            await _context.SaveChangesAsync();

            //Act
            var result = await _repository.UpdateExistingPublisher(id, publisher);
            //Assert
            Assert.NotNull(result);
            Assert.IsType<Publisher>(result);
        }

        [Fact]
        public async void UpdatePublisher_ShouldReturnNull_WhenNoPublisherIsUpdated()
        {
            //Arrange
            int id = 1;
            Publisher publisher = new()
            {
                PublisherId = id,
                Name = "Test"
            };

            await _context.Database.EnsureDeletedAsync();
            await _context.SaveChangesAsync();

            //Act
            var result = await _repository.UpdateExistingPublisher(id, publisher);
            //Assert
            Assert.Null(result);
        }

        [Fact]
        public async void DeletePublishere_ShouldReturnNull_WhenNoPublisherIsDeleted()
        {
            //Arrange
            int id = 1;
            await _context.Database.EnsureDeletedAsync();
            await _context.SaveChangesAsync();
            //Act
            var result = await _repository.DeletePublisherById(id);
            //Assert
            Assert.Null(result);
        }

        [Fact]
        public async void DeletePublisher_ShouldReturnPublisher_WhenPublisherIsDeleted()
        {
            //Arrange
            int id = 1;
            Publisher publisher = new()
            {
                PublisherId = id,
                Name = "Test"


            };

            await _context.Database.EnsureDeletedAsync();
            _context.Publisher.Add(publisher);
            await _context.SaveChangesAsync();
            //Act
            var result = await _repository.DeletePublisherById(id);
            //Assert
            Assert.NotNull(result);
            Assert.IsType<Publisher>(result);
            Assert.Equal(id, result.PublisherId);

        }
    }
}
