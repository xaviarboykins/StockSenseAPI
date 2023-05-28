using StockSense.Services;
using StockSense.Repositories;
using StockSense.Model;
using StockSense.DbContextFolder;
using Microsoft.EntityFrameworkCore;

namespace StockSenseUnitTesting
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddProduct_ShouldAddProductToRepository()
        {
            // Arrange
            // Create the necessary options for the DbContext
            var options = new DbContextOptionsBuilder<ProductDbContext>()
                .UseSqlServer("DefaultConnection")
                .Options;
            // Create an instance of the DbContext using the options
            var dbContext = new ProductDbContext(options);
            // Create an instance of the actual repository using the DbContext
            var productRepository = new ProductRepository(dbContext);
            // Create an instance of the service using the repository
            var productService = new ProductService(productRepository); 
            var product = new Product { Name = "Test Product", Quantity = 10 };

            // Act
            // Call the AddProduct method on the service
            productService.AddProduct(product);

            // Assert
            // Retrieve the added product from the repository
            var addedProduct = productRepository.GetProductById(product.ProductId);
            // Assert that the added product is not null
            Assert.IsNotNull(addedProduct);
            // Assert that the added product has the expected name
            Assert.AreEqual("Test Product", addedProduct.Name);
            // Assert that the added product has the expected quantity
            Assert.AreEqual(10, addedProduct.Quantity); 
        }

        [TestMethod]
        public void IncreaseStock_ShouldIncreaseProductQuantity()
        {
            // Arrange
            // Create the necessary options for the DbContext
            var options = new DbContextOptionsBuilder<ProductDbContext>()
                .UseSqlServer("DefaultConnection")
                .Options;

            // Create an instance of the ProductDbContext
            var dbContext = new ProductDbContext(options);

            // Create an instance of the ProductRepository using the ProductDbContext
            var productRepository = new ProductRepository(dbContext);

            // Create an instance of the ProductService using the ProductRepository
            var productService = new ProductService(productRepository);

            // Create a test product
            var product = new Product { Name = "Test Product", Quantity = 10 };

            // Add the test product to the repository
            productRepository.AddProduct(product);

            // Act
            // Increase the stock quantity of the product
            productService.IncreaseStock(product.ProductId, 5);

            // Assert
            // Retrieve the updated product from the repository
            var updatedProduct = productRepository.GetProductById(product.ProductId);

            // Check if the product quantity has been increased to the expected value
            Assert.AreEqual(15, updatedProduct.Quantity);
        }

        [TestMethod]
        public void DecreaseStock_ShouldDecreaseProductQuantity()
        {
            // Arrange
            // Create the necessary options for the DbContext
            var options = new DbContextOptionsBuilder<ProductDbContext>()
                .UseSqlServer("DefaultConnection")
                .Options;

            // Create an instance of the ProductDbContext
            var dbContext = new ProductDbContext(options);

            // Create an instance of the ProductRepository using the ProductDbContext
            var productRepository = new ProductRepository(dbContext);

            // Create an instance of the ProductService using the ProductRepository
            var productService = new ProductService(productRepository);

            // Create a test product
            var product = new Product { Name = "Test Product", Quantity = 10 };

            // Add the test product to the repository
            productRepository.AddProduct(product);

            // Act
            // Decrease the stock quantity of the product
            productService.DecreaseStock(product.ProductId, 5);

            // Assert
            // Retrieve the updated product from the repository
            var updatedProduct = productRepository.GetProductById(product.ProductId);

            // Check if the product quantity has been decreased to the expected value
            Assert.AreEqual(5, updatedProduct.Quantity);
        }

        [TestMethod]
        public void GetStockSummary_ShouldReturnValidInventoryReport()
        {
            // Arrange
            // Create the necessary options for the DbContext
            var options = new DbContextOptionsBuilder<ProductDbContext>()
                .UseSqlServer("DefaultConnection")
                .Options;

            // Create an instance of the ProductDbContext
            var dbContext = new ProductDbContext(options);

            // Create an instance of the ProductRepository using the ProductDbContext
            var productRepository = new ProductRepository(dbContext);

            // Create an instance of the ProductService using the ProductRepository
            var productService = new ProductService(productRepository);

            // Create test products with different quantities and prices
            var product1 = new Product { Name = "Product 1", Quantity = 10, Price = 5 };
            var product2 = new Product { Name = "Product 2", Quantity = 20, Price = 8 };

            // Add the test products to the repository
            productRepository.AddProduct(product1);
            productRepository.AddProduct(product2);

            // Act
            // Retrieve the inventory report
            var inventoryReport = productService.GetStockSummary();

            // Assert
            // Check if the inventory report is not null
            Assert.IsNotNull(inventoryReport);

            // Check if the report name is set correctly
            Assert.AreEqual("Inventory Summary", inventoryReport.ReportName);

            // Check if the total value is calculated correctly
            Assert.AreEqual(220, inventoryReport.TotalValue);

            // Check if the stock summary items are created correctly
            Assert.AreEqual(2, inventoryReport.StockSummaryItems.Count);

            // Check the stock summary item for the first product
            var stockSummaryItem1 = inventoryReport.StockSummaryItems.FirstOrDefault(x => x.ProductId == product1.ProductId);
            Assert.IsNotNull(stockSummaryItem1);
            Assert.AreEqual("Product 1", stockSummaryItem1.ProductName);
            Assert.AreEqual(10, stockSummaryItem1.StockQuantity);
            Assert.AreEqual(50, stockSummaryItem1.StockValue);

            // Check the stock summary item for the second product
            var stockSummaryItem2 = inventoryReport.StockSummaryItems.FirstOrDefault(x => x.ProductId == product2.ProductId);
            Assert.IsNotNull(stockSummaryItem2);
            Assert.AreEqual("Product 2", stockSummaryItem2.ProductName);
            Assert.AreEqual(20, stockSummaryItem2.StockQuantity);
            Assert.AreEqual(160, stockSummaryItem2.StockValue);
        }

    }
}