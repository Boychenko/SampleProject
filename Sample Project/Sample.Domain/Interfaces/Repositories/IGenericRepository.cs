using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Domain.Interfaces.Repositories
{
	public interface IGenericRepository<T>
	{
		IQueryable<T> All { get; }
		IQueryable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties);
		T Find(long id);
		void Add(T entity);
		void Update(T entity);
		void Delete(T entity);
		void Delete(int id);
	}
}
