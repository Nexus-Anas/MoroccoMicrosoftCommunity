using MMC.Core.Models;
namespace MMC.Core.Services;

public interface IEventService
{
    Task<Event> GetEvent(int id);
    Task<IEnumerable<Event>> GetAllEvents();
    Task<Event> CreateEvent(Event entity);
    Task<Event> UpdateEvent(int id, Event entity);
    Task DeleteEvent(int id);
}
