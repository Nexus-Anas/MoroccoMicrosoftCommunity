using MMC.Core.Models;

namespace MMC.Core.Services;

public interface ICityService
{
    Task<City> GetCity(int id);
    Task<IEnumerable<City>> GetAllCities();
    Task<City> CreateCity(City entity);
    Task<City> UpdateCity(int id, City entity);
    Task DeleteCity(int id);
}
