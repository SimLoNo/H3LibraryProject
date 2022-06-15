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
    public class LoanRepositoryTests
    {
        private readonly DbContextOptions<LibraryContext> _options;
        private readonly LibraryContext _context;
        private readonly LoanRepository _repository;

        public LoanRepositoryTests()
        {
            _options = new DbContextOptionsBuilder<LibraryContext>()
                .UseInMemoryDatabase(databaseName: "LibraryProjectLoan")
                .Options;
            _context = new(_options);

            _repository = new(_context);
        }

        [Fact]
        public async void GetAllLoans_ShouldReturnListOfLoans_WhenLoansExist()
        {
            //Arrange
            int id = 1;
            List<Loan> loanList = new()
            {
                new()
                {
                    LoanId = id,
                    LoanerId = id,
                    MaterialId = id,
                    LoanDate = DateTime.Now,
                    ReturnDate = DateTime.Now,
                    IsReturned = true
                },
                new()
                {
                    LoanId = id + 1,
                    LoanerId = id,
                    MaterialId = id,
                    LoanDate = DateTime.Now,
                    ReturnDate = DateTime.Now,
                    IsReturned = true
                }
            };
            await _context.Database.EnsureDeletedAsync();

            _context.LoanerTypes.Add(new() { LoanerTypeId = id, Name = "Test" });
            _context.Title.Add(new() { TitleId = id,Name = "Test",LanguageId=id,RYear=4,Pages=4, });
            _context.Material.Add(new() { MaterialId = id, TitleId = id, LocationId = id, Home = true });
            _context.Loaner.Add(new() { LoanerId = id, Name = "test", LoanerTypeId = id, Password = "test" });


            foreach (Loan item in loanList)
            {
                _context.Loan.Add(item);
            }
            await _context.SaveChangesAsync();

            //Act
            var result = await _repository.SelectAllLoans();
            //assert
            Assert.NotNull(result);
            Assert.IsType<List<Loan>>(result);
            Assert.Equal(loanList.Count, result.Count);
        }
        [Fact]
        public async void GetAllLoans_ShouldReturnEmptyListOfLoans_WhenNoLoansExist()
        {
            //Arrange
            await _context.Database.EnsureDeletedAsync();
            await _context.SaveChangesAsync();

            //Act
            var result = await _repository.SelectAllLoans();
            //assert
            Assert.NotNull(result);
            Assert.IsType<List<Loan>>(result);
            Assert.Empty(result);
        }

        [Fact]
        public async void GetLoanById_ShouldReturnLoan_WhenTheLoanExists()
        {
            //Arrange
            int id = 1;
            Loan loan = new()
            {
                LoanId = id,
                LoanerId = id,
                MaterialId = id,
                LoanDate = DateTime.Now,
                ReturnDate = DateTime.Now,
            };
            await _context.Database.EnsureDeletedAsync();
            _context.Loan.Add(loan);
            _context.LoanerTypes.Add(new() { LoanerTypeId = id, Name = "Test" });
            _context.Title.Add(new() { TitleId = id, Name = "Test", LanguageId = id, RYear = 4, Pages = 4, });
            _context.Material.Add(new() { MaterialId = id, TitleId = id, LocationId = id, Home = true });
            _context.Loaner.Add(new() { LoanerId = id, Name = "test", LoanerTypeId = id, Password = "test" });
            await _context.SaveChangesAsync();

            //Act
            var result = await _repository.SelectLoanById(id);
            //assert
            Assert.NotNull(result);
            Assert.IsType<Loan>(result);
            Assert.Equal(id, result.LoanId);
        }
        [Fact]
        public async void GetLoanById_ShouldReturnNull_WhenTheLoanDoesNotExist()
        {
            //Arrange
            int id = 1;
            await _context.Database.EnsureDeletedAsync();
            await _context.SaveChangesAsync();

            //Act
            var result = await _repository.SelectLoanById(id);
            //assert
            Assert.Null(result);
        }

        [Fact]
        public async void CreateLoan_ShouldReturnError_WhenLoanAlreadyExist()
        {
            //Arrange
            int id = 1;
            Loan loan = new()
            {
                LoanId = id,
                LoanerId = id,
                MaterialId = id,
                LoanDate = DateTime.Now,
                ReturnDate = DateTime.Now,
            };

            await _context.Database.EnsureDeletedAsync();
            _context.Loan.Add(loan);
            await _context.SaveChangesAsync();

            //Act
            async Task action() => await _repository.InsertNewLoan(loan);
            //Assert
            var ex = await Assert.ThrowsAsync<ArgumentException>(action);
            Assert.Contains("An item with the same key has already been added", ex.Message);
        }

        [Fact]
        public async void CreateLoanType_ShouldReturnLoanType_WhenErrorIsNotFired()
        {
            //Arrange
            Loan loan = new()
            {
                LoanId = 1,
                LoanerId = 1,
                MaterialId = 1,
                LoanDate = DateTime.Now,
                ReturnDate = DateTime.Now,
            };
            await _context.Database.EnsureDeletedAsync();

            //Act
            var result = await _repository.InsertNewLoan(loan);
            //Assert
            Assert.NotNull(result);
            Assert.IsType<Loan>(result);
        }

        [Fact]
        public async void UpdateLoane_ShouldReturnLoan_WhenLoanIsUpdated()
        {
            //Arrange
            int id = 1;
            Loan loan = new()
            {
                LoanId = id,
                LoanerId = id,
                MaterialId = id,
                LoanDate = DateTime.Now,
                ReturnDate = DateTime.Now,
            };

            await _context.Database.EnsureDeletedAsync();
            _context.Loan.Add(loan);
            await _context.SaveChangesAsync();

            //Act
            var result = await _repository.UpdateExistingLoan(id, loan);
            //Assert
            Assert.NotNull(result);
            Assert.IsType<Loan>(result);
        }

        [Fact]
        public async void UpdateLoan_ShouldReturnNull_WhenNoLoanIsUpdated()
        {
            //Arrange
            int id = 1;
            Loan loan = new()
            {
                LoanId = id,
                LoanerId = id,
                MaterialId = id,
                LoanDate = DateTime.Now,
                ReturnDate = DateTime.Now,
            };

            await _context.Database.EnsureDeletedAsync();
            await _context.SaveChangesAsync();

            //Act
            var result = await _repository.UpdateExistingLoan(id, loan);
            //Assert
            Assert.Null(result);
        }

        [Fact]
        public async void DeleteLoane_ShouldReturnNull_WhenNoLoanIsDeleted()
        {
            //Arrange
            int id = 1;
            await _context.Database.EnsureDeletedAsync();
            await _context.SaveChangesAsync();
            //Act
            var result = await _repository.DeleteLoan(id);
            //Assert
            Assert.Null(result);
        }

        [Fact]
        public async void DeleteLoan_ShouldReturnLoan_WhenLoanIsDeleted()
        {
            //Arrange
            int id = 1;
            Loan loan = new()
            {
                LoanId = id,
                LoanerId = id,
                MaterialId = id,
                LoanDate = DateTime.Now,
                ReturnDate = DateTime.Now,
            };

            await _context.Database.EnsureDeletedAsync();
            _context.Loan.Add(loan);
            await _context.SaveChangesAsync();
            //Act
            var result = await _repository.DeleteLoan(id);
            //Assert
            Assert.NotNull(result);
            Assert.IsType<Loan>(result);
            Assert.Equal(id, result.LoanId);

        }
    }
}
