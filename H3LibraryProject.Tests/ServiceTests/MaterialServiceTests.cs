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
    public class MaterialServiceTests
    {
        private readonly MaterialService _service;
        private readonly Mock<IMaterialRepository> _mockRepository = new();

        public MaterialServiceTests()
        {
            _service = new(_mockRepository.Object);
        }
        [Fact]
        public async void CreateMaterial_ShouldReturnNMaterialResponse_whenMaterialIsCreated()
        {
            //Arrange
            int id = 1;
            Material material = new()
            {
                MaterialId = id,
                TitleId = id,
            };
            MaterialRequest request = new()
            {
                TitleId = id,
            };

            _mockRepository
                .Setup(x => x.CreateMaterial(It.IsAny<Material>()))
                .ReturnsAsync(material);
            //Act
            var result = await _service.CreateMaterial(request);
            //Assert
            Assert.NotNull(result);
            Assert.IsType<MaterialResponse>(result);
        }


        [Fact]
        public async void CreateMaterial_ShouldReturnNull_WhenMaterialIsNotCreated()
        {
            //Arrange
            MaterialRequest request = new()
            {
                TitleId = 1
            };

            _mockRepository
                .Setup(x => x.CreateMaterial(It.IsAny<Material>()))
                .ReturnsAsync(() => null);
            //Act
            var result = await _service.CreateMaterial(request);
            //Assert
            Assert.Null(result);
        }

        [Fact]
        public async void DeleteMaterial_ShouldReturnMaterialResponse_WhenMaterialIsDeleted()
        {
            //Arrange
            int id = 1;
            Material material = new()
            {
                MaterialId = id,
                TitleId = id,
            };

            _mockRepository
                .Setup(x => x.DeleteMaterial(It.IsAny<int>()))
                .ReturnsAsync(material);
            //Act
            var result = await _service.DeleteMaterial(id);
            //Assert
            Assert.NotNull(result);
            Assert.IsType<MaterialResponse>(result);
            Assert.Equal(id, result.MaterialId);
        }

        [Fact]
        public async void DeleteMaterial_ShouldReturnNull_WhenMaterialIsNotDeleted()
        {
            //Arrange
            int id = 1;

            _mockRepository
                .Setup(x => x.DeleteMaterial(It.IsAny<int>()))
                .ReturnsAsync(() => null);

            //Act
            var result = await _service.DeleteMaterial(id);
            //Assert
            Assert.Null(result);
        }

        [Fact]
        public async void GetAllMaterials_ShouldReturnListOfMaterialResponse_WhenMaterialsExist()
        {
            //Arrange
            int id = 1;
            List<Material> materials = new()
            {
                new()
                {
                    MaterialId = id,
                    TitleId = id,
                    Home = true,
                    LocationId = id
                },
                new()
                {
                    MaterialId = id + 1,
                    TitleId = id + 2,
                    Home = true,
                    LocationId = id
                }
            };

            _mockRepository
                .Setup(l => l.GetAllMaterials())
                .ReturnsAsync(materials);
            //Act
            var result = await _service.GetAllMaterials();
            //Assert
            Assert.NotNull(result);
            Assert.IsType<List<MaterialResponse>>(result);
            Assert.Equal(materials.Count, result.Count);
        }

        [Fact]
        public async void GetAllMaterials_ShouldReturnEmptyListOfMaterialyResponse_WhenNoMaterialsExist()
        {
            //Arrange
            List<Material> materials = new();
            _mockRepository
                .Setup(l => l.GetAllMaterials())
                .ReturnsAsync(materials);
            //Act
            var result = await _service.GetAllMaterials();
            //Assert
            Assert.NotNull(result);
            Assert.IsType<List<MaterialResponse>>(result);
            Assert.Empty(result);
        }

        [Fact]
        public async void GetMaterialById_ShouldReturnMaterialyResponse_WhenTheMaterialyExist()
        {
            //Arrange
            int id = 1;
            Material material = new()
            {
                MaterialId = id,
                TitleId = id,
                Home = true,
                LocationId = id
            };

            _mockRepository
                .Setup(x => x.GetMaterialById(It.IsAny<int>()))
                .ReturnsAsync(material);
            //Act
            var result = await _service.GetMaterialById(id);
            //Assert
            Assert.NotNull(result);
            Assert.IsType<MaterialResponse>(result);
            Assert.Equal(id, result.MaterialId);
        }

        [Fact]
        public async void GetMaterialById_ShouldReturnNull_WhenTheMaterialDoesNotExist()
        {
            //Arrange
            int id = 1;
            _mockRepository
                .Setup(x => x.GetMaterialById(It.IsAny<int>()))
                .ReturnsAsync(() => null);
            //Act
            var result = await _service.GetMaterialById(id);
            //Assert
            Assert.Null(result);
        }

        [Fact]
        public async void UpdateMaterial_ShouldReturnMaterialResponse_WhenTheMaterialIsUpdated()
        {
            //Arrange
            int id = 1;
            MaterialRequest request = new()
            {
                TitleId = 1,
                Home = true,
                LocationId = id
            };
            Material material = new()
            {
                MaterialId = id,
                TitleId = 1,
                Home = true,
                LocationId = id
            };

            _mockRepository
                .Setup(x => x.UpdateMaterial(It.IsAny<int>(), It.IsAny<Material>()))
                .ReturnsAsync(material);
            //Act
            var result = await _service.UpdateMaterial(id, request);
            //Assert
            Assert.NotNull(result);
            Assert.IsType<MaterialResponse>(result);
        }

        [Fact]
        public async void UpdateMaterial_ShouldReturnNull_WhenTheMaterialIsNotUpdated()
        {
            //Arrange
            int id = 1;
            MaterialRequest request = new()
            {
                TitleId = id,
                Home = true,
                LocationId = id
            };

            _mockRepository
                .Setup(x => x.UpdateMaterial(It.IsAny<int>(), It.IsAny<Material>()))
                .ReturnsAsync(() => null);
            //Act
            var result = await _service.UpdateMaterial(id, request);
            //Assert
            Assert.Null(result);
        }
    }
}
