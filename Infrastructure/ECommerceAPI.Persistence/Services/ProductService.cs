using ECommerceAPI.Application.Abstractions.Services;
using ECommerceAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Persistence.Concretes;

public class ProductService : IProductService
{
    public List<Product> GetProducts()
        => new()
        {
            new() { Id = Guid.NewGuid(), Name = "Product 1", Quantity =10, Price = 100},
            new() { Id = Guid.NewGuid(), Name = "Product 2", Quantity =10, Price = 200},
            new() { Id = Guid.NewGuid(), Name = "Product 3", Quantity =10, Price = 300},
            new() { Id = Guid.NewGuid(), Name = "Product 4", Quantity =10, Price = 400},
            new() { Id = Guid.NewGuid(), Name = "Product 5", Quantity =10, Price = 500}
        };
}
