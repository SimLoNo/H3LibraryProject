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
    public class LoanServiceTests
    {
        private readonly LoanService _service;
        private readonly Mock<ILoanRepository> _mockRepository = new();

        public LoanServiceTests()
        {
            _service = new(_mockRepository.Object);
        }

        [Fact]
        public async Task GetAllLoans_ShouldReturnListOfLoanResponse_WhenLoansExist()
        {
            //Arrange
            List<Loan> loaners = new()
            {
                new()
                {
                    LoanId = 1,
                    LoanerId = 1,
                    MaterialId = 1,
                    LoanDate = DateTime.Now,
                    ReturnDate = DateTime.Now
                },
                new()
                {
                    LoanId = 2,
                    LoanerId = 1,
                    MaterialId = 1,
                    LoanDate = DateTime.Now,
                    ReturnDate = DateTime.Now
                }
            };

            _mockRepository
                .Setup(x => x.SelectAllLoans())
                .ReturnsAsync(loaners);
            //Act
            var result = await _service.GetAllLoans();
            //Assert
            Assert.NotNull(result);
            Assert.IsType<List<LoanResponse>>(result);
            Assert.Equal(loaners.Count, result.Count);
        }
        [Fact]
        public async void GetAllLoans_ShouldReturnEmptyListOfLoans_WhenNoLoansExist()
        {
            //Arrange
            List<Loan> loaners = new();

            _mockRepository
                .Setup(x => x.SelectAllLoans())
                .ReturnsAsync(loaners);
            //Act
            var result = await _service.GetAllLoans();
            //Assert
            Assert.NotNull(result);
            Assert.IsType<List<LoanResponse>>(result);
            Assert.Empty(result);

        }

        [Fact]
        public async void GetLoanById_ShouldReturnLoanResponse_WhenTheLoanerExist()
        {
            //arrange
            int id = 1;
            Loan loan = new()
            {
                LoanId = id,
                LoanerId = 1,
                MaterialId = 1,
                LoanDate = DateTime.Now,
                ReturnDate = DateTime.Now
            };

            _mockRepository
                .Setup(x => x.SelectLoanById(It.IsAny<int>()))
                .ReturnsAsync(loan);
            //Act
            var result = await _service.GetLoanById(id);
            //Assert
            Assert.NotNull(result);
            Assert.IsType<LoanResponse>(result);
            Assert.Equal(id, result.LoanId);
        }

        [Fact]
        public async void GetLoanById_ShouldReturnNull_WhenTheLoanDoesNotExist()
        {
            //arrange
            int id = 1;

            _mockRepository
                .Setup(x => x.SelectLoanById(It.IsAny<int>()))
                .ReturnsAsync(() => null);
            //Act
            var result = await _service.GetLoanById(id);
            //Assert
            Assert.Null(result);
        }

        [Fact]
        public async void CreateLoan_ShouldReutnrLoanResponse_WhenLoanIsCreated()
        {
            //Arrange
            int id = 1;
            Loan loan = new()
            {
                LoanId = id,
                LoanerId = 1,
                MaterialId = 1,
                LoanDate = DateTime.Now,
                ReturnDate = DateTime.Now
            };
            LoanRequest request = new()
            {
                LoanerId = 1,
                MaterialId= 1,
                LoanDate= DateTime.Now,
                ReturnDate= DateTime.Now
            };

            _mockRepository
                .Setup(x => x.InsertNewLoan(It.IsAny<Loan>()))
                .ReturnsAsync(loan);
            //Act
            var result = await _service.CreateLoan(request);
            //Assert
            Assert.NotNull(result);
            Assert.IsType<LoanResponse>(result);
        }

        [Fact]
        public async void CreateLoan_ShouldReturnNUll_WhenLoanIsNotCreated()
        {
            //Arrange
            LoanRequest request = new()
            {
                LoanerId = 1,
                MaterialId = 1,
                LoanDate = DateTime.Now,
                ReturnDate = DateTime.Now
            };

            _mockRepository
                .Setup(x => x.InsertNewLoan(It.IsAny<Loan>()))
                .ReturnsAsync(() => null);
            //Act
            var result = await _service.CreateLoan(request);
            //Assert
            Assert.Null(result);

        }

        [Fact]
        public async void UpdateLoan_ShouldReturnLoanResponse_WhenLoanIsUpdated()
        {
            //Arrange
            int id = 1;
            LoanRequest request = new()
            {
                LoanerId = 1,
                MaterialId = 1,
                LoanDate = DateTime.Now,
                ReturnDate = DateTime.Now
            };
            Loan loan = new()
            {
                LoanId = id,
                LoanerId = 1,
                MaterialId = 1,
                LoanDate = DateTime.Now,
                ReturnDate = DateTime.Now
            };

            _mockRepository
                .Setup(x => x.UpdateExistingLoan(It.IsAny<int>(), It.IsAny<Loan>()))
                .ReturnsAsync(loan);
            //Act
            var result = await _service.UpdateLoan(id, request);
            //Assert
            Assert.NotNull(result);
            Assert.IsType<LoanResponse>(result);
        }


        [Fact]
        public async void UpdateLoan_ShouldReturnNull_WhenLoanIsNotUpdated()
        {
            //Arrange
            int id = 1;
            LoanRequest request = new()
            {
                LoanerId = 1,
                MaterialId = 1,
                LoanDate = DateTime.Now,
                ReturnDate = DateTime.Now
            };

            _mockRepository
                .Setup(x => x.UpdateExistingLoan(It.IsAny<int>(), It.IsAny<Loan>()))
                .ReturnsAsync(() => null);
            //Act
            var result = await _service.UpdateLoan(id, request);
            //Assert
            Assert.Null(result);
        }

        [Fact]
        public async void DeleteLoan_shouldReturnLoanResponse_WhenLoanIsDeleted()
        {
            //Arrange
            int id = 1;
            Loan loan = new()
            {
                LoanId = id,
                LoanerId = 1,
                MaterialId = 1,
                LoanDate = DateTime.Now,
                ReturnDate = DateTime.Now
            };

            _mockRepository
                .Setup(x => x.DeleteLoan(It.IsAny<int>()))
                .ReturnsAsync(loan);
            //Act
            var result = await _service.DeleteLoan(id);
            //Assert
            Assert.NotNull(result);
            Assert.IsType<LoanResponse>(result);
            Assert.Equal(id, result.LoanId);
        }

        [Fact]
        public async void DeleteLoan_shouldReturnNull_WhenLoanIsNotDeleted()
        {
            //Arrange
            int id = 1;
            _mockRepository
                .Setup(x => x.DeleteLoan(It.IsAny<int>()))
                .ReturnsAsync(() => null);
            //Act
            var result = await _service.DeleteLoan(id);
            //Assert
            Assert.Null(result);

        }
    }
}
