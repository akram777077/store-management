using Data.Entities;
using Infrastracture.Interfaces;
using Microsoft.EntityFrameworkCore;
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
        return await _repository.GetListAsync()
            .FirstOrDefaultAsync(c => EF.Functions.ILike(c.MethodName, name));
    }

    public async Task<bool> IsPaymentMethodNameExistsAsync(string name)
    {
        return await _repository.GetListAsync()
               .AnyAsync(c => EF.Functions.ILike(c.MethodName, name));
    }
    
    public async Task<bool> IsPaymentMethodNameExistsAsync(string name, long id)
    {
        return await _repository.GetListAsync()
            .AnyAsync(c => EF.Functions.ILike(c.MethodName, name) && c.Id != id);
    }

    // Implement your functions here
}