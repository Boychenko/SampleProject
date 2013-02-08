using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Common.Domain.Interfaces.Repositories;

namespace Common.DAL.Repositories
{
	public class GenericRepository<TContext, TEntity> : IGenericRepository<TEntity> 
		where TEntity: class 
		where TContext: DbContext
	{
		public GenericRepository(TContext dbContext)
        {
            if (dbContext == null)
            {
	            throw new ArgumentNullException("dbContext");
            }
            DbContext = dbContext;
			DbSet = DbContext.Set<TEntity>();
        }

		protected TContext DbContext { get; set; }

        protected DbSet<TEntity> DbSet { get; set; }


		public IQueryable<TEntity> All
		{
			get { return DbSet; }
		}
		public IQueryable<TEntity> AllIncluding(params Expression<Func<TEntity, object>>[] includeProperties)
		{
			IQueryable<TEntity> query = All;
			foreach(var includeProperty in includeProperties)
			{
				query = query.Include(includeProperty);
			}
			return query;
		}

		public TEntity Find(long id)
		{
			return DbSet.Find(id);
		}

		public virtual void Add(TEntity entity)
		{
			DbEntityEntry dbEntityEntry = DbContext.Entry(entity);
			if(dbEntityEntry.State != EntityState.Detached)
			{
				dbEntityEntry.State = EntityState.Added;
			}
			else
			{
				DbSet.Add(entity);
			}
		}

		public virtual void Update(TEntity entity)
		{
			DbEntityEntry dbEntityEntry = DbContext.Entry(entity);
			if(dbEntityEntry.State == EntityState.Detached)
			{
				DbSet.Attach(entity);
			}
			dbEntityEntry.State = EntityState.Modified;
		}

		public virtual void Delete(TEntity entity)
		{
			DbEntityEntry dbEntityEntry = DbContext.Entry(entity);
			if(dbEntityEntry.State != EntityState.Deleted)
			{
				dbEntityEntry.State = EntityState.Deleted;
			}
			else
			{
				DbSet.Attach(entity);
				DbSet.Remove(entity);
			}
		}

		public virtual void Delete(int id)
		{
			var entity = Find(id);
			if(entity == null) return; // not found; assume already deleted.
			Delete(entity);
		}
	}
}
