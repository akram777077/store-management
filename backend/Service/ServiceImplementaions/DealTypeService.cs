using Data.Entities;
using Infrastracture.Interfaces;
using ServiceLayer.Interfaces;
using ServiceLayer.ServiceBase;

namespace ServiceLayer.ServiceImplementations;

public class DealTypeService : GenericService<DealType>, IDealTypeService
{
    private readonly IDealTypeRepository _repository;

    public DealTypeService(IDealTypeRepository repository) : base(repository)
    {
        _repository = repository;
    }

    // Implement your functions here
}