using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain
{
	public class GeneralQueryParams<T>
	{
		public Expression<Func<T, bool>>[] WhereExpressions { get; set; } 
		public Sorting<T>[] SortExpressions { get; set; }
		public PagingInfo PagingInfo { get; set; }
	}
}
