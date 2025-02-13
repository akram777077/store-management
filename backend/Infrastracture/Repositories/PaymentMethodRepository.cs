using Data.Entities;
using Infrastracture.Data;
using Infrastracture.Base;
using Infrastracture.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastracture.Repositories;

public class PaymentMethodRepository : GenericRepository<PaymentMethod>, IPaymentMethodRepository
{
    private readonly DbSet<PaymentMethod> _paymentMethods;

    public PaymentMethodRepository(AppDbContext context) : base(context)
    {
        _paymentMethods = context.PaymentMethods;
    }

    public async Task<PaymentMethod?> GetPaymentMethodByNameAsync(string name)
    {
        return await _paymentMethods.FirstOrDefaultAsync(x => x.MethodName == name);
    }

    // Implement your functions here
}