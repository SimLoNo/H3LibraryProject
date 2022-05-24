using H3LibraryProject.Repositories.Database;
using H3LibraryProject.Repositories.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace H3LibraryProject.Tests.RepositoryTests
{
    public class LoanerRepositoryTests
    {
        private readonly DbContextOptions<LibraryContext> _options;
        private readonly LibraryContext _context;
        private readonly LoanerRepository _repository;

        public LoanerRepositoryTests()
        {
            _options = new DbContextOptionsBuilder<LibraryContext>()
                .UseInMemoryDatabase(databaseName: "LibraryProjectLoaner")
                .Options;
            _context = new(_options);

            _repository = new(_context);
        }

        [Fact]
        public async void GetAllLoaners_ShouldReturnListOfLoaners_WhenLoanersExist()
        {
            //Arrange
            int id = 1;
            List<Loaner> loanerList = new()
            {
                new()
                {
                    LoanerId = id,
                    LoanerTypeId = 1,
                    Name = "Test",
                    Password = "Passw0rd"
                },
                new()
                {
                    LoanerId = id+1,
                    LoanerTypeId = 1,
                    Name = "Test",
                    Password = "Passw0rd"
                }
            };
            LoanerType loanerType = new() { LoanerTypeId = 1, Name = "Test" };
            await _context.Database.EnsureDeletedAsync();
            foreach (Loaner item in loanerList)
            {
                _context.Loaners.Add(item);
            }
            _context.LoanerTypes.Add(loanerType);
            await _context.SaveChangesAsync();

            //Act
            var result = await _repository.GetAllLoaners();
            //assert
            Assert.NotNull(result);
            Assert.IsType<List<Loaner>>(result);
            Assert.Equal(loanerList.Count, result.Count);
        }
        [Fact]
        public async void GetAllLoaners_ShouldReturnEmptyListOfLoaners_WhenNoLoanersExist()
        {
            //Arrange
            await _context.Database.EnsureDeletedAsync();
            await _context.SaveChangesAsync();

            //Act
            var result = await _repository.GetAllLoaners();
            //assert
            Assert.NotNull(result);
            Assert.IsType<List<Loaner>>(result);
            Assert.Empty(result);
        }

        [Fact]
        public async void GetLoanerById_ShouldReturnLoaner_WhenTheLoanerExists()
        {
            //Arrange
            int id = 1;
            Loaner loaner = new()
            {
                LoanerId = id,
                LoanerTypeId = 1,
                Name = "Test",
                Password = "Passw0rd"
            };
            await _context.Database.EnsureDeletedAsync();
            _context.Loaners.Add(loaner);
            await _context.SaveChangesAsync();

            //Act
            var result = await _repository.GetLoanerById(id);
            //assert
            Assert.NotNull(result);
            Assert.IsType<Loaner>(result);
            Assert.Equal(id, result.LoanerId);
        }
        [Fact]
        public async void GetLoanerById_ShouldReturnNull_WhenTheLoanerDoesNotExist()
        {
            //Arrange
            int id = 1;
            await _context.Database.EnsureDeletedAsync();
            await _context.SaveChangesAsync();

            //Act
            var result = await _repository.GetLoanerById(id);
            //assert
            Assert.Null(result);
        }

        [Fact]
        public async void CreateLoaner_ShouldReturnError_WhenLoanerAlreadyExist()
        {
            //Arrange
            int id = 1;
            Loaner loaner = new()
            {
                LoanerId=id,
                LoanerTypeId = 1,
                Name = "Test",
                Password = "Passw0rd"
            };

            await _context.Database.EnsureDeletedAsync();
            _context.Loaners.Add(loaner);
            await _context.SaveChangesAsync();

            //Act
            async Task action() => await _repository.CreateLoaner(loaner);
            //Assert
            var ex = await Assert.ThrowsAsync<ArgumentException>(action);
            Assert.Contains("An item with the same key has already been added", ex.Message);
        }

        [Fact]
        public async void CreateLoanerType_ShouldReturnLoanerType_WhenErrorIsNotFired()
        {
            //Arrange
            Loaner loaner = new()
            {
                LoanerTypeId = 1,
                Name = "Test",
                Password = "Passw0rd"
            };
            await _context.Database.EnsureDeletedAsync();

            //Act
            var result = await _repository.CreateLoaner(loaner);
            //Assert
            Assert.NotNull(result);
            Assert.IsType<Loaner>(result);
        }

        [Fact]
        public async void UpdateLoanere_ShouldReturnLoaner_WhenLoanerIsUpdated()
        {
            //Arrange
            int id = 1;
            string newName = "New name!";
            Loaner loaner = new()
            {
                LoanerTypeId = 1,
                Name = "Test",
                Password = "Passw0rd"
            };

            await _context.Database.EnsureDeletedAsync();
            _context.Loaners.Add(loaner);
            await _context.SaveChangesAsync();

            loaner.Name = newName;
            //Act
            var result = await _repository.UpdateLoaner(id, loaner);
            //Assert
            Assert.NotNull(result);
            Assert.IsType<Loaner>(result);
            Assert.Equal(newName, result.Name);
        }

        [Fact]
        public async void UpdateLoaner_ShouldReturnNull_WhenNoLoanerIsUpdated()
        {
            //Arrange
            int id = 1;
            Loaner loaner = new()
            {
                LoanerId = id,
                LoanerTypeId = 1,
                Name = "Test",
                Password = "Passw0rd"
            };

            await _context.Database.EnsureDeletedAsync();
            await _context.SaveChangesAsync();

            //Act
            var result = await _repository.UpdateLoaner(id, loaner);
            //Assert
            Assert.Null(result);
        }

        [Fact]
        public async void DeleteLoanere_ShouldReturnNull_WhenNoLoanerIsDeleted()
        {
            //Arrange
            int id = 1;
            await _context.Database.EnsureDeletedAsync();
            await _context.SaveChangesAsync();
            //Act
            var result = await _repository.DeleteLoaner(id);
            //Assert
            Assert.Null(result);
        }

        [Fact]
        public async void DeleteLoaner_ShouldReturnLoaner_WhenLoanerIsDeleted()
        {
            //Arrange
            int id = 1;
            Loaner loaner = new()
            {
                LoanerId= id,
                LoanerTypeId = 1,
                Name = "Test",
                Password = "Passw0rd"
            };

            await _context.Database.EnsureDeletedAsync();
            _context.Loaners.Add(loaner);
            await _context.SaveChangesAsync();
            //Act
            var result = await _repository.DeleteLoaner(id);
            //Assert
            Assert.NotNull(result);
            Assert.IsType<Loaner>(result);
            Assert.Equal(id, result.LoanerTypeId);

        }
    }
}
