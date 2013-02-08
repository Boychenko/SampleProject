using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sample.Domain.Interfaces.Repositories;
using Sample.Domain.Models;

namespace Sample.Domain.Interfaces
{
	public interface IUnitOfWork
	{
		void SaveChanges();
		IGenericRepository<Product> ProductRepository { get; }
		ICategoryRepository CategoryRepository { get; }
	}

}
