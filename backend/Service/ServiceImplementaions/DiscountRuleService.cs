using Data.Entities;
using Infrastracture.Interfaces;
using ServiceLayer.Interfaces;
using ServiceLayer.ServiceBase;

namespace ServiceLayer.ServiceImplementations;

public class DiscountRuleService : GenericService<DiscountRule>, IDiscountRuleService
{
    private readonly IDiscountRuleRepository _repository;

    public DiscountRuleService(IDiscountRuleRepository repository) : base(repository)
    {
        _repository = repository;
    }

    // Implement your functions here
}