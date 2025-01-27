using Data.Entities;
using Infrastracture.Interfaces;
using ServiceLayer.Interfaces;
using ServiceLayer.ServiceBase;

namespace ServiceLayer.ServiceImplementations;

public class InvoiceItemService : GenericService<InvoiceItem>, IInvoiceItemService
{
    private readonly IInvoiceItemRepository _repository;

    public InvoiceItemService(IInvoiceItemRepository repository) : base(repository)
    {
        _repository = repository;
    }

    // Implement your functions here
}