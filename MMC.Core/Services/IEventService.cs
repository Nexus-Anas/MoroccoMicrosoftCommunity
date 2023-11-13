using MMC.Core.Models;
namespace MMC.Core.Services;

public interface IEventService
{
    Task<Event> Find(int id);
    Task<IEnumerable<Event>> FindAll();
    Task<Event> Create(Event entity);
    Task<Event> Update(int id, Event entity);
    Task Delete(int id);
}
