using ECommerceAPI.Application.Abstractions.Services;
using ECommerceAPI.Application.Repositories;
using ECommerceAPI.Domain.Entities;
using ECommerceAPI.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Persistence.Services;

public class OrderService : IOrderService
{
    readonly IOrderReadRepository _orderReadRepository;
    readonly ICustomerReadRepository _customerReadRepository;
    readonly IProductReadRepository _productReadRepository;
    readonly IMailService _mailService;

    public OrderService(IOrderReadRepository orderReadRepository, ICustomerReadRepository customerReadRepository, IProductReadRepository productReadRepository, IMailService mailService)
    {
        _orderReadRepository = orderReadRepository;
        _customerReadRepository = customerReadRepository;
        _productReadRepository = productReadRepository;
        _mailService = mailService;
    }

    public async Task GetCompletedOrder()
    {
        var order = await _orderReadRepository.Table.Include(o => o.Products).FirstOrDefaultAsync(p => p.IsOrdered == true) ?? new();

        var customer = await _customerReadRepository.Table.FirstOrDefaultAsync(c => c.Id == order.CustomerId) ?? new();

        if (order != null && customer != null) 
            await _mailService.SendCompletedOrderMailAsync(customer.Email, customer.Name, 
                order.Id.ToString(), order.CreatedDate, order.Products.FirstOrDefault() ?? new());
    }

    public async Task<Order> GetOrder(string id)
    {
        var order =  await _orderReadRepository.GetByIdAsync(id);
        return order;
    }
}
