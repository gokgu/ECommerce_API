using ECommerceAPI.Application.Abstractions.Services;
using ECommerceAPI.Application.Abstractions;
using ECommerceAPI.Application.Repositories;
using ECommerceAPI.Persistence.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.API.Controllers
{
    [ApiController]
    public class CustomersController : ControllerBase
    {
        readonly private ICustomerWriteRepository _customerWriteRepository;
        readonly private ICustomerReadRepository _customerReadRepository;

        public CustomersController(
            ICustomerWriteRepository customerWriteRepository,
            ICustomerReadRepository customerReadRepository)
        {
            _customerWriteRepository = customerWriteRepository;
            _customerReadRepository = customerReadRepository;
        }

        //[HttpPost]
        //[Route("[controller]/Add")]
        //public async Task Add()
        //{
        //    var customerId = Guid.NewGuid();
        //    await _customerWriteRepository.AddAsync(new() { Id = customerId, Name = "Ahmet Sağlam" });
        //    await _customerWriteRepository.SaveAsync();
        //}
    }
}
