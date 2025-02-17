using EcommerceMVC.IRepository;
using EcommerceMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EcommerceMVC.Controllers;

public class OrderController : Controller
{
    private readonly IOrderRepository _orderRepository;
    private readonly IProductRepository _productRepository;
    public OrderController(IOrderRepository orderRepository, IProductRepository productRepository)
    {
        _orderRepository = orderRepository;
        _productRepository = productRepository;
    }

    [HttpGet("/pending-orders")]
    public async Task<ActionResult<List<Order>>> Index()
    {
        try
        {
            var orders = await _orderRepository.GetAllPendingOrders();
            if(orders == null) orders = [];

            return View(orders);
        }
        catch (Exception ex)
        {
            return View("Error", new { message = ex.Message });
        }
    }

    [HttpGet("/completed-orders")]
    public async Task<ActionResult<List<Order>>> CompletedOrders()
    {
        try
        {
            var orders = await _orderRepository.GetAllCompletedOrders();
            if(orders == null) orders = [];

            return View("Completed", orders);
        }
        catch (Exception ex)
        {
            return View("Error", new { message = ex.Message });
        }
    }

    public async Task<IActionResult> Create()
    {
        try
        {
            var products = await _productRepository.GetAllActiveProducts();
            ViewBag.Products = new SelectList(products, "Id", "Name");
            return View();
        }
        catch (Exception ex)
        {
            return View("Error", new { message = ex.Message });
        }
    }
}