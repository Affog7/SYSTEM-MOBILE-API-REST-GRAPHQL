

namespace Tests;

public class ProductsControllerTests
{
    private readonly ProductsController _controller;
    private readonly Mock<IProductService> _mockProductService;

    public ProductsControllerTests()
    {
        _mockProductService = new Mock<IProductService>();
        _controller = new ProductsController(_mockProductService.Object);
    }

    [Fact]
    public async Task TestGetAll()
    {
        // Arrange
        _mockProductService.Setup(x => x.GetAll(It.IsAny<int>()))
            .Returns(new List<ProductDTO>());

        // Act
        var result =   _controller.GetAll();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var products = Assert.IsAssignableFrom<IEnumerable<ProductDTO>>(okResult.Value);
        _mockProductService.Verify(x => x.GetAll(It.IsAny<int>()), Times.Once);
    }

    [Fact]
    public async Task TestGetById()
    {
        // Arrange
        int id = 1;
        var product = new ProductDTO { Id = id };
        _mockProductService.Setup(x => x.GetById(id))
            .Returns(product);

        // Act
        var result =   _controller.GetById(id);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Same(product, okResult.Value);
        _mockProductService.Verify(x => x.GetById(id), Times.Once);
    }

    [Fact]
    public async Task TestGetById_NotFound()
    {
        // Arrange
        int id = 1;
        _mockProductService.Setup(x => x.GetById(id))
            .Returns((ProductDTO)null);

        // Act
        var result =   _controller.GetById(id);

        // Assert
        Assert.IsType<NotFoundResult>(result);
        _mockProductService.Verify(x => x.GetById(id), Times.Once);
    }



    [Fact]
    public async Task TestCreate()
    {
        // Arrange
        var product = new ProductDTO { Id = 100,Name ="Essaie" };
        _mockProductService.Setup(x => x.Create(product));

        // Act
        var result = await _controller.Create(product);

        // Assert

        var createdResult = Assert.IsType <ActionResult<ProductDTO>> (result);


        Assert.Same(product.Name, createdResult.Value.Name);
       // Assert.NotSame(product.Id, createdResult.Value.Id);
        _mockProductService.Verify(x => x.Create(product), Times.Once);
    }


    [Fact]
    public async Task TestUpdate()
    {
        // Arrange
        int id = 1;
        var product = new ProductDTO { Id = id };
        _mockProductService.Setup(x => x.GetById(id))
            .Returns(product);
        _mockProductService.Setup(x => x.Update(product));

        // Act
        var result =   _controller.Update(id, product);

        // Assert
        Assert.IsType<NoContentResult>(result);
        _mockProductService.Verify(x => x.GetById(id), Times.Once);
        _mockProductService.Verify(x => x.Update(product), Times.Once);
    }

    [Fact]
    public async Task TestUpdate_NotFound()
    {
        // Arrange
        int id = 1;
        var product = new ProductDTO { Id = id };
        _mockProductService.Setup(x => x.GetById(id))
            .Returns((ProductDTO)null);

        // Act
        var result =   _controller.Update(id, product);

        // Assert
        Assert.IsType<NotFoundResult>(result);
        _mockProductService.Verify(x => x.GetById(id), Times.Once);
        _mockProductService.Verify(x => x.Update(product), Times.Never);
    }

    [Fact]
    public void Delete_ReturnsNotFound_WhenProductNotExists()
    {
        // Arrange
        var productId = 1;
        var productServiceMock = new Mock<IProductService>();
        productServiceMock.Setup(x => x.GetById(productId)).Returns((ProductDTO)null);
        var controller = new ProductsController(productServiceMock.Object);

        // Act
        var result = controller.Delete(productId);

        // Assert
        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public void Delete_ReturnsNoContent_WhenProductExists()
    {
        // Arrange
        var productId = 1;
        var existingProduct = new ProductDTO { Id = productId };
        var productServiceMock = new Mock<IProductService>();
        productServiceMock.Setup(x => x.GetById(productId)).Returns(existingProduct);
        var controller = new ProductsController(productServiceMock.Object);

        // Act
        var result = controller.Delete(productId);

        // Assert
        productServiceMock.Verify(x => x.Delete(existingProduct), Times.Once);
        Assert.IsType<NoContentResult>(result);
    }



    [Fact]
    public async Task GetByName_ReturnsProduct_WhenProductExists()
    {
        // Arrange
        var productName = "productName";
        var expectedProduct = new ProductDTO { Name = productName };
        var productServiceMock = new Mock<IProductService>();
        productServiceMock.Setup(ps => ps.GetByName(productName)).Returns(expectedProduct);
        var productsController = new ProductsController(productServiceMock.Object);

        // Act
        var result =   productsController.GetByName(productName) as OkObjectResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expectedProduct, result.Value);
    }

    [Fact]
    public async Task GetByName_ReturnsNotFound_WhenProductDoesNotExist()
    {
        // Arrange
        var productName = "productName";
        ProductDTO expectedProduct = null;
        var productServiceMock = new Mock<IProductService>();
        productServiceMock.Setup(ps => ps.GetByName(productName)).Returns(expectedProduct);
        var productsController = new ProductsController(productServiceMock.Object);

        // Act
        var result =   productsController.GetByName(productName) as NotFoundResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal(404, result.StatusCode);
    }



}



