using Data.Entities;
using Infrastracture.Base;
using Infrastracture.Data;
using Infrastracture.Base;
using Infrastracture.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastracture.Repositories;
public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
{
    #region Fields
    private readonly DbSet<Category> _categories;
    #endregion
    #region Constructors
    public CategoryRepository(AppDbContext context) : base(context)
    {
        _categories = context.Categories;
    }
    #endregion

    #region Functions Handle
    //Implement your functions here 
    #endregion
}