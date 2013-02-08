using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sample.Domain.Models;

namespace Sample.Domain.Interfaces.Repositories
{
	public interface ICategoryRepository : IGenericRepository<Category>
	{
		List<Category> GetAllChildCategories(Category category);

	}
}
