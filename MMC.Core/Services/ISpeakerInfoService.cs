using MMC.Core.Models;

namespace MMC.Core.Services;

public interface ISpeakerInfoService
{
    Task<SpeakerInfo> Find(int id);
    Task<IEnumerable<SpeakerInfo>> FindAll();
    Task<SpeakerInfo> Create(SpeakerInfo entity);
    Task<SpeakerInfo> Update(int id, SpeakerInfo entity);
    Task Delete(int id);
}
