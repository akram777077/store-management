using Data.Entities;
using Infrastracture.Data;
using Infrastracture.Base;
using Infrastracture.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastracture.Repositories;

public class InvoiceItemRepository : GenericRepository<InvoiceItem>, IInvoiceItemRepository
{
    private readonly DbSet<InvoiceItem> _invoiceItems;

    public InvoiceItemRepository(AppDbContext context) : base(context)
    {
        _invoiceItems = context.InvoiceItems;
    }

    // Implement your functions here
}