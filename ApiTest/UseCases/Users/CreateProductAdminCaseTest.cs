using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTest.UseCases.Users
{
    internal class CreateProductAdminCaseTest
    {
        private readonly CreateProductAdminCase _adminCase;

        public CreateProductAdminCaseTest()
        {
        }

        public void ExecuteAsync_WithValidCommand_ShouldReturnSuccess()
        {
            // Arrange
            var command = new CreateProductCommand("ProductName", "Description", "Price", "Season", "UsageContexte", "FlowerType", "FlowerCareAdvice");
        }
    }
}
