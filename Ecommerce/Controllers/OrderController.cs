using Ecommerce.Data;
using Ecommerce.IRepository;
using Ecommerce.Models;
using Ecommerce.Models.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Ecommerce.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IProductRepository _productRepository;
    private readonly IOrderRepository _orderRepository;
    public OrderController(ICustomerRepository customerRepository, IProductRepository productRepository, IOrderRepository orderRepository)
    {
        _customerRepository = customerRepository;
        _productRepository = productRepository;
        _orderRepository = orderRepository;
    }

    [HttpPost]
    [Authorize(Roles = "Customer")]
    public async Task<ActionResult> AddOrder(OrderDto orderDto)
    {
        try
        {
            var customer = await _customerRepository.GetCustomerById(orderDto.CustomerId);
            if (customer == null) return BadRequest("Customer not found");

            var productIds = orderDto.Products.Select(p => p.ProductId).ToList();
            var products = await _productRepository.GetProductByListOfId(productIds);

            decimal sum = 0m;

            var orderProducts = new List<OrderProduct>();
            foreach (var product in products)
            {
                var requiredProduct = orderDto.Products.FirstOrDefault(p => p.ProductId == product.Id);
                if (requiredProduct == null) return BadRequest("Required product not found");

                if (product.Quantity < requiredProduct.Quantity)
                {
                    return BadRequest($"{product.Name} does not have sufficient stock");
                }

                OrderProduct orderProduct = new OrderProduct()
                {
                    OrderId = 1,
                    ProductId = product.Id,
                    Quantity = requiredProduct.Quantity
                };

                product.Quantity -= requiredProduct.Quantity;

                sum += product.Price * requiredProduct.Quantity;
                orderProducts.Add(orderProduct);
            }

            await _productRepository.UpdateProductQuantity(products);

            Order order = new Order()
            {
                CustomerId = orderDto.CustomerId,
                TotalAmount = sum,
                Status = "Pending",
                OrderDate = DateOnly.FromDateTime(DateTime.UtcNow.Date)
            };

            await _orderRepository.AddOrder(order);

            foreach (var orderProduct in orderProducts)
            {
                orderProduct.OrderId = order.Id;
            }

            await _orderRepository.AddOrderDetails(orderProducts);

            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Message = "An error occured while adding order", Details = ex.Message });
        }
    }

    [HttpGet("/api/pending-orders")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult> GetPendingOrders()
    {
        try
        {
            var orders = await _orderRepository.GetPendingOrders();
            if(orders.Count < 1) return Ok("No pending orders");

            return Ok(orders);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Message = "An error occured while fetching pending orders", Details = ex.Message });
        }
    }


    [HttpGet("/api/completed-orders")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult> GetCompletedOrders()
    {
        try
        {
            var orders = await _orderRepository.GetCompletedOrders();
            if(orders.Count < 1) return Ok("No completed orders");

            return Ok(orders);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Message = "An error occured while fetching pending orders", Details = ex.Message });
        }
    }

    [HttpPut("{id:int}")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult> EditOrderStatus(int id, EditOrderDto editOrderDto)
    {
        try
        {
            var order = await _orderRepository.GetPendingOrderById(id);
            if (order == null) return BadRequest($"Order with Id {id} not found or completed");

            if (editOrderDto.Status != "Pending" && editOrderDto.Status != "Completed")
            {
                return BadRequest("Order status can only be Pending or Completed");
            }

            order.Status = editOrderDto.Status;

            await _orderRepository.EditOrderStatus(order);

            return Ok("Order changed successfully");
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Message = "An error occured while fetching pending orders", Details = ex.Message });
        }
    }

    [HttpPut("/api/cancel-order/{id:int}")]
    [Authorize]
    public async Task<ActionResult> CancelOrder(int id)
    {
        try
        {
            var order = await _orderRepository.GetPendingOrderById(id);
            if (order == null) return BadRequest($"Order with Id {id} not found or completed");

            order.IsDeleted = true;

            await _orderRepository.CancelOrder(order);

            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Message = "An error occured while fetching pending orders", Details = ex.Message });
        }
    }
}