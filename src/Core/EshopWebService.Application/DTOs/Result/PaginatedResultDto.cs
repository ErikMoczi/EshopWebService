using System;
using System.Collections.Generic;

namespace EshopWebService.Application.DTOs.Result
{
    public class PaginatedResultDto<T> : ResultDto<List<T>>, IPaginatedResultDto<List<T>>
    {
        public int Page { get; set; }
        public int TotalPages { get; set; }
        public long TotalCount { get; set; }

        internal PaginatedResultDto(bool success, List<T> data = default, string message = null, long count = 0, int page = 1, int pageSize = 10)
        {
            Message = message;
            Data = data;
            Page = page;
            Success = success;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            TotalCount = count;
        }
    }
}