using System.Linq;
using System.Threading.Tasks;
using Ardalis.GuardClauses;
using EshopWebService.Application.DTOs.Result;
using EshopWebService.Application.Factories;
using Microsoft.EntityFrameworkCore;

namespace EshopWebService.Application.Extensions
{
    public static class QueryableExtensions
    {
        public static async Task<IPaginatedResultDto<T>> ToPaginatedListAsync<T>(this IQueryable<T> source, int pageNumber, int pageSize) where T : class
        {
            Guard.Against.Null(source, nameof(source));

            pageNumber = pageNumber <= 0 ? 1 : pageNumber;
            pageSize = pageSize == 0 ? 10 : pageSize;

            var count = await source.LongCountAsync();
            var items = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

            return PaginatedResultDtoFactory.Success(items, count, pageNumber, pageSize);
        }
    }
}