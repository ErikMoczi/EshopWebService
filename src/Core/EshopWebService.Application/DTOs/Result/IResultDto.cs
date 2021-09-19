namespace EshopWebService.Application.DTOs.Result
{
    public interface IResultDto
    {
        string Message { get; set; }
        bool Success { get; set; }
    }

    public interface IResultDto<out T> : IResultDto
    {
        T Data { get; }
    }

    public interface IPaginatedResultDto<out T> : IResultDto<T>
    {
        int Page { get; }
        int TotalPages { get; }
        long TotalCount { get; }
        bool HasPreviousPage => Page > 1;
        bool HasNextPage => Page < TotalPages;
    }
}