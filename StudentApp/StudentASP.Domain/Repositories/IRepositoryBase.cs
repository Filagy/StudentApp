﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StudentASP.Domain.Repositories
{
    public interface IRepositoryBase<TEntity> : IDisposable where TEntity : class
    {
        Task<int> Create(TEntity obj);
        Task<TEntity> GetById(int? id);
        Task<List<TEntity>> GetAll();
        Task Update(TEntity obj);
        Task Delete(TEntity obj);
    }
}