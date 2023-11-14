using MMC.Core.Models;

namespace MMC.Core.Services;

public interface ICategoryService
{
    Task<Category> Find(int id);
    Task<IEnumerable<Category>> FindAll();
    Task<Category> Create(Category entity);
    Task<Category> Update(int id, Category entity);
    Task Delete(int id);
}
