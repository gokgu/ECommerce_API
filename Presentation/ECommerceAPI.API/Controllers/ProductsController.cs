﻿using ECommerceAPI.Application.Abstractions.Services;
using ECommerceAPI.Application.Repositories;
using ECommerceAPI.Domain.Entities;
using ECommerceAPI.Persistence.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.API.Controllers
{
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

        //[HttpPost]
        //[Route("[controller]/Add")]
        //public async Task Add()
        //{
        //    await _productWriteRepository.AddRangeAsync(new()
        //    {
        //        new() { Id = Guid.NewGuid(), Name = "Product 1", Quantity = 10, Price = 100, CreatedDate = DateTime.UtcNow},
        //        new() { Id = Guid.NewGuid(), Name = "Product 2", Quantity = 20, Price = 200, CreatedDate = DateTime.UtcNow},
        //        new() { Id = Guid.NewGuid(), Name = "Product 3", Quantity = 30, Price = 300, CreatedDate = DateTime.UtcNow},
        //    });
        //    await _productWriteRepository.SaveAsync();
        //}

        //[HttpPost]
        //[Route("[controller]/Get/{id}")]
        //public async Task<ActionResult> GetProduct(string id)
        //{
        //    Product product = await _productReadRepository.GetByIdAsync(id);
        //    return Ok(product);
        //}

        //[HttpPost]
        //[Route("[controller]/GetAll")]
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
    }
}
