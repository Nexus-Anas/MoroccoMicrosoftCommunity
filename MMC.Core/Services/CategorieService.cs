using MMC.Core.Interfaces;
using MMC.Core.Models;

namespace MMC.Core.Services;

public class CategorieService : ICategorieService
{
    private readonly IRepository<Categorie> _repo;
    public CategorieService(IRepository<Categorie> repo) => _repo = repo;




    public async Task<Categorie> Find(int id)
        => await _repo.Get(id);
    public async Task<IEnumerable<Categorie>> FindAll()
        => await _repo.GetAll();
    public async Task<Categorie> Create(Categorie entity)
        => await _repo.Post(entity);
    public async Task<Categorie> Update(int id, Categorie entity)
        => await _repo.Put(id, entity);
    public async Task Delete(int id)
        => await _repo.Remove(id);
}