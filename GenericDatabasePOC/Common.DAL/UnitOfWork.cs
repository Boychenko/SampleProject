using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.DAL.Repositories;
using Common.Domain.Interfaces.Repositories;
using Common.Domain.Models;

namespace Common.DAL
{
	internal class UnitOfWork: IDisposable
	{
		private readonly GenericDatabasePOCContext _context;
		public UnitOfWork()
		{
			_context = new GenericDatabasePOCContext();
		}

		public void SaveChanges()
		{
			_context.SaveChanges();
		}

		public IGenericRepository<Product> ProductRepository
		{
			get { return new GenericRepository<GenericDatabasePOCContext, Product>(_context); }
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
