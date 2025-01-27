using Data.Entities;
using Infrastracture.Interfaces;
using ServiceLayer.Interfaces;
using ServiceLayer.ServiceBase;

namespace ServiceLayer.ServiceImplementations;

public class ProductDetailService : GenericService<ProductDetail>, IProductDetailService
{
    private readonly IProductDetailRepository _repository;

    public ProductDetailService(IProductDetailRepository repository) : base(repository)
    {
        _repository = repository;
    }

    // Implement your functions here
}