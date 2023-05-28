using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using StockSense.Model;
using StockSense.Services;



namespace StockSenseAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductService _productService;
        private readonly CategoryService _categoryService;
        private readonly SupplierService _supplierService;

        public ProductsController(ProductService productService, CategoryService categoryService, SupplierService supplierService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _supplierService = supplierService;
        }
        #region <----- CRUD Products
        [HttpGet]
        public ActionResult<List<Product>> GetAllProducts()
        {
            return _productService.GetAllProducts();
        }

        // GET api/products/{id}
        [HttpGet("id:int")]
        public IActionResult GetProductById(int id)
        {
            var product = _productService.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public IActionResult AddProduct(ProductDto productDto)
        {
            if (productDto == null)
            {
                return BadRequest();
            }

            var product = new Product
            {
                Name = productDto.Name,
                Description = productDto.Description,
                Price = productDto.Price,
                Quantity = productDto.Quantity,
                CategoryId = productDto.CategoryId,
                SupplierId = productDto.SupplierId
            };

             _productService.AddProduct(product);

            return Ok("Product Added");
        }

        [HttpPut("id:int")]
        public IActionResult UpdateProduct(int id, ProductDto productDto)
        {
            var existingProduct = _productService.GetProductById(id);

            if (id == null)
            {
                return NotFound();
            }

            existingProduct.Name = productDto.Name;
            existingProduct.Description = productDto.Description;
            existingProduct.Price = productDto.Price;
            existingProduct.Quantity = productDto.Quantity;
            existingProduct.CategoryId = productDto.CategoryId;
            existingProduct.SupplierId = productDto.SupplierId;

            _productService.UpdateProduct(existingProduct);

            return Ok("Product Updated");

        }

        [HttpDelete("id:int")]
        public IActionResult DeleteProduct(int id)            
        {
            var product = _productService.GetProductById(id);

            if (id == null)
            {
                return NotFound();
            }

            _productService.DeleteProduct(product);

            return Ok("Product Deleted");

        }
        #endregion 

        [HttpPost("category")]
        public IActionResult AddCategory(CategoryDto category)
        {
            if (category == null)
            {
                return BadRequest();
            }

            var newCategory = new Category
            {
                Name = category.Name,
            };

            _categoryService.AddCategory(newCategory);

            return Ok("category added");

        }

        [HttpPost("supplier")]
        public IActionResult AddSupplier(SupplierDto supplierDto)
        {
            if (supplierDto == null)
            {
                return BadRequest();
            }

            var newSupplier = new Supplier
            {
                Name = supplierDto.Name,
                ContactNumber = supplierDto.ContactNumber,
                Email = supplierDto.Email,
            };

            _supplierService.AddSupplier(newSupplier);

            return Ok("supplier added");

        }

        [HttpGet("report")]
        public ActionResult<InventoryReport> GetStockSummary()
        {
            InventoryReport report = _productService.GetStockSummary();

            if (report == null)
            {
                return NotFound();
            }

            return Ok(report);
        }

        [HttpPost("{id}/increaseStock")]
        public IActionResult IncreaseStock(int id, int quantity)
        {
            _productService.IncreaseStock(id, quantity);
            string message = $"Stock increased by {quantity} for product with ID {id}.";
            return Ok(message);
        }

        [HttpPost("{id}/decreaseStock")]
        public IActionResult DecreaseStock(int id, int quantity)
        {
            _productService.DecreaseStock(id, quantity);
            string message = $"Stock decreased by {quantity} for product with ID {id}.";
            return Ok(message);
        }
    }
}
