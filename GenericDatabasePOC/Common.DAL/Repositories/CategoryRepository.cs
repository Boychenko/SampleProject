using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Domain.Interfaces.Repositories;
using Common.Domain.Models;

namespace Common.DAL.Repositories
{
	public class CategoryRepository : GenericRepository<GenericDatabasePOCContext, Category>, ICategoryRepository
	{
		public CategoryRepository(GenericDatabasePOCContext dbContext) : base(dbContext)
		{
		}

		public List<Category> GetAllChildCategories(Category category)
		{
			var childQuery = DbContext.Entry(category).Collection(c => c.ChildCategories);
			if (!childQuery.IsLoaded)
			{
				childQuery.Load();
			}
			List<Category> result = new List<Category>(category.ChildCategories);
			foreach(var category1 in result.ToArray())
			{
				result.AddRange(GetAllChildCategories(category1));
			}
			return result;
		}
	}
}
