using System;
namespace EShop.Domain.AggregatesModel.CategoryAggregateModel
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Category Add(Category category);
        Category Update(Category category);
        Task<Category> GetCategoryByName(string name);
        Task<Category> GetCategoryById(int id);
        Task<List<Category>> GetCategories();
    }
}

