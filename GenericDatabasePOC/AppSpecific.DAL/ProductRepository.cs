using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Common.DAL.Services;
using Common.Domain;
using Product = AppSpecific.Domain.Product;

namespace AppSpecific.DAL
{
	public class ProductRepository
	{
		public List<Product> GetProducts()
		{
			Sorting<Common.Domain.Models.Product> [] sortings = new Sorting<Common.Domain.Models.Product>[]
				{
					new Sorting<Common.Domain.Models.Product>()
						{
							SortingType = SortingType.Desc,
							Expression = p=>p.Name
						}, 
					new Sorting<Common.Domain.Models.Product>()
						{
							SortingType = SortingType.Asc,
							Expression = p=>p.Description
						}
				};
			var queryParams = new GeneralQueryParams<Common.Domain.Models.Product>()
				{
					WhereExpressions = null,//new Expression<Func<Common.Domain.Models.Product, bool>>[] { p => p.Name.StartsWith("fir") },
					SortExpressions = sortings

				};
			var commonProducts = new ProductsService().GetProducts("parentCat", queryParams);
			return commonProducts.Select(cp => new Product()
				{
					Id = cp.Id,
					Name = cp.Name,
					CategoryName = cp.Categories.Single().Name,
					Description = cp.Description,
					CreatedTime = cp.CreatedTime,
					Energy = cp.AttributeValues.Single(av => av.Attribute.Name == "Energy").Value
				}).ToList();
		}
	}
}
