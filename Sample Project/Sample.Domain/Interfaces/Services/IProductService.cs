using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sample.Domain.Models;

namespace Sample.Domain.Interfaces.Services
{
	public interface IProductService
	{
		List<Product> GetProdutcs();
	}
}
