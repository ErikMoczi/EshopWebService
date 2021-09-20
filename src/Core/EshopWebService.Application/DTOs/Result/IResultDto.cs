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
}