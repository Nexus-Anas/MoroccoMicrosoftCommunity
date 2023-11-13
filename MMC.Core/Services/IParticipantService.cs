using MMC.Core.Models;

namespace MMC.Core.Services;

internal interface IParticipantService
{
    Task<Participant> Find(int id);
    Task<IEnumerable<Participant>> FindAll();
    Task<Participant> Create(Participant entity);
    Task<Participant> Update(int id, Participant entity);
    Task Delete(int id);
}
