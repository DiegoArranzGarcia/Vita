using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Vita.Application.Abstractions.Pagination;

namespace Vita.API.Headers.Pagination
{
    public static class PaginationExtension
    {
        public static void AddPaginationMetadata<T>(this HttpResponse response, PagedList<T> page)
        {
			var metadata = new PaginationMetadata()
			{
				TotalCount = page.TotalCount,
				PageSize= page.PageSize,
				CurrentPage = page.CurrentPage,
				TotalPages = page.TotalPages,
				HasNext = page.HasNext,
				HasPrevious = page.HasPrevious
			};

			response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
		}
    }
}
