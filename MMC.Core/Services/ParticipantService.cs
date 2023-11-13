using MMC.Core.Interfaces;
using MMC.Core.Models;

namespace MMC.Core.Services;

public class ParticipantService : IParticipantService
{
    private readonly IRepository<Participant> _repo;
    public ParticipantService(IRepository<Participant> repo) => _repo = repo;




    public async Task<Participant> Find(int id)
        => await _repo.Get(id);
    public async Task<IEnumerable<Participant>> FindAll()
        => await _repo.GetAll();
    public async Task<Participant> Create(Participant entity)
        => await _repo.Post(entity);
    public async Task<Participant> Update(int id, Participant entity)
        => await _repo.Put(id, entity);
    public async Task Delete(int id)
        => await _repo.Remove(id);
}
