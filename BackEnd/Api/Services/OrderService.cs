using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data;
using Microsoft.EntityFrameworkCore;

namespace Api.Services
{
    public class OrderService
    {
        private readonly MyDBContext _context;

        public OrderService(MyDBContext context)
        {
            _context = context;
        }

        // Place a new order
        public void PlaceOrder(Order newOrder)
        {
            _context.Orders.Add(newOrder);
            _context.SaveChanges();
        }

        // Get order by ID
        public Order GetOrderById(int id)
        {
            return _context.Orders
                           .Include(o => o.OrderItems)
                           .FirstOrDefault(o => o.OrderID == id);
        }

        // Get all orders for a user
        public IEnumerable<Order> GetOrdersByUserId(int userId)
        {
            return _context.Orders
                           .Where(o => o.UserID == userId)
                           .Include(o => o.OrderItems)
                           .ToList();
        }

        // Update an existing order (if your business logic allows this)
        public void UpdateOrder(Order order)
        {
            _context.Orders.Update(order);
            _context.SaveChanges();
        }

        // Delete an order
        public void DeleteOrder(int id)
        {
            var order = _context.Orders.FirstOrDefault(o => o.OrderID == id);
            if (order != null)
            {
                _context.Orders.Remove(order);
                _context.SaveChanges();
            }
        }
    }

}