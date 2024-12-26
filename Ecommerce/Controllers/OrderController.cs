using Ecommerce.Data;
using Ecommerce.IRepository;
using Ecommerce.Models;
using Ecommerce.Models.Dto;
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
    private readonly IOrderProductRepository _orderProductRepository;
    public OrderController(ICustomerRepository customerRepository, IProductRepository productRepository, IOrderRepository orderRepository, IOrderProductRepository orderProductRepository)
    {
        _customerRepository = customerRepository;
        _productRepository = productRepository;
        _orderRepository = orderRepository;
        _orderProductRepository = orderProductRepository;
    }
    [HttpPost]
    public async Task<ActionResult> AddOrder(OrderDto orderDto)
    {
        try
        {
            var customer = await _customerRepository.GetCustomerById(orderDto.CustomerId);
            if(customer == null) return BadRequest("Customer not found");

            var productIds = orderDto.Products.Select(p => p.ProductId).ToList();
            var products = await _productRepository.GetProductByListOfId(productIds);
            
            decimal sum = 0m;

            var orderProducts = new List<OrderProduct>();
            foreach(var product in products)
            {
                var requiredProduct = orderDto.Products.FirstOrDefault(p => p.ProductId == product.Id);
                if(requiredProduct == null) return BadRequest("Required product not found");

                if(product.Quantity < requiredProduct.Quantity)
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

            foreach(var orderProduct in orderProducts)
            {
                orderProduct.OrderId = order.Id;
            }
            
            await _orderProductRepository.AddOrderDetails(orderProducts);

            return Ok(order);
        }
        catch(Exception ex)
        {
            return StatusCode(500, new {Message = "An error occured while adding order", Details = ex.Message});
        }
    }
}