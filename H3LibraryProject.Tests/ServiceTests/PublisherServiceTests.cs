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
    public class PublisherServiceTests
    {
        private readonly PublisherService _service;
            private readonly Mock<IPublisherRepository> _mockRepository = new();

            public PublisherServiceTests()
            {
                _service = new(_mockRepository.Object);
            }

            [Fact]
            public async void CreatePublisher_ShouldReturnPublisherResponse_whenPublisherIsCreated()
            {
                //Arrange
                int id = 1;
                Publisher publisher = new()
                {
                    PublisherId = id,
                    Name = "Test"
                };
                PublisherRequest request = new()
                {
                    Name = "Test",
                };

                _mockRepository
                    .Setup(x => x.InsertNewPublisher(It.IsAny<Publisher>()))
                    .ReturnsAsync(publisher);
                //Act
                var result = await _service.CreatePublisher(request);
                //Assert
                Assert.NotNull(result);
                Assert.IsType<PublisherResponse>(result);
            }


            [Fact]
            public async void CreatePublisher_ShouldReturnNull_WhenPublisherIsNotCreated()
            {
                //Arrange
                PublisherRequest request = new()
                {
                    Name = "Test",
                };

                _mockRepository
                    .Setup(x => x.InsertNewPublisher(It.IsAny<Publisher>()))
                    .ReturnsAsync(() => null);
                //Act
                var result = await _service.CreatePublisher(request);
                //Assert
                Assert.Null(result);
            }

            [Fact]
            public async void DeletePublisher_ShouldReturnPublisherResponse_WhenPublisherIsDeleted()
            {
                //Arrange
                int id = 1;
                Publisher publisher = new()
                {
                    PublisherId = id,
                    Name = "Test"
                };

                _mockRepository
                    .Setup(x => x.DeletePublisherById(It.IsAny<int>()))
                    .ReturnsAsync(publisher);
                //Act
                var result = await _service.DeletePublisher(id);
                //Assert
                Assert.NotNull(result);
                Assert.IsType<PublisherResponse>(result);
                Assert.Equal(id, result.PublisherId);
            }

            [Fact]
            public async void DeletePublisher_ShouldReturnNull_WhenPublisherIsNotDeleted()
            {
                //Arrange
                int id = 1;

                _mockRepository
                    .Setup(x => x.DeletePublisherById(It.IsAny<int>()))
                    .ReturnsAsync(() => null);

                //Act
                var result = await _service.DeletePublisher(id);
                //Assert
                Assert.Null(result);
            }

            [Fact]
            public async void GetAllPublishers_ShouldReturnListOfPublisherResponse_WhenPublishersExist()
            {
            //Arrange
            int id = 1;
            List<Publisher> publishers = new()
            {
                    new()
                    {
                        PublisherId = id,
                        Name = "Test"
                    },
                    new()
                    {
                        PublisherId = id+1,
                        Name = "Test"
                    }
                };

                _mockRepository
                    .Setup(l => l.SelectAllPublishers())
                    .ReturnsAsync(publishers);
                //Act
                var result = await _service.GetAllPublishers();
                //Assert
                Assert.NotNull(result);
                Assert.IsType<List<PublisherResponse>>(result);
                Assert.Equal(publishers.Count, result.Count);
            }

            [Fact]
            public async void GetAllPublishers_ShouldReturnEmptyListOfPublisherResponse_WhenNoPublishersExist()
            {
                //Arrange
                List<Publisher> publishers = new();
                _mockRepository
                    .Setup(l => l.SelectAllPublishers())
                    .ReturnsAsync(publishers);
                //Act
                var result = await _service.GetAllPublishers();
                //Assert
                Assert.NotNull(result);
                Assert.IsType<List<PublisherResponse>>(result);
                Assert.Empty(result);
            }

            [Fact]
            public async void GetPublishersById_ShouldReturnPublisherResponse_WhenThePublisherExist()
            {
                //Arrange
                int id = 1;
                Publisher publisher = new()
                {
                    PublisherId = id,
                    Name = "Test"
                };

                _mockRepository
                    .Setup(x => x.SelectPublisherById(It.IsAny<int>()))
                    .ReturnsAsync(publisher);
                //Act
                var result = await _service.GetPublisherById(id);
                //Assert
                Assert.NotNull(result);
                Assert.IsType<PublisherResponse>(result);
                Assert.Equal(id, result.PublisherId);
            }

            [Fact]
            public async void GetPublishersById_ShouldReturnNull_WhenThePublisherDoesNotExist()
            {
                //Arrange
                int id = 1;
                _mockRepository
                    .Setup(x => x.SelectPublisherById(It.IsAny<int>()))
                    .ReturnsAsync(() => null);
                //Act
                var result = await _service.GetPublisherById(id);
                //Assert
                Assert.Null(result);
            }

            [Fact]
            public async void UpdatePublisher_ShouldReturnPublisherResponse_WhenThePublisherIsUpdated()
            {
                //Arrange
                int id = 1;
                PublisherRequest request = new()
                {
                    Name = "Test",
                };
                Publisher publisher = new()
                {
                    PublisherId = id,
                    Name = "Test"
                };

                _mockRepository
                    .Setup(x => x.UpdateExistingPublisher(It.IsAny<int>(), It.IsAny<Publisher>()))
                    .ReturnsAsync(publisher);
                //Act
                var result = await _service.UpdatePublisher(id, request);
                //Assert
                Assert.NotNull(result);
                Assert.IsType<PublisherResponse>(result);
            }

            [Fact]
            public async void UpdatePublisher_ShouldReturnNull_WhenThePublisherIsNotUpdated()
            {
                //Arrange
                int id = 1;
                PublisherRequest request = new()
                {
                    Name = "Test",
                };

                _mockRepository
                    .Setup(x => x.UpdateExistingPublisher(It.IsAny<int>(), It.IsAny<Publisher>()))
                    .ReturnsAsync(() => null);
                //Act
                var result = await _service.UpdatePublisher(id, request);
                //Assert
                Assert.Null(result);
            }
    }
}
