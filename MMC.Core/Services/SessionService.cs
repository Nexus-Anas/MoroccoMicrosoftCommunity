using MMC.Core.Interfaces;
using MMC.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMC.Core.Services;

internal class SessionService : ISessionService
{
    private readonly IRepository<Session> _repo;
    public SessionService(IRepository<Session> repo) => _repo = repo;




    public async Task<Session> Find(int id)
        => await _repo.Get(id);
    public async Task<IEnumerable<Session>> FindAll()
        => await _repo.GetAll();
    public async Task<Session> Create(Session entity)
        => await _repo.Post(entity);
    public async Task<Session> Update(int id, Session entity)
        => await _repo.Put(id, entity);
    public async Task Delete(int id)
        => await _repo.Remove(id);
}
