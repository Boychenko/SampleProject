using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain
{
	public static class QueryHelper
	{
		public static IQueryable<T> AddFilteringAndpaging<T>(this IQueryable<T> query, GeneralQueryParams<T> queryParams)
		{
			if (queryParams == null)
			{
				return query;
			}
			Expression<Func<T, bool>>[] whereExpressions = queryParams.WhereExpressions;
			Sorting<T>[] sortExpressions = queryParams.SortExpressions;
			PagingInfo pagingInfo = queryParams.PagingInfo;
			IQueryable<T> result = query;
			if(whereExpressions != null)
			{
				foreach(var whereExpression in whereExpressions)
				{
					result = result.Where(whereExpression);
				}
			}
			if(sortExpressions != null
				&& sortExpressions.Any())
			{
				IOrderedQueryable<T> orderedQueryable;
				var firstExpression = sortExpressions.First();
				if(firstExpression.SortingType == SortingType.Asc)
				{
					orderedQueryable = result.OrderBy(firstExpression.Expression);
				}
				else
				{
					orderedQueryable = result.OrderByDescending(firstExpression.Expression);
				}

				foreach(var sortExpression in sortExpressions.Skip(1))
				{
					if(sortExpression.SortingType == SortingType.Asc)
					{
						orderedQueryable = orderedQueryable.ThenBy(sortExpression.Expression);
					}
					else
					{
						orderedQueryable = orderedQueryable.ThenByDescending(sortExpression.Expression);
					}
				}
				result = orderedQueryable;
			}
			if(pagingInfo != null)
			{
				var total = result.Count();
				pagingInfo.TotalSize = total;
				result = result.Skip((pagingInfo.PageNumber - 1) * pagingInfo.PageSize).Take(pagingInfo.PageSize);//assume 1 based pages
			}
			return result;
		}
	}
}
