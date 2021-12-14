﻿using Core.Entities;
using Core.Entities.Abstract;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    public interface IEntityRepository<T>
        where T : class, IEntity
    {
        T Add(T entity);
        T Update(T entity);
        void Delete(T entity);
        IEnumerable<T> GetList(Expression<Func<T, bool>> expression = null, params Expression<Func<T, object>>[] includeEntities);
        Task<IEnumerable<T>> GetListAsync(Expression<Func<T, bool>> expression = null, params Expression<Func<T, object>>[] includeEntities);
        PagingResult<T> GetListForPaging(int page, string propertyName, bool asc, Expression<Func<T, bool>> expression = null, params Expression<Func<T, object>>[] includeEntities);
        T Get(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includeEntities);
        Task<T> GetAsync(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includeEntities);
        int SaveChanges();
        Task<int> SaveChangesAsync();
        IQueryable<T> Query();

        TResult InTransaction<TResult>(Func<TResult> action, Action successAction = null, Action<Exception> exceptionAction = null);

        Task<int> GetCountAsync(Expression<Func<T, bool>> expression = null);
        int GetCount(Expression<Func<T, bool>> expression = null);
    }
}