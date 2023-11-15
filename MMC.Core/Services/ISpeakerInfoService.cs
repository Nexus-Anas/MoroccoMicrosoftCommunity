using MMC.Core.Models;

namespace MMC.Core.Services;

public interface ISpeakerInfoService
{
    Task<Speaker> Find(int id);
    Task<IEnumerable<Speaker>> FindAll();
    Task<Speaker> Create(Speaker entity);
    Task<Speaker> Update(int id, Speaker entity);
    Task Delete(int id);
}
