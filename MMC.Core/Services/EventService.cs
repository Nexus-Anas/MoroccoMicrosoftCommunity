using MMC.Core.Interfaces;
using MMC.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MMC.Core.Services;

public class EventService : IEventService
{
    private readonly IRepository<Event> _repo;
    public EventService(IRepository<Event> repo) => _repo = repo;




    public async Task<Event> GetEvent(int id)
        => await _repo.Get(id);
    public async Task<IEnumerable<Event>> GetAllEvents()
        => await _repo.GetAll();
    public async Task<Event> CreateEvent(Event entity)
        => await _repo.Add(entity);
    public async Task<Event> UpdateEvent(int id, Event entity)
        => await _repo.Update(id, entity);
    public async Task DeleteEvent(int id)
        => await _repo.Delete(id);
}
