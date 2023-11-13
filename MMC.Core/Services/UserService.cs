using MMC.Core.Interfaces;
using MMC.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMC.Core.Services;

public class UserService : IUserService
{
    private readonly IRepository<User> _repo;
    public UserService(IRepository<User> repo) => _repo = repo;




    public async Task<User> Find(int id)
        => await _repo.Get(id);
    public async Task<IEnumerable<User>> FindAll()
        => await _repo.GetAll();
    public async Task<User> Create(User entity)
        => await _repo.Post(entity);
    public async Task<User> Update(int id, User entity)
        => await _repo.Put(id, entity);
    public async Task Delete(int id)
        => await _repo.Remove(id);
}
