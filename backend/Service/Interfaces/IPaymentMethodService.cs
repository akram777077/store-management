using Data.Entities;
using ServiceLayer.ServiceBase;

namespace ServiceLayer.Interfaces;

public interface IPaymentMethodService : IGenericService<PaymentMethod>
{
    public Task<PaymentMethod?> GetPaymentMethodByNameAsync(string name);
    public Task<bool> IsPaymentMethodNameExistsAsync(string name);
    public Task<bool> IsPaymentMethodNameExistsAsync(string name, long id);
}