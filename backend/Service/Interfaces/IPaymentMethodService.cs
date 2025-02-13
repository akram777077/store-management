using Data.Entities;
using ServiceLayer.ServiceBase;

namespace ServiceLayer.Interfaces;

public interface IPaymentMethodService : IGenericService<PaymentMethod>
{
    Task<PaymentMethod?> GetPaymentMethodByNameAsync(string name);

}