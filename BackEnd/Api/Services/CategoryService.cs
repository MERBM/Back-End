using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data;

namespace Api.Services
{
    public class CategoryService
{
    private readonly MyDBContext _context;

    public CategoryService(MyDBContext context)
    {
        _context = context;
    }

    // Get all categories
    public IEnumerable<object> GetAllCategories()
    {
        return _context.Categories.Select(c => new { c.CategoryID, c.Name , count= c.Products.Count() }).ToList();
    }

    // Get a category by ID
    public Category GetCategoryById(int id)
    {
        return _context.Categories.FirstOrDefault(c => c.CategoryID == id);
    }

    // Add a new category
    public void AddCategory(Category category)
    {
        _context.Categories.Add(category);
        _context.SaveChanges();
    }

    // Update an existing category
    public void UpdateCategory(Category category)
    {
        _context.Categories.Update(category);
        _context.SaveChanges();
    }

    // Delete a category
    public void DeleteCategory(int id)
    {
        var category = _context.Categories.FirstOrDefault(c => c.CategoryID == id);
        if (category != null)
        {
            _context.Categories.Remove(category);
            _context.SaveChanges();
        }
    }
}

}