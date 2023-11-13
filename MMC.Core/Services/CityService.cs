using MMC.Core.Interfaces;
using MMC.Core.Models;

namespace MMC.Core.Services;

public class CityService : ICityService
{
    private readonly IRepository<City> _repo;
    public CityService(IRepository<City> repo) => _repo = repo;




    public async Task<City> Find(int id)
        => await _repo.Get(id);
    public async Task<IEnumerable<City>> FindAll()
        => await _repo.GetAll();
    public async Task<City> Create(City entity)
        => await _repo.Post(entity);
    public async Task<City> Update(int id, City entity)
        => await _repo.Put(id, entity);
    public async Task Delete(int id)
        => await _repo.Remove(id);
}
