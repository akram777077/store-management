using Data.Entities;
using Infrastracture.Interfaces;
using ServiceLayer.Interfaces;
using ServiceLayer.ServiceBase;

namespace ServiceLayer.ServiceImplementations;
public class CategoryService : GenericService<Category>, ICategoryService
{
    #region Fields
    private readonly ICategoryRepository _repository;
    #endregion

    #region Constructor
    public CategoryService(ICategoryRepository repository) : base(repository)
    {
        _repository = repository;
    }
    #endregion

    #region Functions Handling
    //implement your functions here
    #endregion
}
