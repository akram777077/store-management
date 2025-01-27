using Data.Entities.Identity;
using Infrastracture.Interfaces;
using ServiceLayer.Interfaces;
using ServiceLayer.ServiceBase;

namespace ServiceLayer.ServiceImplementations;

public class UserService : GenericService<User>, IUserService
{
    private readonly IUserRepository _repository;

    public UserService(IUserRepository repository) : base(repository)
    {
        _repository = repository;
    }

    // Implement your functions here
}