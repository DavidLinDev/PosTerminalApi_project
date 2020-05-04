using Xunit;
using Moq;
using CoreLayer.Services;
using System.Threading.Tasks;
using CoreLayer.Models;
using ServiceLayer;

namespace PostTerminalApiTestSuite
{
    public class UnitTest1
    {
        [Fact]
        public async Task TestPosTermial_ProcessOrder1()
        {
            // Arrange
            var mockProductService = new Mock<IProductService>();
            var terminal = new PosTerminal(mockProductService.Object);
            mockProductService.Setup(x => x.GetProductByCode("A")).ReturnsAsync(GetTestProduct("A"));
            mockProductService.Setup(x => x.GetProductByCode("B")).ReturnsAsync(GetTestProduct("B"));
            mockProductService.Setup(x => x.GetProductByCode("C")).ReturnsAsync(GetTestProduct("C"));
            mockProductService.Setup(x => x.GetProductByCode("D")).ReturnsAsync(GetTestProduct("D"));
            var orderedProduct = "A,B,C,D,A,B,A";
            decimal amount = 13.25M;
            
            // Act
            var result = await terminal.GenerateOrderAsync(orderedProduct);
            
            // Assert
            Assert.Equal(result, amount);
        }

        [Fact]
        public async Task TestPosTermial_ProcessOrder2()
        {
            // Arrange
            var mockProductService = new Mock<IProductService>();
            var terminal = new PosTerminal(mockProductService.Object);
            mockProductService.Setup(x => x.GetProductByCode("A")).ReturnsAsync(GetTestProduct("A"));
            mockProductService.Setup(x => x.GetProductByCode("B")).ReturnsAsync(GetTestProduct("B"));
            mockProductService.Setup(x => x.GetProductByCode("C")).ReturnsAsync(GetTestProduct("C"));
            mockProductService.Setup(x => x.GetProductByCode("D")).ReturnsAsync(GetTestProduct("D"));
            var orderedProduct = "C,C,C,C,C,C,C";
            decimal amount = 6.00M;
            
            // Act
            var result = await terminal.GenerateOrderAsync(orderedProduct);

            // Assert
            Assert.Equal(result, amount);
        }

        [Fact]
        public async Task TestPosTermial_ProcessOrder3()
        {
            // Arrange
            var mockProductService = new Mock<IProductService>();
            var terminal = new PosTerminal(mockProductService.Object);
            mockProductService.Setup(x => x.GetProductByCode("A")).ReturnsAsync(GetTestProduct("A"));
            mockProductService.Setup(x => x.GetProductByCode("B")).ReturnsAsync(GetTestProduct("B"));
            mockProductService.Setup(x => x.GetProductByCode("C")).ReturnsAsync(GetTestProduct("C"));
            mockProductService.Setup(x => x.GetProductByCode("D")).ReturnsAsync(GetTestProduct("D"));
            var orderedProduct = "A,B,C,D";
            decimal amount = 7.25M;
            
            // Act
            var result = await terminal.GenerateOrderAsync(orderedProduct);

            // Assert
            Assert.Equal(result, amount);
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
    }
}
