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
    readonly IMailService _mailService;

    public OrderService(IOrderReadRepository orderReadRepository, IMailService mailService)
    {
        _orderReadRepository = orderReadRepository;
        _mailService = mailService;
    }

    public async Task GetCompleteOrder()
    {
        //var order =  _orderReadRepository.GetByIdAsync("A6EA82F9-407D-4D22-3906-08DC773E405E");

        var order = await _orderReadRepository.Table.Include(o => o.Products).FirstOrDefaultAsync(p => p.IsOrdered == true);
        var customer = await _customerReadRepository.Table.FirstOrDefaultAsync(c => c.Id == order.CustomerId);

        _mailService.SendCompletedOrderMailAsync(customer.Email, customer.Name, order.Id.ToString(), order.CreatedDate, order.Products.FirstOrDefault());
    }
}
