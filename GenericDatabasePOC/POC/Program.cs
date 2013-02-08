using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppSpecific.DAL;

namespace POC
{
	class Program
	{
		static void Main(string[] args)
		{
			var products = new ProductRepository().GetProducts();
			foreach (var product in products)
			{
				Console.WriteLine("Name: {0} Description:{1}, Category:{2}, Energy:{3}", product.Name, product.Description, product.CategoryName, product.Energy);
			}
			Console.ReadKey();
		}
	}
}
