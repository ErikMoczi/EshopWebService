namespace EshopWebService.Application.DTOs.Result
{
    public class ResultDto : IResultDto
    {
        public string Message { get; set; }
        public bool Success { get; set; }
        public bool Failed => !Success;

        public ResultDto()
        {
        }
    }

    public class ResultDto<T> : ResultDto, IResultDto<T>
    {
        public T Data { get; set; }

        public ResultDto()
        {
        }
    }
}