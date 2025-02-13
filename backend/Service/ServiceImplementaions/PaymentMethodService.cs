using Data.Entities;
using Infrastracture.Interfaces;
using ServiceLayer.Interfaces;
using ServiceLayer.ServiceBase;

namespace ServiceLayer.ServiceImplementations;

public class PaymentMethodService : GenericService<PaymentMethod>, IPaymentMethodService
{
    private readonly IPaymentMethodRepository _repository;

    public PaymentMethodService(IPaymentMethodRepository repository) : base(repository)
    {
        _repository = repository;
    }

    public async Task<PaymentMethod?> GetPaymentMethodByNameAsync(string name)
    {
        return await _repository.GetPaymentMethodByNameAsync(name);
    }

    // Implement your functions here
}