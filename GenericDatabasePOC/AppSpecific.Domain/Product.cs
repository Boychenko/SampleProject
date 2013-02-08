using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSpecific.Domain
{
	public class Product
	{
		public long Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public DateTime CreatedTime { get; set; }
		public string CategoryName { get; set; }
		public string Energy { get; set; }
	}
}
