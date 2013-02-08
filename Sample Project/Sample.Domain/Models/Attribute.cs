using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Domain.Models
{
	public class Attribute
	{
		public long Id { get; set; }
		public string Name { get; set; }
		public ICollection<AttributeValue> AttributeValues { get; set; } 
	}
}
