using Data.Entities.Identity;
using Infrastracture.Data;
using Infrastracture.Interfaces;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using ServiceLayer.Interfaces;
using ServiceLayer.ServiceBase;

namespace ServiceLayer.ServiceImplementations;

public class UserService : IUserService
{

    #region Fields
    private readonly AppDbContext _dbcontext;
    private readonly UserManager<User> _userManager;
    #endregion

    #region Constructor
    public UserService(AppDbContext dbcontext, UserManager<User> userManager)
    {
        _dbcontext = dbcontext;
        _userManager = userManager;
    }

    #endregion

    #region HandleFunctions
    public async Task<string> AddUserAsync(User user, string password)
    {
        var transact = await _dbcontext.Database.BeginTransactionAsync();
        try
        {
            user.CreatedAt = DateTime.Now;
            var createResult = await _userManager.CreateAsync(user, password);
            //Failed
            if (!createResult.Succeeded)
            {
                await transact.RollbackAsync();
                return string.Join(",", createResult.Errors.Select(x => x.Description).ToList());
            }
            var AddToRoleResult = await _userManager.AddToRoleAsync(user, "User");
            if (!AddToRoleResult.Succeeded)
            {
                await transact.RollbackAsync();
                return "Failed";
            }
            await transact.CommitAsync();
            return "Success";
        }
        catch (Exception)
        {

            await transact.RollbackAsync();
            return "Failed";
        }
    }
    #endregion
}