using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Common.Domain;
using Common.Domain.Interfaces.Repositories;
using Common.Domain.Models;

namespace Common.DAL.Services
{
	public class ProductsService
	{
		public List<Product> GetProducts(string name, GeneralQueryParams<Product> queryParams) //include childs categoriess
		{
			using (var uow = new UnitOfWork())
			{
				var categories = GetChildCategories(name, uow.CategoryRepository);
				long[] ids = categories.Select(c => c.Id).ToArray();
				var rep = uow.ProductRepository;
				IQueryable<Product> allIncluding =
					rep.AllIncluding(p => p.Categories, p => p.AttributeValues, p => p.AttributeValues.Select(av => av.Attribute))
					   .Where(p => p.Categories.Any(c => ids.Contains(c.Id)));
				allIncluding = allIncluding.AddFilteringAndpaging(queryParams);
				
				return allIncluding.ToList();
			}
		}

		private List<Category> GetChildCategories(string name, ICategoryRepository repository)
		{
			Category category = repository.AllIncluding(c => c.ChildCategories).Single(c => c.Name == name);
			List<Category> result = new List<Category>();
			result.Add(category);
			result.AddRange(repository.GetAllChildCategories(category));
			return result;
		}
	}
}
