using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sample.Domain.Interfaces;
using Sample.Domain.Interfaces.Services;
using Sample.Domain.Models;

namespace Sample.Domain.Services
{
	public class ProductService : IProductService
	{
		private readonly IUnitOfWork _uow;

		public ProductService(IUnitOfWork uow)
		{
			if (uow == null)
			{
				throw new ArgumentNullException("uow");
			}
			_uow = uow;
		}

		public List<Product> GetProdutcs()
		{
			var products = _uow.ProductRepository.All;
			return products.ToList();
		}
	}
}
