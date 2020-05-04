using Xunit;
using Moq;
using CoreLayer.Services;
using System.Threading.Tasks;
using CoreLayer.Models;
using ServiceLayer;
using PosTerminalApi.Controllers;
using PosTerminalApi.Resources;
using Microsoft.AspNetCore.Mvc;

namespace PostTerminalApiTestSuite
{
    public class UnitTest2
    {
        [Fact]
        public async Task TestProductController_GetProductById()
        {
            // Arrange
            var mockProductService = new Mock<IProductService>();
            var terminal = new PosTerminal(mockProductService.Object);
            var mockMapper = new Mock<AutoMapper.IMapper>();
            var productController = new ProductsController(mockProductService.Object, mockMapper.Object);
            mockProductService.Setup(x => x.GetProductByCode("A")).ReturnsAsync(GetTestProduct("A"));
            mockProductService.Setup(x => x.GetProductByCode("B")).ReturnsAsync(GetTestProduct("B"));
            mockProductService.Setup(x => x.GetProductByCode("C")).ReturnsAsync(GetTestProduct("C"));
            mockProductService.Setup(x => x.GetProductByCode("D")).ReturnsAsync(GetTestProduct("D"));
            mockProductService.Setup(x => x.GetProductById(1)).ReturnsAsync(GetTestProduct("A"));
            mockProductService.Setup(x => x.GetProductById(2)).ReturnsAsync(GetTestProduct("B"));
            mockProductService.Setup(x => x.GetProductById(3)).ReturnsAsync(GetTestProduct("C"));
            mockProductService.Setup(x => x.GetProductById(4)).ReturnsAsync(GetTestProduct("D"));
            mockMapper.Setup(x => x.Map<Product, ProductResource>(It.IsAny<Product>())).Returns(GetTestProductResource("A"));

            // Act
            var result = await productController.GetProductById(1);
            var value = result.Result as OkObjectResult;
            var actualProductResource = value.Value as ProductResource;

            // Assert
            Assert.NotNull(value);
            Assert.Equal(GetTestProductResource("A").Id, actualProductResource.Id);
            Assert.Equal(GetTestProductResource("A").CodeName, actualProductResource.CodeName);
            Assert.Equal(GetTestProductResource("A").UnitPrice, actualProductResource.UnitPrice);
            Assert.Equal(GetTestProductResource("A").UnitDiscount, actualProductResource.UnitDiscount);
            Assert.Equal(GetTestProductResource("A").DiscountQtyBase, actualProductResource.DiscountQtyBase);
            Assert.Equal(GetTestProductResource("A").FarmProducer, actualProductResource.FarmProducer);
        }
        private Product GetTestProduct(string productCode)
        {
            var product = new Product();

            if (productCode == "A")
            {
                product.CodeName = "A";
                product.Id = 1;
                product.UnitPrice = 1.25M;
                product.UnitDiscount = 3.00M;
                product.DiscountQtyBase = 3;
            }
            if (productCode == "B")
            {
                product.CodeName = "B";
                product.Id = 2;
                product.UnitPrice = 4.25M;
                product.UnitDiscount = 4.25M;
                product.DiscountQtyBase = 1;
            }
            if (productCode == "C")
            {
                product.CodeName = "C";
                product.Id = 3;
                product.UnitPrice = 1.00M;
                product.UnitDiscount = 5.00M;
                product.DiscountQtyBase = 6;
            }
            if (productCode == "D")
            {
                product.CodeName = "D";
                product.Id = 4;
                product.UnitPrice = 0.75M;
                product.UnitDiscount = 0.75M;
                product.DiscountQtyBase = 1;
            }
            return product;
        }
        private ProductResource GetTestProductResource(string productCode)
        {
            var productResource = new ProductResource();

            if (productCode == "A")
            {
                productResource.CodeName = "A";
                productResource.Id = 1;
                productResource.UnitPrice = 1.25M;
                productResource.UnitDiscount = 3.00M;
                productResource.DiscountQtyBase = 3;
            }
            if (productCode == "B")
            {
                productResource.CodeName = "B";
                productResource.Id = 2;
                productResource.UnitPrice = 4.25M;
                productResource.UnitDiscount = 4.25M;
                productResource.DiscountQtyBase = 1;
            }
            if (productCode == "C")
            {
                productResource.CodeName = "C";
                productResource.Id = 3;
                productResource.UnitPrice = 1.00M;
                productResource.UnitDiscount = 5.00M;
                productResource.DiscountQtyBase = 6;
            }
            if (productCode == "D")
            {
                productResource.CodeName = "D";
                productResource.Id = 4;
                productResource.UnitPrice = 0.75M;
                productResource.UnitDiscount = 0.75M;
                productResource.DiscountQtyBase = 1;
            }
            return productResource;
        }
    }
}
