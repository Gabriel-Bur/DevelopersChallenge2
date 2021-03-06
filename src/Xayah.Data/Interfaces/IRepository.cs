﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Xayah.Data.Interfaces
{
    public interface IRepository<T> : IDisposable where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(Guid id);
        Task Insert(T obj);
        Task InsertRange(IEnumerable<T> obj);
        Task Update(Guid id, T obj);
        Task Delete(Guid id);
    }
}
