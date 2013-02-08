using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain
{
	public class PagingInfo
	{
		public int PageNumber { get; set; }
		public int PageSize { get; set; }
		public int TotalSize { get; set; }
	}
}
