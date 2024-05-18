using ECommerceAPI.Application.Abstractions.Services;
using ECommerceAPI.Application.Repositories;
using ECommerceAPI.Domain.Entities;
using ECommerceAPI.Persistence.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.API.Controllers
{
    [Route("[controller]/AddProduct")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        readonly IProductService _productService;
        readonly IMailService _mailService;
        readonly private IProductWriteRepository _productWriteRepository;
        readonly private IProductReadRepository _productReadRepository;
        readonly private ICustomerWriteRepository _customerWriteRepository;
        readonly private IOrderWriteRepository _orderWriteRepository;

        public ProductsController(
            IProductService productService,
            IMailService mailService,
            IProductWriteRepository productWriteRepository,
            IProductReadRepository productReadRepository,
            ICustomerWriteRepository customerWriteRepository,
            IOrderWriteRepository orderWriteRepository)
        {
            _productService = productService;
            _mailService = mailService;
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
            _customerWriteRepository = customerWriteRepository;
            _orderWriteRepository = orderWriteRepository;
        }

        //[HttpGet]
        //public IActionResult GetProducts()
        //{
        //    var products = _productService.GetProducts();
        //    return Ok(products);
        //}

        //[HttpGet]
        //public async Task<IActionResult> ExampleMailTest() 
        //{
        //    await _mailService.SendMailAsync("ahmet.gokhan.gurel@gmail.com", "Örnek Mail", "<strong>Bu bir örnek maildir.</strong>");
        //    return Ok();
        //}

        [HttpGet]
        public async Task Get()
        {
            await _productWriteRepository.AddRangeAsync(new()
            {
                new() { Id = Guid.NewGuid(), Name = "Product 1", Quantity = 10, Price = 100, CreatedDate = DateTime.UtcNow},
                new() { Id = Guid.NewGuid(), Name = "Product 2", Quantity = 20, Price = 200, CreatedDate = DateTime.UtcNow},
                new() { Id = Guid.NewGuid(), Name = "Product 3", Quantity = 30, Price = 300, CreatedDate = DateTime.UtcNow},
            });
            await _productWriteRepository.SaveAsync();

            //var customerId = Guid.NewGuid();
            //await _customerWriteRepository.AddAsync(new() { Id = customerId, Name = "Ahmet Sağlam" });

            //await _orderWriteRepository.AddAsync(new() { Description = "Dummy 1", Address = "İstanbul, Çekmeköy", CustomerId = customerId, IsOrdered = true });
            //await _orderWriteRepository.AddAsync(new() { Description = "Dummy 2", Address = "İstanbul, Kadıköy", CustomerId = customerId, IsOrdered = false });
            //await _orderWriteRepository.SaveAsync();
        }

        //[HttpGet("{id}")]
        //public async Task<ActionResult> Get(string id)
        //{
        //    Product product = await _productReadRepository.GetByIdAsync(id);
        //    return Ok(product);
        //}
    }
}
