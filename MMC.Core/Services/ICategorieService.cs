using MMC.Core.Models;

namespace MMC.Core.Services;

public interface ICategorieService
{
    Task<Categorie> Find(int id);
    Task<IEnumerable<Categorie>> FindAll();
    Task<Categorie> Create(Categorie entity);
    Task<Categorie> Update(int id, Categorie entity);
    Task Delete(int id);
}
