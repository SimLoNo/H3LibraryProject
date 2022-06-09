using H3LibraryProject.API.Controllers;
using H3LibraryProject.API.DTOs;
using H3LibraryProject.Repositories.Database;
using H3LibraryProject.Services.Services;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Moq;//Gætværk
using System;
using System.Collections.Generic;
using Xunit;

namespace H3LibraryProject.Tests.ControllerTests
{
    public class MaterialControllerTests
    {
        private readonly MaterialController _controller;
        private readonly Mock<IMaterialService> _MaterialServiceMock = new();

        public MaterialControllerTests()
        {
            _controller = new(_MaterialServiceMock.Object);
        }

            //Create
            [Fact]
            public async void Create_ShouldReturnStatusCode200_WhenMaterialIsSuccessfullyCreated()
            {
                //Arrange
                MaterialRequest newMaterial = new()
                {                   
                    Home = true,
                    TitleId = 1965,
                    LocationId = 3
                }; 

                int MaterialId = 1;

                MaterialResponse MaterialResponse = new()
                {
                    MaterialId = MaterialId,
                    Home = true,
                    TitleId = 1965,
                    LocationId = 3
                };

                _MaterialServiceMock
                    .Setup(x => x.CreateMaterial(It.IsAny<MaterialRequest>()))
                    .ReturnsAsync(MaterialResponse);

                //Act
                var result = await _controller.CreateMaterial(newMaterial);

                //Assert
                var statusCodeResult = (IStatusCodeActionResult)result;
                Assert.Equal(200, statusCodeResult.StatusCode);
            }
            [Fact]
            public async void Create_ShouldReturnStatusCode500_WhenExceptionIsRaised()
            {
                //Arrange
                //Arrange
                MaterialRequest newMaterial = new()
                {
                    Home = true,
                    TitleId = 1965,
                    LocationId = 3
                };


                _MaterialServiceMock
                    .Setup(x => x.CreateMaterial(It.IsAny<MaterialRequest>()))
                    .ReturnsAsync(() => throw new System.Exception("Dette er en undtagelse, compadré!"));

                //Act
                var result = await _controller.CreateMaterial(newMaterial);

                //Assert
                var statusCodeResult = (IStatusCodeActionResult)result;
                Assert.Equal(500, statusCodeResult.StatusCode);
            }

            //Read

            //- ById
            [Fact]
            public async void GetById_ShouldReturnStatusCode200_WhenDataExists()
            {
                //Arrange
                int MaterialId = 1;

                MaterialResponse Material = new()
                {
                    MaterialId = MaterialId,
                    Home = true,
                    TitleId = 1965,
                    LocationId = 3
                };

                _MaterialServiceMock
                    .Setup(x => x.GetMaterialById(It.IsAny<int>()))
                    .ReturnsAsync(Material);

                //Act
                var result = await _controller.GetMaterialById(MaterialId);

                //Assert
                var statusCodeResult = (IStatusCodeActionResult)result;
                Assert.Equal(200, statusCodeResult.StatusCode);
            }
        [Fact]
        public async void GetById_ShouldReturnStatusCode404_WhenAuthorDoesNotExist()
        {
            //Arrange 
            int TitleId = 1;

            _MaterialServiceMock.
               Setup(x => x.GetMaterialById(It.IsAny<int>())).
               ReturnsAsync(() => null);

            //Act
            var result = await _controller.GetMaterialById(TitleId);

            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(404, statusCodeResult.StatusCode);
        }

        [Fact]
        public async void GetById_ShouldReturnStatusCode500_WhenExceptionIsRaised()
        {
            //Arrange 
            _MaterialServiceMock.
               Setup(x => x.GetMaterialById(It.IsAny<int>())).
               ReturnsAsync(() => throw new System.Exception("Dette er en undtagelse."));

            //Act
            var result = await _controller.GetMaterialById(1);

            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(500, statusCodeResult.StatusCode);
        }
        //- All
        [Fact]
        public async void GetAll_ShouldReturnStatusCode200_WhenAuthorsExists()
        {
            //Arrange
            List<MaterialResponse> Materials = new();

            Materials.Add(new()
            {
                MaterialId = 1,
                Home = true,
                TitleId = 1965,
                LocationId = 3,
                Loans = new(),
                Title = new(),
                Location = new()
            });

            
            Materials.Add(new()
            {
                MaterialId = 2,
                Home = true,
                TitleId = 1965,
                LocationId = 3,
                Loans = new(),
                Title = new(),
                Location = new()
            });

            _MaterialServiceMock
                .Setup(x => x.GetAllMaterials())
                .ReturnsAsync(Materials); //Manglede Async LOL

            //Act
            var result = await _controller.GetAllMaterials();

            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(200, statusCodeResult.StatusCode);
        }
        [Fact]
        public async void GetAll_ShouldReturnStatusCode204_WhenNoAuthorsExists()
        {
            //Arrange
            List<MaterialResponse> Materials = new();


            _MaterialServiceMock
                .Setup(x => x.GetAllMaterials())
                .ReturnsAsync(Materials);

            //Act
            var result = await _controller.GetAllMaterials();

            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(204, statusCodeResult.StatusCode);
        }
        [Fact]
        public async void GetAll_ShouldReturnStatusCode500_WhenNullIsReturnedFromService()
        {
            //Arrange

            _MaterialServiceMock
                .Setup(x => x.GetAllMaterials())
                .ReturnsAsync(() => null); //man kan ikke bare lave en .Returns(null); - man skal give den en metode, der returnerer null.

            //Act
            var result = await _controller.GetAllMaterials();

            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(500, statusCodeResult.StatusCode);
        }
        [Fact]
        public async void GetAll_ShouldReturnStatusCode500_WhenExceptionIsRaised()
        {
            //Arrange

            _MaterialServiceMock
                .Setup(x => x.GetAllMaterials())
                .ReturnsAsync(() => throw new Exception("This is an exception"));
            //man kan ikke bare lave en .Returns(null); - man skal give den en metode, der returnerer null.

            //Act
            var result = await _controller.GetAllMaterials();

            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(500, statusCodeResult.StatusCode);
        }

        //Update
        [Fact]
        public async void Update_ShouldReturnStatusCode200_WhenAuthorIsSuccessfullyUpdated()
        {
            //Arrange
            MaterialRequest updateMaterial = new()
            {
                Home = true,
                TitleId = 1965,
                LocationId = 3
            }; ;

            int MaterialId = 1;

            MaterialResponse authorResponse = new()
            {
                MaterialId = 1,
                Home = true,
                TitleId = 1965,
                LocationId = 3
            };

            _MaterialServiceMock
                .Setup(x => x.UpdateMaterial(It.IsAny<int>(), It.IsAny<MaterialRequest>()))
                .ReturnsAsync(authorResponse);

            //Act
            var result = await _controller.UpdateMaterial(MaterialId, updateMaterial);

            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(200, statusCodeResult.StatusCode);
        }
        [Fact]
        public async void Update_ShouldReturnStatusCode404_WhenTryingToUpdateAuthorWhichDoesNotExist()

        {
            //Arrange
            MaterialRequest updateMaterial = new()
            {
                Home = true,
                TitleId = 1965,
                LocationId = 3
            }; ;

            int MaterialId = 1;


            _MaterialServiceMock
                .Setup(x => x.UpdateMaterial(It.IsAny<int>(), It.IsAny<MaterialRequest>()))
                .ReturnsAsync(() => null);

            //Act
            var result = await _controller.UpdateMaterial(MaterialId, updateMaterial);

            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(404, statusCodeResult.StatusCode);
        }
        [Fact]
        public async void Update_ShouldReturnStatusCode500_WhenExceptionIsRaised()

        {
            //Arrange
            MaterialRequest updateMaterial = new()
            {
                Home = true,
                TitleId = 1965,
                LocationId = 3
            }; ;

            int MaterialId = 1;


            _MaterialServiceMock
                .Setup(x => x.UpdateMaterial(It.IsAny<int>(), It.IsAny<MaterialRequest>()))
                .ReturnsAsync(() => throw new System.Exception("Dette er en undtagelse, Tovarisch"));

            //Act
            var result = await _controller.UpdateMaterial(MaterialId, updateMaterial);

            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(500, statusCodeResult.StatusCode);
        }

        //Delete
        [Fact]
        public async void Delete_ShouldReturnStatusCode200_WhenAookIsDeleted()
        {
            //Arrange
            int MaterialId = 1;

            MaterialResponse MaterialResponse = new()
            {
                Home = true,
                TitleId = 1965,
                LocationId = 3
            };

            _MaterialServiceMock
                .Setup(x => x.DeleteMaterial(It.IsAny<int>()))
                .ReturnsAsync(MaterialResponse);

            //Act
            var result = await _controller.DeleteMaterial(MaterialId);

            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(200, statusCodeResult.StatusCode);
        }
        [Fact]
        public async void Delete_ShouldReturnStatusCode404_WhenTryingToDeleteAookWhichDoesNotExist()
        {
            //Arrange
            int aookId = 1;


            _MaterialServiceMock
                .Setup(x => x.DeleteMaterial(It.IsAny<int>()))
                .ReturnsAsync(() => null);

            //Act
            var result = await _controller.DeleteMaterial(aookId);

            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(404, statusCodeResult.StatusCode);
        }
        [Fact]
        public async void Delete_ShouldReturnStatusCode500_WhenExceptionIsRaised()
        {
            //Arrange
            int aookId = 1;


            _MaterialServiceMock
                .Setup(x => x.DeleteMaterial(It.IsAny<int>()))
                .ReturnsAsync(() => throw new System.Exception("Undtagelsestilstand, beltalowda!"));

            //Act
            var result = await _controller.DeleteMaterial(aookId);

            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(500, statusCodeResult.StatusCode);
        }
    }
}
