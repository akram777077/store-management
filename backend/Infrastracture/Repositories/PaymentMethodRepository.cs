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

    // Implement your functions here
}