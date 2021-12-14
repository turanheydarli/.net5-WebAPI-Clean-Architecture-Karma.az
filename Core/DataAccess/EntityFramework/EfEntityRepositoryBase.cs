using Core.Entities.Abstract;
using Core.Enums;
using Core.Extensions;
using Core.Utilities.Results;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{
	public class EfEntityRepositoryBase<TEntity, TContext>
		where TEntity : class, IEntity, new()
		where TContext : DbContext
	{
		public EfEntityRepositoryBase(TContext context)
		{
			Context = context;
		}

		protected TContext Context { get; }

		public TEntity Add(TEntity entity)
		{
			return Context.Add(entity).Entity;
		}

		public TEntity Update(TEntity entity)
		{
			Context.Update(entity);
			return entity;
		}

		public void Delete(TEntity entity)
		{
			Context.Remove(entity);
		}

		public TEntity Get(Expression<Func<TEntity, bool>> expression, params Expression<Func<TEntity, object>>[] includeEntities)
		{
			var list = Context.Set<TEntity>().AsQueryable();

			if (includeEntities.Length > 0)
				list = list.IncludeMultiple(includeEntities);

			return list.FirstOrDefault(expression);
		}

		public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression, 
			params Expression<Func<TEntity, object>>[] includeEntities)
		{
			var list = Context.Set<TEntity>().AsQueryable();

			if (includeEntities.Length > 0)
				list = list.IncludeMultiple(includeEntities);

			return await list.FirstOrDefaultAsync(expression);
		}

		public IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> expression = null, params Expression<Func<TEntity, object>>[] includeEntities)
		{
			var list = Context.Set<TEntity>().AsQueryable();

			if (includeEntities.Length > 0)
				list = list.IncludeMultiple(includeEntities);

			return expression == null
				?  list.ToList()
				:  list.Where(expression).ToList();
		}

		public async Task<IEnumerable<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> expression = null, params Expression<Func<TEntity, object>>[] includeEntities)
		{
			var list = Context.Set<TEntity>().AsQueryable();

			if (includeEntities.Length > 0)
				list = list.IncludeMultiple(includeEntities);

			return expression == null
				? await list.ToListAsync()
				: await list.Where(expression).ToListAsync();
		}

		public PagingResult<TEntity> GetListForPaging(int page, string propertyName, bool asc, Expression<Func<TEntity, bool>> expression = null, params Expression<Func<TEntity, object>>[] includeEntities)
		{
			var list = Context.Set<TEntity>().AsQueryable();

			if (includeEntities.Length > 0)
				list = list.IncludeMultiple(includeEntities);

			if (expression != null)
				list = list.Where(expression).AsQueryable();

			list = asc ? list.AscOrDescOrder(ESort.ASC, propertyName) : list.AscOrDescOrder(ESort.DESC, propertyName);
			int totalCount = list.Count();

			var start = (page - 1) * 10;
			list = list.Skip(start).Take(10);

			return new PagingResult<TEntity>(list.ToList(), totalCount, true, $"{totalCount} records listed.");
		}


		public int SaveChanges()
		{
			return Context.SaveChanges();
		}

		public Task<int> SaveChangesAsync()
		{
			return Context.SaveChangesAsync();
		}

		public IQueryable<TEntity> Query()
		{
			return Context.Set<TEntity>();
		}

		/// <summary>
		/// Transactional operations is prohibited when working with InMemoryDb!
		/// </summary>
		/// <typeparam name="TResult"></typeparam>
		/// <param name="action"></param>
		/// <param name="successAction"></param>
		/// <param name="exceptionAction"></param>
		/// <returns></returns>
		/// 
		public TResult InTransaction<TResult>(Func<TResult> action, Action successAction = null, Action<Exception> exceptionAction = null)
		{
			var result = default(TResult);
			try
			{
				if (Context.Database.ProviderName.EndsWith("InMemory"))
				{
					result = action();
					SaveChanges();
				}
				else
				{
					using (var tx = Context.Database.BeginTransaction())
					{
						try
						{
							result = action();
							SaveChanges();
							tx.Commit();
						}
						catch (Exception)
						{
							tx.Rollback();
							throw;
						}
					}
				}

				successAction?.Invoke();
			}
			catch (Exception ex)
			{
				if (exceptionAction == null)
				{
					throw;
				}

				exceptionAction(ex);
			}

			return result;
		}

		public async Task<int> GetCountAsync(Expression<Func<TEntity, bool>> expression = null)
		{
			if (expression == null)
			{
				return await Context.Set<TEntity>().CountAsync();
			}
			else
			{
				return await Context.Set<TEntity>().CountAsync(expression);
			}
		}

		public int GetCount(Expression<Func<TEntity, bool>> expression = null)
		{
			return expression == null ? Context.Set<TEntity>().Count() : Context.Set<TEntity>().Count(expression);
		}
	}
}

