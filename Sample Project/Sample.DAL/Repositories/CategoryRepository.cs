using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sample.Domain.Interfaces.Repositories;
using Sample.Domain.Models;

namespace Sample.DAL.Repositories
{
	public class CategoryRepository : GenericRepository<SampleContext, Category>, ICategoryRepository
	{
		public CategoryRepository(SampleContext dbContext) : base(dbContext)
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
