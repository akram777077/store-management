using Data.Entities.Identity;
using ServiceLayer.ServiceBase;

namespace ServiceLayer.Interfaces;

public interface IUserService 
{
    public Task<string> AddUserAsync(User user, string password);
}