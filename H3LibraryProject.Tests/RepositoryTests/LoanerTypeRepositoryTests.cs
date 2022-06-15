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
    public class LoanerTypeRepositoryTests
    {
        private readonly DbContextOptions<LibraryContext> _options;
        private readonly LibraryContext _context;
        private readonly LoanerTypeRepository _repository;

        public LoanerTypeRepositoryTests()
        {
            _options = new DbContextOptionsBuilder<LibraryContext>()
                .UseInMemoryDatabase(databaseName: "LibraryProjectLoanerType")
                .Options;

            _context = new(_options);

            _repository = new(_context);
        }

        [Fact]
        public async void GetAllLoanerTypes_ShouldReturnListOfLoanerTypes_WhenLoanerTypesExist()
        {
            //Arrange
            int id = 1;
            List<LoanerType> loanerTypeList = new()
            {
                new()
                {
                    LoanerTypeId = id,
                    Name = "Medarbejdere"
                },
                new()
                {
                    LoanerTypeId = id + 1,
                    Name = "Lånere"
                }
            };
            await _context.Database.EnsureDeletedAsync();
            foreach (LoanerType item in loanerTypeList)
            {
                _context.LoanerTypes.Add(item);
            }
            await _context.SaveChangesAsync();

            //Act
            var result = await _repository.GetAllLoanerTypes();
            //assert
            Assert.NotNull(result);
            Assert.IsType<List<LoanerType>>(result);
            Assert.Equal(loanerTypeList.Count, result.Count);
        }
        [Fact]
        public async void GetAllLoanerTypes_ShouldReturnEmptyListOfLoanerTypes_WhenNoLoanerTypesExist()
        {
            //Arrange
           
            await _context.Database.EnsureDeletedAsync();
            await _context.SaveChangesAsync();

            //Act
            var result = await _repository.GetAllLoanerTypes();
            //assert
            Assert.NotNull(result);
            Assert.IsType<List<LoanerType>>(result);
            Assert.Empty(result);
        }

        [Fact]
        public async void GetLoanerTypeById_ShouldReturnLoanerType_WhenTheLoanerTypeExists()
        {
            //Arrange
            int id = 1;
            LoanerType loanerType = new()
            {
                LoanerTypeId = id,
                Name = "Medarbejdere"
            };
            await _context.Database.EnsureDeletedAsync();
            _context.LoanerTypes.Add(loanerType);
            await _context.SaveChangesAsync();

            //Act
            var result = await _repository.GetLoanerTypeById(id);
            //assert
            Assert.NotNull(result);
            Assert.IsType<LoanerType>(result);
            Assert.Equal(id, result.LoanerTypeId);
        }
        [Fact]
        public async void GetLoanerTypeById_ShouldReturnNull_WhenTheLoanerTypeDoesNotExist()
        {
            //Arrange
            int id = 1;
            await _context.Database.EnsureDeletedAsync();
            await _context.SaveChangesAsync();

            //Act
            var result = await _repository.GetLoanerTypeById(id);
            //assert
            Assert.Null(result);
        }

        [Fact]
        public async void CreateLoanerType_ShouldReturnError_WhenLoanerTypeAlreadyExist()
        {
            //Arrange
            int id = 1;
            LoanerType loanerType = new()
            {
                LoanerTypeId = id,
                Name = "Medarbejder"
            };

            await _context.Database.EnsureDeletedAsync();
            _context.LoanerTypes.Add(loanerType);
            await _context.SaveChangesAsync();

            //Act
            async Task action() => await _repository.CreateLoanerType(loanerType);
            //Assert
            var ex = await Assert.ThrowsAsync<ArgumentException>(action);
            Assert.Contains("An item with the same key has already been added", ex.Message);
        }

        [Fact]
        public async void CreateLoanerType_ShouldReturnLoanerType_WhenErrorIsNotFired()
        {
            //Arrange
            LoanerType loanerType = new()
            {
                Name = "Test"
            };
            await _context.Database.EnsureDeletedAsync();

            //Act
            var result = await _repository.CreateLoanerType(loanerType);
            //Assert
            Assert.NotNull(result);
            Assert.IsType<LoanerType>(result);
        }

        [Fact]
        public async void UpdateLoanerType_ShouldReturnLoanerType_WhenLoanerTypeIsUpdated()
        {
            //Arrange
            int id = 1;
            string newName = "New name!";
            LoanerType loanerType = new()
            {
                LoanerTypeId=id,
                Name = "Test"
            };

            await _context.Database.EnsureDeletedAsync();
            _context.LoanerTypes.Add(loanerType);
            await _context.SaveChangesAsync();

            loanerType.Name = newName;
            //Act
            var result = await _repository.UpdateLoanerType(id, loanerType);
            //Assert
            Assert.NotNull(result);
            Assert.IsType<LoanerType>(result);
            Assert.Equal(newName, result.Name);
        }

        [Fact]
        public async void UpdateLoanerType_ShouldReturnNull_WhenNoLoanerTypeIsUpdated()
        {
            //Arrange
            int id = 1;
            LoanerType loanerType = new()
            {
                LoanerTypeId = id,
                Name = "Test"
            };

            await _context.Database.EnsureDeletedAsync();
            await _context.SaveChangesAsync();

            //Act
            var result = await _repository.UpdateLoanerType(id, loanerType);
            //Assert
            Assert.Null(result);
        }

        [Fact]
        public async void DeleteLoanerType_ShouldReturnNull_WhenNoLoanerTypeIsDeleted()
        {
            //Arrange
            int id = 1;
            await _context.Database.EnsureDeletedAsync();
            await _context.SaveChangesAsync();
            //Act
            var result = await _repository.DeleteLoanerType(id);
            //Assert
            Assert.Null(result);
        }

        [Fact]
        public async void DeleteLoanerType_ShouldReturnLoanerType_WhenLoanerTypeIsDeleted()
        {
            //Arrange
            int id = 1;
            LoanerType loanerType = new()
            {
                LoanerTypeId = id,
                Name = "Test"
            };

            await _context.Database.EnsureDeletedAsync();
            _context.LoanerTypes.Add(loanerType);
            await _context.SaveChangesAsync();
            //Act
            var result = await _repository.DeleteLoanerType(id);
            //Assert
            Assert.NotNull(result);
            Assert.IsType<LoanerType>(result);
            Assert.Equal(id, result.LoanerTypeId);

        }
    }
}
