using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sample.Domain.Models;

namespace Sample.DAL
{
	class DbInitializer : CreateDatabaseIfNotExists<SampleContext>
	{
		protected override void Seed(SampleContext context)
		{
			base.Seed(context);
			Category category1 = new Category()
				{
					Name = "firstCat",
					Description = "desc1"
				};
			Category category2 = new Category()
				{
					Name = "secondCat",
					Description = "desc2"
				};
			Category category3 = new Category()
				{
					Name = "parentCat",
					Description = "descP"
				};
			category3.ChildCategories = new Collection<Category>();
			category3.ChildCategories.Add(category1);
			category3.ChildCategories.Add(category2);
			Product product1 = new Product()
			{
				Name = "firstProd",
				Description = "firstProdDesc",
				CreatedTime = DateTime.UtcNow.AddMonths(-1)
			};
			Product product2 = new Product()
			{
				Name = "secondProd",
				Description = "secondProdDesc",
				CreatedTime = DateTime.UtcNow
			};

			category1.Products = new Collection<Product>();
			category1.Products.Add(product1);
			category2.Products = new Collection<Product>();
			category2.Products.Add(product2);

			Domain.Models.Attribute attribute = new Domain.Models.Attribute()
				{
					Name = "Energy"
				};
			AttributeValue attributeValue1 = new AttributeValue()
				{
					Value = "100",
					Attribute = attribute
				};
			AttributeValue attributeValue2 = new AttributeValue()
			{
				Value = "200",
				Attribute = attribute
			};
			product1.AttributeValues = new Collection<AttributeValue>();
			product1.AttributeValues.Add(attributeValue1);
			product2.AttributeValues = new Collection<AttributeValue>();
			product2.AttributeValues.Add(attributeValue2);

			context.Categories.AddOrUpdate(c => c.Name, category3);
		}
	}
}
