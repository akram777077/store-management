using Data.Entities;
using Infrastracture.Interfaces;
using ServiceLayer.Interfaces;
using ServiceLayer.ServiceBase;

namespace ServiceLayer.ServiceImplementations;

public class SaleService : GenericService<Sale>, ISaleService
{
    private readonly ISaleRepository _repository;

    public SaleService(ISaleRepository repository) : base(repository)
    {
        _repository = repository;
    }

    // Implement your functions here
}