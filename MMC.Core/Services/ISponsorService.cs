using MMC.Core.Models;

namespace MMC.Core.Services;

public interface ISponsorService
{
    Task<Sponsor> Find(int id);
    Task<IEnumerable<Sponsor>> FindAll();
    Task<Sponsor> Create(Sponsor entity);
    Task<Sponsor> Update(int id, Sponsor entity);
    Task Delete(int id);
}
