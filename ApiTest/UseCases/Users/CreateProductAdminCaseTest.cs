using API.Application.AdminCases;
using API.Application.DataObjects.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTest.UseCases.Users
{
    public class CreateProductAdminCaseTest
    {
        private readonly CreateProductAdminCase _adminCase;


        [Fact]
        public async void ExecuteAsync_WithValidCommand_ShouldReturnSuccess()
        {
            // Arrange
            var command = new CreateProductCommand("ProductName", "Description", 10, "Season", "UsageContexte", "FlowerType", "FlowerCareAdvice");

            // Act
            var result = await _adminCase.ExecuteAsync(command);

            // Assert
            result.Should().BeOfType<CreateProductResult.Success>();


        }
    }
}
