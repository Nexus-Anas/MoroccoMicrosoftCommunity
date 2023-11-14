using MMC.Core.Interfaces;
using MMC.Core.Models;

namespace MMC.Core.Services;

public class CategoryService : ICategoryService
{
    private readonly IRepository<Category> _repo;
    public CategoryService(IRepository<Category> repo) => _repo = repo;




    public async Task<Category> Find(int id)
        => await _repo.Get(id);
    public async Task<IEnumerable<Category>> FindAll()
        => await _repo.GetAll();
    public async Task<Category> Create(Category entity)
        => await _repo.Post(entity);
    public async Task<Category> Update(int id, Category entity)
        => await _repo.Put(id, entity);
    public async Task Delete(int id)
        => await _repo.Remove(id);
}