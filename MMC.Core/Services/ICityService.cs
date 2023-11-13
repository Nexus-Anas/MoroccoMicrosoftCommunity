using MMC.Core.Models;

namespace MMC.Core.Services;

public interface ICityService
{
    Task<City> Find(int id);
    Task<IEnumerable<City>> FindAll();
    Task<City> Create(City entity);
    Task<City> Update(int id, City entity);
    Task Delete(int id);
}
