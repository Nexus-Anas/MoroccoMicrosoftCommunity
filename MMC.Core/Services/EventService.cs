using MMC.Core.Interfaces;
using MMC.Core.Models;

namespace MMC.Core.Services;

public class EventService : IEventService
{
    private readonly IRepository<Event> _repo;
    public EventService(IRepository<Event> repo) => _repo = repo;




    public async Task<Event> Find(int id)
        => await _repo.Get(id);
    public async Task<IEnumerable<Event>> FindAll()
        => await _repo.GetAll();
    public async Task<Event> Create(Event entity)
        => await _repo.Post(entity);
    public async Task<Event> Update(int id, Event entity)
        => await _repo.Put(id, entity);
    public async Task Delete(int id)
        => await _repo.Remove(id);
}