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
    [Route("api/[controller]")]
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

        [HttpGet]
        [Route("/SendCompletedOrderMail")]
        public async Task Get()
        {
            //var customerId = Guid.NewGuid();
            //await _customerWriteRepository.AddAsync(new() { Id = customerId, Name = "Ahmet Sağlam" });

            //await _orderWriteRepository.AddAsync(new() { Description = "Dummy 1", Address = "İstanbul, Çekmeköy", CustomerId = customerId });
            //await _orderWriteRepository.AddAsync(new() { Description = "Dummy 2", Address = "İstanbul, Kadıköy", CustomerId = customerId });
            //await _orderWriteRepository.SaveAsync();

            //Order order = await _orderReadRepository.GetByIdAsync("A6EA82F9-407D-4D22-3906-08DC773E405E");

            var order = await _orderReadRepository.Table.Include(o => o.Products).FirstOrDefaultAsync(p => p.IsOrdered == true);
            var customer = await _customerReadRepository.Table.FirstOrDefaultAsync(c => c.Id == order.CustomerId);

            _mailService.SendCompletedOrderMailAsync(customer.Email, customer.Name, order.Id.ToString(), order.CreatedDate, order.Products.FirstOrDefault());

            //_orderService.GetCompleteOrder();
        }
    }
}
