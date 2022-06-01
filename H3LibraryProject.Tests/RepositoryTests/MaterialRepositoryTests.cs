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
    public class MaterialRepositoryTests
    {
        private readonly DbContextOptions<LibraryContext> _options;
        private readonly LibraryContext _context;
        private readonly MaterialRepository _repository;

        public MaterialRepositoryTests()
        {
            _options = new DbContextOptionsBuilder<LibraryContext>()
                .UseInMemoryDatabase(databaseName: "LibraryProjectMaterial")
                .Options;
            _context = new(_options);

            _repository = new(_context);
        }

        [Fact]
        public async void GetAllMaterials_ShouldReturnListOfMaterials_WhenMaterialsExist()
        {
            //Arrange
            int id = 1;
            List<Material> materialList = new()
            {
                new()
                {
                    MaterialId = id,
                    TitleId = id,
                    LocationId = id,
                    Home = false
                },
                new()
                {
                    MaterialId = id + 1,
                    TitleId = id,
                    LocationId = id,
                    Home = false
                }
            };
            await _context.Database.EnsureDeletedAsync();
            foreach (Material item in materialList)
            {
                _context.Material.Add(item);
            }
            await _context.SaveChangesAsync();

            //Act
            var result = await _repository.SelectAllMaterials();
            //assert
            Assert.NotNull(result);
            Assert.IsType<List<Material>>(result);
            Assert.Equal(materialList.Count, result.Count);
        }
        [Fact]
        public async void GetAllMaterials_ShouldReturnEmptyListOfMaterials_WhenNoMaterialsExist()
        {
            //Arrange
            await _context.Database.EnsureDeletedAsync();
            await _context.SaveChangesAsync();

            //Act
            var result = await _repository.SelectAllMaterials();
            //assert
            Assert.NotNull(result);
            Assert.IsType<List<Material>>(result);
            Assert.Empty(result);
        }

        [Fact]
        public async void GetMaterialById_ShouldReturnMaterial_WhenTheMaterialExists()
        {
            //Arrange
            int id = 1;
            Material material = new()
            {
                MaterialId = id,
                TitleId = id,
                LocationId = id,
                Home = false
            };
            await _context.Database.EnsureDeletedAsync();
            _context.Material.Add(material);
            await _context.SaveChangesAsync();

            //Act
            var result = await _repository.SelectMaterialById(id);
            //assert
            Assert.NotNull(result);
            Assert.IsType<Material>(result);
            Assert.Equal(id, result.MaterialId);
        }
        [Fact]
        public async void GetMaterialById_ShouldReturnNull_WhenTheMaterialDoesNotExist()
        {
            //Arrange
            int id = 1;
            await _context.Database.EnsureDeletedAsync();
            await _context.SaveChangesAsync();

            //Act
            var result = await _repository.SelectMaterialById(id);
            //assert
            Assert.Null(result);
        }

        [Fact]
        public async void CreateMaterial_ShouldReturnError_WhenMaterialAlreadyExist()
        {
            //Arrange
            int id = 1;
            Material material = new()
            {
                MaterialId = id,
                TitleId = id,
                LocationId = id,
                Home = false
            };

            await _context.Database.EnsureDeletedAsync();
            _context.Material.Add(material);
            await _context.SaveChangesAsync();

            //Act
            async Task action() => await _repository.InsertNewMaterial(material);
            //Assert
            var ex = await Assert.ThrowsAsync<ArgumentException>(action);
            Assert.Contains("An item with the same key has already been added", ex.Message);
        }

        [Fact]
        public async void CreateMaterialType_ShouldReturnMaterialType_WhenErrorIsNotFired()
        {
            //Arrange
            Material material = new()
            {
                MaterialId = 1,
                TitleId = 1,
                LocationId = 1,
                Home = false
            };
            await _context.Database.EnsureDeletedAsync();

            //Act
            var result = await _repository.InsertNewMaterial(material);
            //Assert
            Assert.NotNull(result);
            Assert.IsType<Material>(result);
        }

        [Fact]
        public async void UpdateMateriale_ShouldReturnMaterial_WhenMaterialIsUpdated()
        {
            //Arrange
            int id = 1;
            Material material = new()
            {
                MaterialId = id,
                TitleId = id,
                LocationId = id,
                Home = false
            };

            await _context.Database.EnsureDeletedAsync();
            _context.Material.Add(material);
            await _context.SaveChangesAsync();

            //Act
            var result = await _repository.UpdateExistingMaterial(id, material);
            //Assert
            Assert.NotNull(result);
            Assert.IsType<Material>(result);
        }

        [Fact]
        public async void UpdateMaterial_ShouldReturnNull_WhenNoMaterialIsUpdated()
        {
            //Arrange
            int id = 1;
            Material material = new()
            {
                MaterialId = id,
                TitleId = id,
                LocationId = id,
                Home = false
            };

            await _context.Database.EnsureDeletedAsync();
            await _context.SaveChangesAsync();

            //Act
            var result = await _repository.UpdateExistingMaterial(id, material);
            //Assert
            Assert.Null(result);
        }

        [Fact]
        public async void DeleteMateriale_ShouldReturnNull_WhenNoMaterialIsDeleted()
        {
            //Arrange
            int id = 1;
            await _context.Database.EnsureDeletedAsync();
            await _context.SaveChangesAsync();
            //Act
            var result = await _repository.DeleteMaterial(id);
            //Assert
            Assert.Null(result);
        }

        [Fact]
        public async void DeleteMaterial_ShouldReturnMaterial_WhenMaterialIsDeleted()
        {
            //Arrange
            int id = 1;
            Material material = new()
            {
                MaterialId = id,
                TitleId = id,
                LocationId = id,
                Home = false


            };

            await _context.Database.EnsureDeletedAsync();
            _context.Material.Add(material);
            await _context.SaveChangesAsync();
            //Act
            var result = await _repository.DeleteMaterial(id);
            //Assert
            Assert.NotNull(result);
            Assert.IsType<Material>(result);
            Assert.Equal(id, result.MaterialId);

        }
    }
}
