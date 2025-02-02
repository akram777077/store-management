﻿using Data.Entities;
using ServiceLayer.ServiceBase;

namespace ServiceLayer.Interfaces;

public interface ICategoryService : IGenericService<Category>
{
    public Task<Category> GetCategoryById(int id);
    public Task<Category>GetCategoryByName(string name);
    public Task<bool> IsCategoryNameExists(string name);
    public Task<bool> IsCategoryNameExists(string name, int id);
}