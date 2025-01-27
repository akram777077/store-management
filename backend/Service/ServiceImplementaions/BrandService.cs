using Data.Entities;
using Infrastracture.Interfaces;
using ServiceLayer.Interfaces;
using ServiceLayer.ServiceBase;

namespace ServiceLayer.ServiceImplementations;

public class BrandService : GenericService<Brand>, IBrandService
{
    private readonly IBrandRepository _repository;

    public BrandService(IBrandRepository repository) : base(repository)
    {
        _repository = repository;
    }

    // Implement your functions here
}