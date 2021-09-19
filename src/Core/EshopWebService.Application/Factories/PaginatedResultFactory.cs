using System.Collections.Generic;
using EshopWebService.Application.DTOs.Result;

namespace EshopWebService.Application.Factories
{
    public static class PaginatedResultDtoFactory
    {
        public static PaginatedResultDto<T> Failure<T>(string message)
        {
            return new PaginatedResultDto<T>(false, null, message);
        }

        public static PaginatedResultDto<T> Success<T>(List<T> data, long count, int page, int pageSize)
        {
            return new PaginatedResultDto<T>(true, data, null, count, page, pageSize);
        }
    }
}