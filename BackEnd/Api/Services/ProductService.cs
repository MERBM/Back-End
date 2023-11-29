using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data;

namespace Api.Services
{
    public class ProductService
{
    private readonly MyDBContext _context;

    public ProductService(MyDBContext context)
    {
        _context = context;
    }

    public IEnumerable<Product> GetAllProducts()
    {
        return _context.Products.ToList();
    }

    public Product GetProductById(int id)
    {
        return _context.Products.FirstOrDefault(p => p.ProductID == id);
    }

    public void AddProduct(Product product)
    {
        _context.Products.Add(product);
        _context.SaveChanges();
    }

    public void UpdateProduct(Product product)
    {
        _context.Products.Update(product);
        _context.SaveChanges();
    }

    public void DeleteProduct(int id)
    {
        var product = _context.Products.FirstOrDefault(p => p.ProductID == id);
        if (product != null)
        {
            _context.Products.Remove(product);
            _context.SaveChanges();
        }
    }
     public void DeleteProducts()
    {
        var products = _context.Products.ToList();
        if (products != null)
        {
            _context.Products.RemoveRange(products);
            _context.SaveChanges();
        }
    }
}

}