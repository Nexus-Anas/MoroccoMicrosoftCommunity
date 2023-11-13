using MMC.Core.Interfaces;
using MMC.Core.Models;
using System.Threading.Tasks;

namespace MMC.Core.Services;

public class CityService : ICityService
{
    private readonly IRepository<City> _repo;
    public CityService(IRepository<City> repo) => _repo = repo;




    public async Task<City> GetCity(int id)
        => await _repo.Get(id);
    public async Task<IEnumerable<City>> GetAllCities()
        => await _repo.GetAll();
    public async Task<City> CreateCity(City entity)
        => await _repo.Add(entity);
    public async Task<City> UpdateCity(int id, City entity)
        => await _repo.Update(id, entity);
    public async Task DeleteCity(int id)
        => await _repo.Delete(id);
}
