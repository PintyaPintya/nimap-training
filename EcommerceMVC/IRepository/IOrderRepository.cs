using EcommerceMVC.Models;
using EcommerceMVC.Models.Dto;

namespace EcommerceMVC.IRepository;

public interface IOrderRepository
{
    Task<List<DisplayOrderDto>> GetAllPendingOrders();
    Task<List<DisplayOrderDto>> GetAllCompletedOrders();
}