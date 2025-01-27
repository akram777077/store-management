using Data.Entities;
using Infrastracture.Interfaces;
using ServiceLayer.Interfaces;
using ServiceLayer.ServiceBase;

namespace ServiceLayer.ServiceImplementations;

public class SaleTypeService : GenericService<SaleType>, ISaleTypeService
{
    private readonly ISaleTypeRepository _repository;

    public SaleTypeService(ISaleTypeRepository repository) : base(repository)
    {
        _repository = repository;
    }

    // Implement your functions here
}