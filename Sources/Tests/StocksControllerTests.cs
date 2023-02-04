using System;
namespace Tests
{
    public class StocksControllerTests
    {
        [Fact]
        public void GetAll_Returns_OkResult_WhenStocksExist()
        {
            // Arrange
            var mockStockService = new Mock<IStockService>();
            mockStockService.Setup(service => service.GetAll()).Returns(new List<StockDTO>());
            var controller = new StocksController(mockStockService.Object);

            // Act
            var result = controller.Index(); 

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void GetById_Returns_OkResult_WhenStockExists()
        {
            // Arrange
            var mockStockService = new Mock<IStockService>();
            mockStockService.Setup(service => service.GetById(1)).Returns(new StockDTO());
            var controller = new StocksController(mockStockService.Object);

            // Act
            var result = controller.GetById(1);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void GetById_Returns_NotFoundResult_WhenStockDoesNotExist()
        {
            // Arrange
            var mockStockService = new Mock<IStockService>();
            mockStockService.Setup(service => service.GetById(1)).Returns((StockDTO)null);
            var controller = new StocksController(mockStockService.Object);

            // Act
            var result = controller.GetById(1);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async void Create_Returns_CreatedAtActionResult_WhenStockCreated()
        {
            // Arrange
            var mockStockService = new Mock<IStockService>();
            mockStockService.Setup(service => service.Create(It.IsAny<StockDTO>()));
            var controller = new StocksController(mockStockService.Object);
            var stock = new StockDTO();

            // Act
            var result = await controller.Create(stock);

            // Assert
            Assert.IsType<CreatedAtActionResult>(result);
        }

        [Fact]
        public void Update_Returns_NoContentResult_WhenStockUpdated()
        {
            // Arrange
            var mockStockService = new Mock<IStockService>();
            mockStockService.Setup(service => service.GetById(1)).Returns(new StockDTO());
            mockStockService.Setup(service => service.Update(It.IsAny<StockDTO>()));
            var controller = new StocksController(mockStockService.Object);
            var stock = new StockDTO();

            // Act
            var result = controller.Update(1, stock);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }



    }

}