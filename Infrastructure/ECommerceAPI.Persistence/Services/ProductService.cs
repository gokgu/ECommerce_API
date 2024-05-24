using ECommerceAPI.Application.Abstractions.Services;
using ECommerceAPI.Application.Repositories;
using ECommerceAPI.Domain.Entities;
using ECommerceAPI.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Persistence.Concretes;

public class ProductService : IProductService
{
    readonly IProductReadRepository _produtReadRepository;

    public ProductService(IProductReadRepository produtReadRepository)
    {
        _produtReadRepository = produtReadRepository;
    }

    public List<Product> GetProducts()
    {
        var products =  _produtReadRepository.GetAll().ToList();
        return products.ToList();
    }
}
