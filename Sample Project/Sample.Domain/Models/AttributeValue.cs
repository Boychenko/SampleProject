using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Domain.Models
{
	public class AttributeValue
	{
		public long Id { get; set; }
		public string Value { get; set; }
		public Attribute Attribute { get; set; }
		public Product Product { get; set; }
	}
}
