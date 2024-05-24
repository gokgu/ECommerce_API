using ECommerceAPI.Application.Abstractions.Services;
using ECommerceAPI.Application.Repositories;
using ECommerceAPI.Domain.Entities;
using ECommerceAPI.Infrastructure.Services;
using ECommerceAPI.Persistence.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerceAPI.API.Controllers
{
    [ApiController]
    public class OrdersController : ControllerBase
    {
        readonly private IOrderWriteRepository _orderWriteRepository;
        readonly private IOrderReadRepository _orderReadRepository;
        readonly private ICustomerWriteRepository _customerWriteRepository;
        readonly private ICustomerReadRepository _customerReadRepository;
        readonly IOrderService _orderService;
        readonly IMailService _mailService;

        public OrdersController(
            IOrderWriteRepository orderWriteRepository,
            IOrderReadRepository orderReadRepository,
            ICustomerWriteRepository customerWriteRepository,
            ICustomerReadRepository customerReadRepository,
            IOrderService orderService,
            IMailService mailService)
        {
            _orderWriteRepository = orderWriteRepository;
            _orderReadRepository = orderReadRepository;
            _customerWriteRepository = customerWriteRepository;
            _customerReadRepository = customerReadRepository;
            _orderService = orderService;
            _mailService = mailService;
        }

        [HttpPost]
        [Route("[controller]/SendCompletedOrderMail")]
        public async Task SendCompletedOrderMail()
        {
            await _orderService.GetCompletedOrder();
        }

        //[HttpPost]
        //[Route("[controller]/Add")]
        //public async Task AddOrder()
        //{
        //    var customerId = Guid.NewGuid();
        //    await _customerWriteRepository.AddAsync(new() { Id = customerId, Name = "Ahmet Sağlam" });

        //    await _orderWriteRepository.AddAsync(new() { Description = "Dummy 1", Address = "İstanbul, Çekmeköy", CustomerId = customerId });
        //    await _orderWriteRepository.AddAsync(new() { Description = "Dummy 2", Address = "İstanbul, Kadıköy", CustomerId = customerId });
        //    await _orderWriteRepository.SaveAsync();
        //}

        //[HttpPost]
        //[Route("[controller]/Get/{id}")]
        //public async Task<ActionResult> GetOrder(string id)
        //{
        //    Order order = await _orderService.GetOrder(id);
        //    return Ok(order);
        //}
    }
}
