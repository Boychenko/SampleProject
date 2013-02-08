using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sample.Domain.Interfaces;
using Sample.Domain.Interfaces.Repositories;
using Sample.DAL.Repositories;
using Sample.Domain.Models;

namespace Sample.DAL
{
	public class UnitOfWork: IDisposable, IUnitOfWork
	{
		private readonly SampleContext _context;
		public UnitOfWork(SampleContext context)
		{
			_context = context;
		}

		public void SaveChanges()
		{
			_context.SaveChanges();
		}

		public IGenericRepository<Product> ProductRepository
		{
			get { return new GenericRepository<SampleContext, Product>(_context); }
		}

		public ICategoryRepository CategoryRepository
		{
			get { return new CategoryRepository(_context); }
		}

		#region IDisposable

		private bool _disposed = false;

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!_disposed)
			{
				if(disposing)
				{
					if(_context != null)
					{
						_context.Dispose();
					}
				}
			}
			
			_disposed = true;
		}

		#endregion
	}
}
