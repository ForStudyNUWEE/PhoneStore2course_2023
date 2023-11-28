using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Linq.Expressions;
//using Microsoft.EntityFrameworkCore;
using Core;

namespace Core.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        public Task Save();

        public Task<List<TEntity>> GetAll();

        public Task<TEntity> GetByID(object id);

        public Task Insert(TEntity entity);

        public Task Delete(object id);

        public Task Delete(TEntity entityToDelete);

        public Task Update(TEntity entityToUpdate);
    }
}