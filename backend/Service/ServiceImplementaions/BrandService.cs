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
    
    public async Task<Brand?> GetBrandByNameAsync(string name)
    {
        return await _repository.GetBrandByNameAsync(name);
    }

    // Implement your functions here
}