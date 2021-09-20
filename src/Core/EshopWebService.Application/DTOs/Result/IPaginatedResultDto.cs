using System.Collections.Generic;

namespace EshopWebService.Application.DTOs.Result
{
    public interface IPaginatedResultDto<T> : IResultDto<List<T>>
    {
        int Page { get; }
        int TotalPages { get; }
        long TotalCount { get; }
        bool HasPreviousPage => Page > 1;
        bool HasNextPage => Page < TotalPages;
    }
}