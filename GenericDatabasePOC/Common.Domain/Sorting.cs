using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain
{
	public class Sorting<T>
	{
		public SortingType SortingType { get; set; }
		public Expression<Func<T, string>> Expression { get; set; }
	}
}
