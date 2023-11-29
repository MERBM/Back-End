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

    [HttpPost]
    public ActionResult<Product> Create(Product product)
    {
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