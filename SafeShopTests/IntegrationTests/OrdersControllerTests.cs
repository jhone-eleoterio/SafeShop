using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using SafeShopAPI.Controllers;
using SafeShopAPI.Domain.Entities;
using SafeShopAPI.Domain.Interfaces;
using SafeShopAPI.Domain.Models;

namespace SafeShopTests.IntegrationTests
{
    public class OrdersControllerTests
    {
        private readonly Mock<IOrderRepository> _mockRepository;
        private readonly OrdersController _controller;
        private readonly ILogger<OrdersController> _logger;

        public OrdersControllerTests()
        {
            _mockRepository = new Mock<IOrderRepository>();
            _controller = new OrdersController(_logger, _mockRepository.Object);
        }

        [Fact]
        public async Task Post_InvalidModelState_ReturnsBadRequest()
        {
            // Arrange
            _controller.ModelState.AddModelError("ProductId", "ProductId is required");
            var viewModel = new OrderViewModel();

            // Act
            var result = await _controller.Post(viewModel);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.IsType<SerializableError>(badRequestResult.Value);
        }

        [Fact]
        public async Task Post_ValidModelState_CreatesOrder_ReturnsCreatedResult()
        {
            // Arrange
            var viewModel = new OrderViewModel
            {
                ProductId = Guid.Parse("1bcfa457-7a57-418b-bd1c-75a3db9e4fa9"),
                Quantity = 5
            };
            var order = new Order("1234", viewModel.ProductId, viewModel.Quantity);

            _mockRepository.Setup(repo => repo.Add(It.IsAny<Order>())).Returns(Task.CompletedTask);

            // Act
            var result = await _controller.Post(viewModel);

            // Assert
            var createdResult = Assert.IsType<CreatedResult>(result);
            var returnedOrder = Assert.IsType<Order>(createdResult.Value);
            Assert.Equal(order.ProductId, returnedOrder.ProductId);
            Assert.Equal(order.Quantity, returnedOrder.Quantity);
        }
    }
}
