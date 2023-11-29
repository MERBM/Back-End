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
public class OrdersController : ControllerBase
{
    private readonly OrderService _orderService;

    public OrdersController(OrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet("{id}")]
    public ActionResult<Order> GetOrder(int id)
    {
        var order = _orderService.GetOrderById(id);
        if (order == null)
        {
            return NotFound();
        }
        return Ok(order);
    }

    [HttpPost]
    public ActionResult PlaceOrder(Order order)
    {
        _orderService.PlaceOrder(order);
        return Ok();
    }

    // Update an existing order
    [HttpPut("{id}")]
    public IActionResult UpdateOrder(int id, Order updatedOrder)
    {
        var existingOrder = _orderService.GetOrderById(id);
        if (existingOrder == null)
        {
            return NotFound();
        }

        // Additional logic can be added here to update only specific fields
        // or to handle updates in a certain way based on your application's requirements.
        _orderService.UpdateOrder(updatedOrder);
        return NoContent();
    }

    // Delete an order
    [HttpDelete("{id}")]
    public IActionResult DeleteOrder(int id)
    {
        var existingOrder = _orderService.GetOrderById(id);
        if (existingOrder == null)
        {
            return NotFound();
        }

        _orderService.DeleteOrder(id);
        return NoContent();
    }


    // Implement other endpoints for updating and deleting orders as needed
}

}