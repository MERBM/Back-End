using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data;
using Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductsController(ProductService productService)
        {
            _productService = productService;
        }

        // Define endpoints using _productService
        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetAll()
        {
            return Ok(_productService.GetAllProducts());
        }

        [HttpGet("{id}")]
        public ActionResult<Product> GetById(int id)
        {
            var product = _productService.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
        public class ProductViewModel
        {
            public string productName { get; set; }
            public string productDescription { get; set; }
            public decimal productPrice { get; set; }
            public int productCategory { get; set; }
            public IFormFile productImage { get; set; }
        }

        [HttpPost]
        public async Task<ActionResult<Product>> Create([FromForm] ProductViewModel model)
        {
            // Handle the file here
            string imageUrl = null;
            if (model.productImage != null && model.productImage.Length > 0)
            {
                // Process the file here. For example, save it to the server and get the URL
                var uploadsFolderPath = Path.Combine(Environment.CurrentDirectory, "images");
                    if (!Directory.Exists(uploadsFolderPath))
                        Directory.CreateDirectory(uploadsFolderPath);
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(model.productImage.FileName);
                imageUrl = "images/"+ fileName ;
                var filePath = Path.Combine(uploadsFolderPath, fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await model.productImage.CopyToAsync(stream);
                }
            }

            // Map ViewModel to your domain model (Product)
            var product = new Product
            {
                Name = model.productName,
                Description = model.productDescription,
                Price = model.productPrice,
                CategoryID = model.productCategory,
                ImageURL = imageUrl!
            };

            _productService.AddProduct(product);

            return CreatedAtAction(nameof(GetById), new { id = product.ProductID }, product);
        }


        [HttpPut("{id}")]
        public IActionResult Update(int id, Product product)
        {
            if (id != product.ProductID)
            {
                return BadRequest();
            }

            _productService.UpdateProduct(product);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingProduct = _productService.GetProductById(id);
            if (existingProduct == null)
            {
                return NotFound();
            }

            _productService.DeleteProduct(id);
            return NoContent();
        }

        [HttpDelete]
        public IActionResult DeleteAll(int id)
        {
            _productService.DeleteProducts();
            return NoContent();
        }

    }

}