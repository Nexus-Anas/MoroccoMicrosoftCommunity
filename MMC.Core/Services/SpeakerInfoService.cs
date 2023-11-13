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
    private readonly IRepository<SpeakerInfo> _repo;
    public SpeakerInfoService(IRepository<SpeakerInfo> repo) => _repo = repo;




    public async Task<SpeakerInfo> Find(int id)
        => await _repo.Get(id);
    public async Task<IEnumerable<SpeakerInfo>> FindAll()
        => await _repo.GetAll();
    public async Task<SpeakerInfo> Create(SpeakerInfo entity)
        => await _repo.Post(entity);
    public async Task<SpeakerInfo> Update(int id, SpeakerInfo entity)
        => await _repo.Put(id, entity);
    public async Task Delete(int id)
        => await _repo.Remove(id);
}
