using ECommerceAPI.Application.Abstractions;
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
            new() { Id = Guid.NewGuid(), Name = "Product 1", Quantity =10, Price = 100, IsOrdered = true },
            new() { Id = Guid.NewGuid(), Name = "Product 2", Quantity =10, Price = 200, IsOrdered = false },
            new() { Id = Guid.NewGuid(), Name = "Product 3", Quantity =10, Price = 300, IsOrdered = true },
            new() { Id = Guid.NewGuid(), Name = "Product 4", Quantity =10, Price = 400, IsOrdered = false },
            new() { Id = Guid.NewGuid(), Name = "Product 5", Quantity =10, Price = 500, IsOrdered = true }
        };
}
