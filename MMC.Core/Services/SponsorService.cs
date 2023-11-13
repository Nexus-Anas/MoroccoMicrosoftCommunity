using MMC.Core.Interfaces;
using MMC.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMC.Core.Services;

public class SponsorService : ISponsorService
{
    private readonly IRepository<Sponsor> _repo;
    public SponsorService(IRepository<Sponsor> repo) => _repo = repo;




    public async Task<Sponsor> Find(int id)
        => await _repo.Get(id);
    public async Task<IEnumerable<Sponsor>> FindAll()
        => await _repo.GetAll();
    public async Task<Sponsor> Create(Sponsor entity)
        => await _repo.Post(entity);
    public async Task<Sponsor> Update(int id, Sponsor entity)
        => await _repo.Put(id, entity);
    public async Task Delete(int id)
        => await _repo.Remove(id);
}
