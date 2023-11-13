using MMC.Core.Models;

namespace MMC.Core.Services;

public interface IUserService
{
    Task<User> Find(int id);
    Task<IEnumerable<User>> FindAll();
    Task<User> Create(User entity);
    Task<User> Update(int id, User entity);
    Task Delete(int id);
}
