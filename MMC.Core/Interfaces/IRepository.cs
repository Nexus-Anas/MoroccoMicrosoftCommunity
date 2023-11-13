﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MMC.Core.Interfaces;

public interface IRepository<T> where T : class
{
    Task<T> Get(int id);
    Task<IEnumerable<T>> GetAll();
    Task<T> Add(T entity);
    Task<T> Update(int id, T entity);
    Task Delete(int id);
}
