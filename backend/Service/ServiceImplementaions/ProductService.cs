using Data.Entities;
using Infrastracture.Interfaces;
using ServiceLayer.Interfaces;
using ServiceLayer.ServiceBase;

namespace ServiceLayer.ServiceImplementations;

public class ProductService : GenericService<Product>, IProductService
{
    private readonly IProductRepository _repository;

    public ProductService(IProductRepository repository) : base(repository)
    {
        _repository = repository;
    }

    // Implement your functions here
}