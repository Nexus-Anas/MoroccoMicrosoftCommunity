using MMC.Core.Interfaces;
using MMC.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMC.Core.Services;

public class SpeakerInfoService : ISpeakerInfoService
{
    private readonly IRepository<Speaker> _repo;
    public SpeakerInfoService(IRepository<Speaker> repo) => _repo = repo;




    public async Task<Speaker> Find(int id)
        => await _repo.Get(id);
    public async Task<IEnumerable<Speaker>> FindAll()
        => await _repo.GetAll();
    public async Task<Speaker> Create(Speaker entity)
        => await _repo.Post(entity);
    public async Task<Speaker> Update(int id, Speaker entity)
        => await _repo.Put(id, entity);
    public async Task Delete(int id)
        => await _repo.Remove(id);
}
