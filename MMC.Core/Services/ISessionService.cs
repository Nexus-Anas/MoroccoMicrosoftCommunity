using MMC.Core.Models;

namespace MMC.Core.Services;

public interface ISessionService
{
    Task<Session> Find(int id);
    Task<IEnumerable<Session>> FindAll();
    Task<Session> Create(Session entity);
    Task<Session> Update(int id, Session entity);
    Task Delete(int id);
}
