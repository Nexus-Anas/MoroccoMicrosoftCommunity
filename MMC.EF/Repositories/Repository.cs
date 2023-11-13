using Microsoft.EntityFrameworkCore;
using MMC.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMC.EF.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly AppDbContext _db;
    private DbSet<T> _table { get; set; }


     

    public Repository(AppDbContext db)
    {
        _db = db;
        _table = _db.Set<T>();
    }




    public async Task<T> Post(T entity)
    {
        await _table.AddAsync(entity);
        await _db.SaveChangesAsync();
        return entity;
    }

    public async Task Remove(int id)
    {
        var data = await Get(id);
        if (data is not null)
        {
            _table.Remove(data);
            await _db.SaveChangesAsync();
        }
    }

    public async Task<T> Get(int id) => await _table.FindAsync(id);

    public async Task<IEnumerable<T>> GetAll() => await _table.ToListAsync();

    public async Task<T> Put(int id, T entity)
    {
        var data = await Get(id);
        if (data is null)
            return null;

        _db.Entry(data).CurrentValues.SetValues(entity);
        await _db.SaveChangesAsync();
        return data;
    }
}
