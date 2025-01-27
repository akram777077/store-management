using Data.Entities;
using Infrastracture.Interfaces;
using ServiceLayer.Interfaces;
using ServiceLayer.ServiceBase;

namespace ServiceLayer.ServiceImplementations;

public class PricingService : GenericService<Pricing>, IPricingService
{
    private readonly IPricingRepository _repository;

    public PricingService(IPricingRepository repository) : base(repository)
    {
        _repository = repository;
    }

    // Implement your functions here
}