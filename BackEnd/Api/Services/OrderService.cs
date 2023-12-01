using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data;
using Microsoft.EntityFrameworkCore;

namespace Api.Services
{
     public class Orderdto
    {
        public int OrderID { get; set; }
        public int UserID { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string DeliveryAddress { get; set; }
        public string PhoneNumber { get; set; }
        public ICollection<OrderItemdto> OrderItems { get; set; }
    }

    public class OrderItemdto
    {
        public int OrderItemID { get; set; }
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public decimal PriceAtOrder { get; set; }
        
    }

    public class OrderService
    {
        private readonly MyDBContext _context;

        public OrderService(MyDBContext context)
        {
            _context = context;
        }

        // Place a new order
        public void PlaceOrder(Orderdto newOrder)
        {
            Order order = new Order();
            order.UserID = newOrder.UserID;
            order.OrderDate = DateTime.Now;
            order.User = _context.users.FirstOrDefault(u => u.UserID == newOrder.UserID);
            order.DeliveryAddress = newOrder.DeliveryAddress;
            order.PhoneNumber = newOrder.PhoneNumber;
            order.TotalAmount = newOrder.TotalAmount;
            order.OrderItems = new List<OrderItem>();
            order.OrderItems = newOrder.OrderItems.Select(oi => new OrderItem{ OrderID = order.OrderID, ProductID = oi.ProductID, Quantity = oi.Quantity, PriceAtOrder = oi.PriceAtOrder}).ToList();
            _context.Orders.Add(order);
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

        public List<Order> GetOrders()
        {
            return _context.Orders.Include(o => o.OrderItems).ThenInclude(x=>x.Product).Include(o => o.User).ToList();
        }
        public List<Order> GetOrdersByUserId(int userid)
        {
            return _context.Orders.Include(o => o.OrderItems).ThenInclude(x=>x.Product).Include(o => o.User).Where(o => o.UserID == userid).ToList();
        }
        public bool DeleteOrderForUser(int userid,int Orderid)
        {
            // Assuming you have a DbContext named _context
            // Retrieve the order for the specified user
            var order = _context.Orders.FirstOrDefault(o => o.OrderID == Orderid && o.UserID == userid);

            if (order == null)
            {
                // Order not found or does not belong to the user
                return false;
            }

            // Check if the order was placed within the last 3 hours
            TimeSpan timeSinceOrder = DateTime.UtcNow - order.OrderDate;
            if (timeSinceOrder <= TimeSpan.FromHours(3))
            {
                // Delete the order
                _context.Orders.Remove(order);
                _context.SaveChanges();
                return true;
            }

            // Order is older than 3 hours, do not delete
            return false;
        }
        
    }

}