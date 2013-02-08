using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Domain.Models;

namespace Common.Domain.Interfaces.Repositories
{
	public interface ICategoryRepository : IGenericRepository<Category>
	{
		List<Category> GetAllChildCategories(Category category);

	}
}
