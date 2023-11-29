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
public class CategoriesController : ControllerBase
{
    private readonly CategoryService _categoryService;

    public CategoriesController(CategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    // Get all categories
    [HttpGet]
    public ActionResult<IEnumerable<object>> GetAll()
    {
        return Ok(_categoryService.GetAllCategories());
    }

    // Get category by ID
    [HttpGet("{id}")]
    public ActionResult<Category> GetById(int id)
    {
        var category = _categoryService.GetCategoryById(id);
        if (category == null)
        {
            return NotFound();
        }
        return Ok(category);
    }

    // Create a new category
    [HttpPost]
    public ActionResult<Category> Create(Category category)
    {
        _categoryService.AddCategory(category);
        return CreatedAtAction(nameof(GetById), new { id = category.CategoryID }, category);
    }

    // Update an existing category
    [HttpPut("{id}")]
    public IActionResult Update(int id, Category category)
    {
        if (id != category.CategoryID)
        {
            return BadRequest();
        }

        _categoryService.UpdateCategory(category);
        return NoContent();
    }

    // Delete a category
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var existingCategory = _categoryService.GetCategoryById(id);
        if (existingCategory == null)
        {
            return NotFound();
        }

        _categoryService.DeleteCategory(id);
        return NoContent();
    }
}

}