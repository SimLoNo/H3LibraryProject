using H3LibraryProject.API.DTOs;
using H3LibraryProject.Repositories.Database;
using H3LibraryProject.Repositories.Repositories;
using H3LibraryProject.Services.DTO;
using H3LibraryProject.Services.Services;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;


namespace H3LibraryProject.Tests.ServiceTests
{
    public class LoanerServiceTests
    {
        private readonly LoanerService _service;
        private readonly Mock<ILoanerRepository> _mockRepository = new();

        public LoanerServiceTests()
        {
            _service = new(_mockRepository.Object);
        }

        [Fact]
        public async void GetAllLoaners_ShouldReturnListOfLoanerResponse_WhenLoanersExist()
        {
            //Arrange
            List<Loaner> loaners = new()
            {
                new()
                {
                    LoanerId = 1,
                    LoanerTypeId = 1,
                    Name = "test",
                    Password = "Test"
                },
                new()
                {
                    LoanerId = 2,
                    LoanerTypeId = 1,
                    Name = "test",
                    Password = "Test"
                }
            };

            _mockRepository
                .Setup(l => l.GetAllLoaners())
                .ReturnsAsync(loaners);
            //Act
            var result = await _service.GetAllLoaners();
            //Assert
            Assert.NotNull(result);
            Assert.IsType<List<LoanerResponse>>(result);
            Assert.Equal(loaners.Count, result.Count);
        }
    }
}
