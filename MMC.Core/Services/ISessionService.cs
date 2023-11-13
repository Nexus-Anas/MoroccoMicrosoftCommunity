using MMC.Core.Models;

namespace MMC.Core.Services;

internal interface ISessionService
{
    Task<Session> Find(int id);
    Task<IEnumerable<Session>> FindAll();
    Task<Session> Create(Session entity);
    Task<Session> Update(int id, Session entity);
    Task Delete(int id);
}
