using System.Collections.Generic;
using System.Linq;

namespace Vita.Application.Abstractions.Pagination
{
	public static class PagedListExtensions
    {
		public static PagedList<T> ToPagedList<T>(this IEnumerable<T> source, int pageNumber, int pageSize)
		{
			return ToPagedList(source.AsQueryable(), pageNumber, pageSize);
		}

		public static PagedList<T> ToPagedList<T>(this IQueryable<T> source, int pageNumber, int pageSize)
		{
			var count = source.Count();
			var items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

			return new PagedList<T>(items, count, pageNumber, pageSize);
		}
	}
}
